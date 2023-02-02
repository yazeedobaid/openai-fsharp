open System.IO
open Fake.Core
open Fake.Core.TargetOperators
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.DotNet
open Fake.Api
open Fake.Tools

// ------------------------------------------- Definitions -------------------------------------------

Context.FakeExecutionContext.Create false "build.fsx" []
|> Context.RuntimeContext.Fake
|> Context.setExecutionContext

let outputDirectory = "./out"
Directory.delete outputDirectory

let changelog = Changelog.load (__SOURCE_DIRECTORY__ </> ".." </> "CHANGELOG.md")

let gitHubToken = Environment.environVarOrNone "GITHUB_TOKEN"
let gitHubOwner = "yazeedobaid"
let gitHubRepoName = "openai-fsharp"

let nuGetToken = Environment.environVarOrNone "NUGET_TOKEN"

let clean _ =
    let cleanOptions (defaults: DotNet.Options) =
        { defaults with
            CustomParams = Some("--c release") }

    DotNet.exec cleanOptions "clean" "" |> ignore

let restore _ =
    DotNet.exec id "paket install" "" |> ignore

let checkFormatting _ =
    let result = DotNet.exec id "fantomas" "Client/ Tests/ Build/ --recurse --check"

    if result.ExitCode = 0 then
        Trace.log "No files need formatting"
    elif result.ExitCode = 99 then
        failwith
            "Some files need formatting, please run \"dotnet fantomas  Client/ Tests/ Build/ --recurse\" to resolve this."
    else
        failwith "Errors while formatting"

let build _ =
    let buildOptions (defaults: DotNet.BuildOptions) =
        { defaults with
            Configuration = DotNet.BuildConfiguration.Release }

    DotNet.build buildOptions "openai-fsharp.sln"

let test _ =
    let processResult = DotNet.exec id "run" "--project Tests"

    if processResult.ExitCode <> 0 then
        failwithf "Tests failed."

let pack _ =
    Directory.ensure outputDirectory

    let notes = changelog.LatestEntry.ToString()

    let args =
        [ sprintf "/p:PackageVersion=%s" changelog.LatestEntry.NuGetVersion
          sprintf "/p:PackageReleaseNotes=\"%s\"" notes ]

    DotNet.pack
        (fun c ->
            { c with
                Configuration = DotNet.BuildConfiguration.Release
                OutputPath = Some outputDirectory
                Common = c.Common |> DotNet.Options.withAdditionalArgs args })
        "Client"

let githubRelease () =
    let releaseNotes = changelog.LatestEntry.ToString()
    let tag = changelog.LatestEntry.NuGetVersion.ToString()

    Git.Branches.tag "" tag
    Git.Branches.pushTag "" "origin" tag
    
    GitHub.createClientWithToken gitHubToken.Value
    |> GitHub.draftNewRelease
        gitHubOwner
        gitHubRepoName
        (changelog.LatestEntry.NuGetVersion.ToString())
        (changelog.LatestEntry.SemVer.PreRelease <> None)
        (releaseNotes |> Seq.singleton)
    |> GitHub.uploadFiles !!(outputDirectory </> "*.nupkg")
    |> GitHub.publishDraft
    |> Async.RunSynchronously

let nuGetPush () =
    Paket.push
    <| fun c ->
        { c with
            ToolType = ToolType.CreateLocalTool()
            PublishUrl = "https://www.nuget.org"
            WorkingDir = outputDirectory
            ApiKey = nuGetToken.Value }

let release _ =
    //nuGetPush ()
    githubRelease ()

// --------------------------------------------- Targets ---------------------------------------------

Target.create "Clean" clean
Target.create "Restore" restore
Target.create "Build" build
Target.create "Test" test
Target.create "CheckFormatting" checkFormatting
Target.create "Pack" pack
Target.create "Release" release

let dependencies =
    [ "Clean" ==> "Restore" ==> "Build" ==> "Test"

      "Test" ==> "Pack" ==> "Release" ]

[<EntryPoint>]
let main args =
    match args.Length > 0 with
    | true -> Target.runOrDefault args[0]
    | _ -> Target.runOrDefault "Test"

    0
