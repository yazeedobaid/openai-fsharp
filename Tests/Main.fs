module test

open System.IO
open Tests.Fixtures.Models
open Tests.Fixtures.Completions
open Tests.Fixtures.Chat
open Tests.Fixtures.Edits
open Tests.Fixtures.Images
open Tests.Fixtures.Embeddings
open Tests.Fixtures.Audio
open Tests.Fixtures.Moderations
open Tests.Fixtures.Files
open Tests.Fixtures.FineTunes
open Tests.Helpers
open Suave
open Suave.Operators
open Suave.Filters
open Expecto

[<EntryPoint>]
let main argv =
    let fixturesPath = Path.Combine("Tests", "Fixtures", "sample-json.txt")

    use _ =
        choose
            [ GET
              >=> path "/models"
              >=> request (fun _ -> listModelsResponse () |> Successful.OK)
              GET
              >=> pathScan "/models/%s" (fun _ -> request (fun _ -> retrieveModelResponse () |> Successful.OK))
              DELETE
              >=> pathScan "/models/%s" (fun _ -> request (fun _ -> deleteModelResponse () |> Successful.OK))
              POST
              >=> path "/completions"
              >=> request (fun _ -> createCompletionResponse () |> Successful.OK)
              POST
              >=> path "/chat/completions"
              >=> request (fun _ -> createChatResponse () |> Successful.OK)
              POST
              >=> path "/edits"
              >=> request (fun _ -> createEditResponse () |> Successful.OK)
              POST
              >=> path "/images/generations"
              >=> request (fun _ -> createImageResponse () |> Successful.OK)
              POST
              >=> path "/images/edits"
              >=> request (fun _ -> editImageResponse () |> Successful.OK)
              POST
              >=> path "/images/variations"
              >=> request (fun _ -> variationImageResponse () |> Successful.OK)
              POST
              >=> path "/embeddings"
              >=> request (fun _ -> createEmbeddingResponse () |> Successful.OK)
              POST
              >=> path "/audio/transcriptions"
              >=> request (fun req ->
                 match req.fieldData "language" with
                 | Choice1Of2 _ -> transcriptWithLanguageResponse () |> Successful.OK
                 | Choice2Of2 _ -> transcriptResponse () |> Successful.OK
              )
              POST
              >=> path "/audio/translations"
              >=> request (fun _ -> translateResponse () |> Successful.OK)
              POST
              >=> path "/moderations"
              >=> request (fun _ -> createModerationResponse () |> Successful.OK)
              GET
              >=> path "/files"
              >=> request (fun _ -> listFilesResponse () |> Successful.OK)
              POST
              >=> path "/files"
              >=> request (fun _ -> uploadFileResponse () |> Successful.OK)
              DELETE
              >=> pathScan "/files/%s" (fun _ -> request (fun _ -> deleteFileResponse () |> Successful.OK))
              GET
              >=> pathScan "/files/%s/content" (fun _ ->
                  request (fun _ -> File.ReadAllText fixturesPath |> Successful.OK))
              GET
              >=> pathScan "/files/%s" (fun _ -> request (fun _ -> retrieveFileResponse () |> Successful.OK))
              POST
              >=> path "/fine-tunes"
              >=> request (fun _ -> createFineTuneResponse () |> Successful.OK)
              GET
              >=> path "/fine-tunes"
              >=> request (fun _ -> listFineTunesResponse () |> Successful.OK)
              GET
              >=> pathScan "/fine-tunes/%s/events" (fun _ ->
                  request (fun _ -> listFineTuneEventsResponse () |> Successful.OK))
              GET
              >=> pathScan "/fine-tunes/%s" (fun _ -> request (fun _ -> retrieveFineTuneResponse () |> Successful.OK))
              POST
              >=> pathScan "/fine-tunes/%s/cancel" (fun _ ->
                  request (fun _ -> cancelFineTuneResponse () |> Successful.OK)) ]
        |> serve

    Tests.runTestsInAssembly defaultConfig argv
