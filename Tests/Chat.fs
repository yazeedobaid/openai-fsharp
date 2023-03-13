module Tests.Chat

open OpenAI
open OpenAI.Client
open OpenAI.Chat
open Tests.Helpers
open Expecto
open Tests.Fixtures.Chat

[<Tests>]
let tests =
    testList
        "chat"
        [ test "chat create test" {
              let response = createChatResponse ()
              let responseObject = serialize<CreateResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> chat
                  |> create
                      { Model = "text-davinci-003"
                        Messages = [| {Role = "user"; Content = "Hello!"} |] }

              Expect.equal response responseObject ""
          }

          test "chat create test using computation expression" {
              let response = createChatResponse ()
              let responseObject = serialize<CreateResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      chat

                      create
                          { Model = "text-davinci-003"
                            Messages = [| {Role = "user"; Content = "Hello!"} |] }
                  }

              Expect.equal response responseObject ""
          } ]
