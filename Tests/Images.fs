module Tests.Images

open System.IO
open OpenAI
open OpenAI.Client
open OpenAI.Images
open Tests.Helpers
open Expecto
open Tests.Fixtures.Images

[<Tests>]
let tests =
    testList
        "images"
        [ test "images create test" {
              let response = createImageResponse ()
              let responseObject = serialize<CreateResponse> response

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> images
                  |> create
                      { Prompt = "A cute baby sea otter"
                        N = 2
                        Size = "1024x1024"
                        responseFormat = "url" }

              Expect.equal response responseObject ""
          }

          test "images create test using computation expression" {
              let response = createImageResponse ()
              let responseObject = serialize<CreateResponse> response

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      images
                      create
                          { Prompt = "A cute baby sea otter"
                            N = 2
                            Size = "1024x1024"
                            responseFormat = "url" }
                  }

              Expect.equal response responseObject ""
          }
          
          test "images edit test" {
              let response = editImageResponse ()
              let responseObject = serialize<EditResponse> response
              let sampleImagePath = Path.Combine("Tests", "Fixtures", "sample-image.png")

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> images
                  |> edit
                      { Image = sampleImagePath
                        Mask = sampleImagePath
                        Prompt = ""
                        N = 2
                        Size = "1024x1024"
                        responseFormat = "url" }

              Expect.equal response responseObject ""
          }

          test "images edit test using computation expression" {
              let response = editImageResponse ()
              let responseObject = serialize<EditResponse> response
              let sampleImagePath = Path.Combine("Tests", "Fixtures", "sample-image.png")

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      images
                      edit
                          { Image = sampleImagePath
                            Mask = sampleImagePath
                            Prompt = ""
                            N = 2
                            Size = "1024x1024"
                            responseFormat = "url" }
                  }

              Expect.equal response responseObject ""
          }
          
          test "images variation test" {
              let response = variationImageResponse ()
              let responseObject = serialize<VariationResponse> response
              let sampleImagePath = Path.Combine("Tests", "Fixtures", "sample-image.png")

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> images
                  |> variation
                      { Image = sampleImagePath
                        N = 2
                        Size = "1024x1024"
                        responseFormat = "url" }

              Expect.equal response responseObject ""
          }

          test "images variation test using computation expression" {
              let response = variationImageResponse ()
              let responseObject = serialize<VariationResponse> response
              let sampleImagePath = Path.Combine("Tests", "Fixtures", "sample-image.png")

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      images
                      variation
                          { Image = sampleImagePath
                            N = 2
                            Size = "1024x1024"
                            responseFormat = "url" }
                  }

              Expect.equal response responseObject ""
          } ]
