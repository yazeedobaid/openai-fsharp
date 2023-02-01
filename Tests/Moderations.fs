module Tests.Moderations

open OpenAI
open OpenAI.Client
open OpenAI.Moderations
open Tests.Helpers
open Expecto
open Tests.Fixtures.Moderations

[<Tests>]
let tests =
    testList
        "moderations"
        [ test "moderations create test" {
              let response = createModerationResponse ()
              let responseObject = serialize<CreateResponse> response

              let client =
                  { ApiConfig = { ApiKey = "apiKey"; Endpoint = url "" }
                    HttpRequester = HttpRequester() }

              let response =
                  client
                  |> moderations
                  |> create
                      { Model = "text-moderation-latest"
                        Input = "I want to kill them." }

              Expect.equal response responseObject ""
          }

          test "moderations create test using computation expression" {
              let response = createModerationResponse ()
              let responseObject = serialize<CreateResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      moderations
                      create
                          { Model = "text-moderation-latest"
                            Input = "I want to kill them." }
                  }

              Expect.equal response responseObject ""
          } ]
