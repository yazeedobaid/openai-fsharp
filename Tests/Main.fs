module test

open Tests.Fixtures.Models
open Tests.Fixtures.Completions
open Tests.Fixtures.Edits
open Tests.Fixtures.Images
open Tests.Fixtures.Embeddings
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
            POST >=> path "/edits" >=> request (fun _ -> createEditResponse () |> Successful.OK)
            POST >=> path "/images/generations" >=> request (fun _ -> createImageResponse () |> Successful.OK)
            POST >=> path "/images/edits" >=> request (fun _ -> editImageResponse () |> Successful.OK)
            POST >=> path "/images/variations" >=> request (fun _ -> variationImageResponse () |> Successful.OK)
            POST >=> path "/embeddings" >=> request (fun _ -> createEmbeddingResponse () |> Successful.OK)
        ]
        |> serve

    Tests.runTestsInAssembly defaultConfig argv
