module Tests.Edits

open OpenAI
open OpenAI.Client
open OpenAI.Edits
open Tests.Helpers
open Expecto
open Tests.Fixtures.Edits

[<Tests>]
let tests =
    testList
        "edits"
        [ test "edits create test" {
              let response = createEditResponse ()
              let responseObject = serialize<CreateResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> edits
                  |> create
                      { Model = "text-davinci-edit-001"
                        Input = "What day of the wek is it?"
                        Instruction = "Fix the spelling mistakes" }

              Expect.equal response responseObject ""
          }

          test "completions create test using computation expression" {
              let response = createEditResponse ()
              let responseObject = serialize<CreateResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      edits
                      create
                          { Model = "text-davinci-edit-001"
                            Input = "What day of the wek is it?"
                            Instruction = "Fix the spelling mistakes" }
                  }

              Expect.equal response responseObject ""
          } ]
