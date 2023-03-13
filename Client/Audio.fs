namespace OpenAI

open FsHttp.Helper
open FsHttp
open OpenAI

module Audio =

    type TranscriptRequest =
        { File: string
          Model: string
          Language: string option }

        static member Default =
            { File = ""
              Model = ""
              Language = None }

    type TranscriptResponse = { Text: string }

    type TranslateRequest = { File: string; Model: string }

    type TranslateResponse = { Text: string }

    let audio (config: Config) : ConfigWithAudioContext =
        ConfigWithAudioContext(
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/audio" },
            config.HttpRequester
        )

    let transcript (request: TranscriptRequest) (config: ConfigWithAudioContext) : TranscriptResponse =
        let apiConfig =
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/transcriptions" }

        let httpRequest =
            config.HttpRequester.PrepareRequestForMultiPart apiConfig {
                multipart
                filePartWithName "file" request.File
                stringPart "model" request.Model
            }

        match request.Language with
        | Some language -> httpRequest |> Dsl.Multipart.stringPart "language" language
        | None -> httpRequest
        |> config.HttpRequester.postRequestMultiPart<TranscriptResponse>

    let translate (request: TranslateRequest) (config: ConfigWithAudioContext) : TranslateResponse =
        let apiConfig =
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/translations" }

        let httpRequest =
            config.HttpRequester.PrepareRequestForMultiPart apiConfig {
                multipart
                filePartWithName "file" request.File
                stringPart "model" request.Model
            }

        config.HttpRequester.postRequestMultiPart<TranslateResponse> httpRequest
