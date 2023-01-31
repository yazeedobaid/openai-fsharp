namespace OpenAI

open System.Text.Json.Serialization
open FsHttp.Helper
open OpenAI

module Embeddings =
    type CreateRequest = { Model: string; Input: string }

    type Embedding =
        { Object: string
          Embedding: float[]
          Index: int }

    type Usage =
        { [<JsonPropertyName("prompt_tokens")>]
          PromptTokens: int
          [<JsonPropertyName("total_tokens")>]
          TotalTokens: int }

    type CreateResponse =
        { Object: string
          Data: Embedding[]
          Usage: Usage }


    let embeddings (config: Config) : Config =
        { config with
            ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/embeddings" } }

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> config.ApiConfig request
