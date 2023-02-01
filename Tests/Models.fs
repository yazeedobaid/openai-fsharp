module Tests.Models

open OpenAI
open OpenAI.Client
open OpenAI.Models
open Tests.Helpers
open Tests.Fixtures.Models
open Expecto

[<Tests>]
let tests =
    testList
        "models"
        [ test "models list test" {
              let response = listModelsResponse ()
              let responseObject = serialize<ListModelsResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> models |> list

              Expect.equal response responseObject ""
          }

          test "models list using computation expression" {
              let response = listModelsResponse ()
              let responseObject = serialize<ListModelsResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      models
                      list
                  }

              Expect.equal response responseObject ""
          }

          test "model retrieve test" {
              let response = retrieveModelResponse ()
              let responseObject = serialize<ModelResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> models |> retrieve "text-davinci-003"

              Expect.equal response responseObject ""
          }

          test "model retrieve using computation expression" {
              let response = retrieveModelResponse ()
              let responseObject = serialize<ModelResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      models
                      retrieve "text-davinci-003"
                  }

              Expect.equal response responseObject ""
          } ]
