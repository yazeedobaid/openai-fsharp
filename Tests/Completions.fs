module Tests.Completions

open OpenAI
open OpenAI.Client
open OpenAI.Completions
open Tests.Helpers
open Expecto
open Suave
open Suave.Operators
open Suave.Filters
open Tests.Fixtures.Completions

[<Tests>]
let tests =
    testList
        "completions"
        [ test "completions create test" {
              let response = createCompletionResponse ()
              let responseObject = serialize<CreateResponse> response

              use _ = POST >=> request (fun _ -> response |> Successful.OK) |> serve

              let client =
                  { ApiConfig = { ApiKey = "apiKey"; Endpoint = url "" }
                    HttpRequester = HttpRequester() }

              let response =
                  client
                  |> completions
                  |> create
                      { Model = "text-davinci-003"
                        Prompt = "the earth has a shape of"
                        Temperature = 0
                        Stop = "." }

              Expect.equal response responseObject ""
          }
          test "completions create test using computation expression" {
              let response = createCompletionResponse ()
              let responseObject = serialize<CreateResponse> response

              use _ = POST >=> request (fun _ -> response |> Successful.OK) |> serve

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      completions

                      create
                          { Model = "text-davinci-003"
                            Prompt = "the earth has a shape of"
                            Temperature = 0
                            Stop = "." }
                  }

              Expect.equal response responseObject ""
          } ]
