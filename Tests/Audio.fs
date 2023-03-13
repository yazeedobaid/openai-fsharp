module Tests.Audio

open System.IO
open OpenAI
open OpenAI.Client
open OpenAI.Audio
open Tests.Helpers
open Expecto
open Tests.Fixtures.Audio

[<Tests>]
let tests =
    testList
        "audio"
        [ test "audio transcript test" {
              let response = transcriptResponse ()
              let responseObject = serialize<TranscriptResponse> response
              let sampleFilePath = Path.Combine("Tests", "Fixtures", "sample-audio.mp3")

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> audio
                  |> transcript
                      { TranscriptRequest.Default with
                          File = sampleFilePath
                          Model = "whisper-1" }

              Expect.equal response responseObject ""
          }

          test "audio transcript test using computation expression" {
              let response = transcriptResponse ()
              let responseObject = serialize<TranscriptResponse> response
              let sampleFilePath = Path.Combine("Tests", "Fixtures", "sample-audio.mp3")

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      audio

                      transcript
                          { TranscriptRequest.Default with
                              File = sampleFilePath
                              Model = "whisper-1" }
                  }

              Expect.equal response responseObject ""
          }

          test "audio transcript with language test" {
              let response = transcriptWithLanguageResponse ()
              let responseObject = serialize<TranscriptResponse> response
              let sampleFilePath = Path.Combine("Tests", "Fixtures", "sample-audio.mp3")

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> audio
                  |> transcript
                      { TranscriptRequest.Default with
                          File = sampleFilePath
                          Model = "whisper-1"
                          Language = Some("ar") }

              Expect.equal response responseObject ""
          }

          test "audio translate test" {
              let response = translateResponse ()
              let responseObject = serialize<TranslateResponse> response
              let sampleFilePath = Path.Combine("Tests", "Fixtures", "sample-audio.mp3")

              let client = Config({ ApiKey = "apiKey"; Endpoint = url "" }, HttpRequester())

              let response =
                  client
                  |> audio
                  |> translate
                      { File = sampleFilePath
                        Model = "whisper-1" }

              Expect.equal response responseObject ""
          }

          test "audio translate test using computation expression" {
              let response = translateResponse ()
              let responseObject = serialize<TranslateResponse> response
              let sampleFilePath = Path.Combine("Tests", "Fixtures", "sample-audio.mp3")

              let response =
                  openAI {
                      endPoint (url "")
                      apiKey "apiKey"
                      audio

                      translate
                          { File = sampleFilePath
                            Model = "whisper-1" }
                  }

              Expect.equal response responseObject ""
          } ]
