module test

open Tests.Fixtures.Models
open Tests.Fixtures.Completions
open Tests.Helpers
open Suave
open Suave.Operators
open Suave.Filters
open Expecto

[<EntryPoint>]
let main argv =
    use _ =
        choose [
            GET >=> path "/models" >=> request (fun _ -> listModelsResponse () |> Successful.OK)
            GET >=> pathScan "/models/%s" (fun _ -> request (fun _ -> retrieveModelResponse () |> Successful.OK))
            POST >=> path "/completions" >=> request (fun _ -> createCompletionResponse () |> Successful.OK)
        ]
        |> serve

    Tests.runTestsInAssembly defaultConfig argv
