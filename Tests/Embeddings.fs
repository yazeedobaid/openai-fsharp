module Tests.Embeddings

open OpenAI
open OpenAI.Client
open OpenAI.Embeddings
open Tests.Helpers
open Expecto
open Tests.Fixtures.Embeddings

[<Tests>]
let tests =
    testList
        "embeddings"
        [ test "embeddings create test" {
              let response = createEmbeddingResponse ()
              let responseObject = serialize<CreateResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> embeddings
                  |> create
                      { Model = "text-embedding-ada-002"
                        Input = "The food was delicious and the waiter..." }

              Expect.equal response responseObject ""
          }

          test "embeddings create test using computation expression" {
              let response = createEmbeddingResponse ()
              let responseObject = serialize<CreateResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      embeddings
                      create
                          { Model = "text-embedding-ada-002"
                            Input = "The food was delicious and the waiter..." }
                  }

              Expect.equal response responseObject ""
          } ]
