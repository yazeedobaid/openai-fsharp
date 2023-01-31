namespace OpenAI

open System.Text.Json.Serialization
open FsHttp
open FsHttp.Helper
open OpenAI

module Images =
    type CreateRequest =
        { Prompt: string
          N: int
          Size: string
          [<JsonPropertyName("response_format")>]
          responseFormat: string }

    type EditRequest =
        { Image: string
          Mask: string
          Prompt: string
          N: int
          Size: string
          [<JsonPropertyName("response_format")>]
          responseFormat: string }

    type VariationRequest =
        { Image: string
          N: int
          Size: string
          [<JsonPropertyName("response_format")>]
          responseFormat: string }

    type Data =
        { Url: string
          [<JsonPropertyName("b64_json")>]
          B64Json: string }

    type CreateResponse = { Created: int; Data: Data[] }

    type EditResponse = { Created: int; Data: Data[] }

    type VariationResponse = { Created: int; Data: Data[] }


    let images (config: Config) : Config =
        { config with ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/images" } }

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        let apiConfig =
            { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/generations" }

        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> apiConfig request

    let edit (request: EditRequest) (config: Config) : EditResponse =
        let apiConfig =
            { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/edits" }
        
        let httpRequest = config.HttpRequester.PrepareRequestForMultiPart apiConfig {
                multipart
                filePartWithName "image" request.Image
                filePartWithName "mask" request.Mask
                stringPart "prompt" request.Prompt
                stringPart "n" (request.N.ToString())
                stringPart "size" request.Size
                stringPart "response_format" request.responseFormat
        }
        
        config.HttpRequester.sendRequestMultiPart<EditResponse> httpRequest

    let variation (request: VariationRequest) (config: Config) : VariationResponse =
        let apiConfig =
            { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/variations" }

        let httpRequest = config.HttpRequester.PrepareRequestForMultiPart apiConfig {
                multipart
                filePartWithName "image" request.Image
                stringPart "n" (request.N.ToString())
                stringPart "size" request.Size
                stringPart "response_format" request.responseFormat
        }
        
        config.HttpRequester.sendRequestMultiPart<VariationResponse> httpRequest
