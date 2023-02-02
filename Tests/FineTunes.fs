module Tests.FineTunes

open OpenAI
open OpenAI.Client
open OpenAI.FineTunes
open Tests.Helpers
open Tests.Fixtures.FineTunes
open Expecto

[<Tests>]
let tests =
    testList
        "fine-tunes"
        [ test "fine-tunes create test" {
              let response = createFineTuneResponse ()
              let responseObject = serialize<CreateResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> fineTunes
                  |> create
                      { CreateRequest.Default with
                          TrainingFile = "file-Lpe0n5tOHtoG6OVVbk5d4iXA" }

              Expect.equal response responseObject ""
          }

          test "fine-tunes create using computation expression" {
              let response = createFineTuneResponse ()
              let responseObject = serialize<CreateResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      fineTunes

                      create
                          { CreateRequest.Default with
                              TrainingFile = "file-Lpe0n5tOHtoG6OVVbk5d4iXA" }
                  }

              Expect.equal response responseObject ""
          }

          test "fine-tunes list test" {
              let response = listFineTunesResponse ()
              let responseObject = serialize<ListResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> fineTunes |> list

              Expect.equal response responseObject ""
          }

          test "fine-tunes list using computation expression" {
              let response = listFineTunesResponse ()
              let responseObject = serialize<ListResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      fineTunes
                      list
                  }

              Expect.equal response responseObject ""
          }

          test "fine-tunes retrieve test" {
              let response = retrieveFineTuneResponse ()
              let responseObject = serialize<RetrieveFineTuneResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> fineTunes |> retrieve "ft-BFEIdtwzxz4UsnVcdQRInPKI"

              Expect.equal response responseObject ""
          }

          test "fine-tunes retrieve using computation expression" {
              let response = retrieveFineTuneResponse ()
              let responseObject = serialize<RetrieveFineTuneResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      fineTunes
                      retrieve "ft-BFEIdtwzxz4UsnVcdQRInPKI"
                  }

              Expect.equal response responseObject ""
          }

          test "fine-tunes cancel test" {
              let response = cancelFineTuneResponse ()
              let responseObject = serialize<CancelFineTuneResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> fineTunes |> cancel "ft-BFEIdtwzxz4UsnVcdQRInPKI"

              Expect.equal response responseObject ""
          }

          test "fine-tunes cancel using computation expression" {
              let response = cancelFineTuneResponse ()
              let responseObject = serialize<CancelFineTuneResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      fineTunes
                      cancel "ft-BFEIdtwzxz4UsnVcdQRInPKI"
                  }

              Expect.equal response responseObject ""
          }

          test "fine-tunes list events test" {
              let response = listFineTuneEventsResponse ()
              let responseObject = serialize<ListFineTuneEventsResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response = client |> fineTunes |> listEvents "ft-BFEIdtwzxz4UsnVcdQRInPKI"

              Expect.equal response responseObject ""
          }

          test "fine-tunes list events using computation expression" {
              let response = listFineTuneEventsResponse ()
              let responseObject = serialize<ListFineTuneEventsResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      fineTunes
                      listEvents "ft-BFEIdtwzxz4UsnVcdQRInPKI"
                  }

              Expect.equal response responseObject ""
          } ]
