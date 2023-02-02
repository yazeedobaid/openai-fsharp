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


    let embeddings (config: Config) : ConfigWithEmbeddingContext =
        ConfigWithEmbeddingContext(
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/embeddings" },
            config.HttpRequester
        )

    let create (request: CreateRequest) (config: ConfigWithEmbeddingContext) : CreateResponse =
        config.HttpRequester.postRequest<CreateRequest, CreateResponse> config.ApiConfig request
