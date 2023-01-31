namespace OpenAI

open System.Text.Json.Serialization
open OpenAI
open FsHttp.Helper

module Edits =
    type CreateRequest =
        { Model: string
          Input: string
          Instruction: string }

    type Choice = { Text: string; Index: int }

    type Usage =
        { [<JsonPropertyName("prompt_tokens")>]
          PromptTokens: int
          [<JsonPropertyName("completion_tokens")>]
          CompletionTokens: int option
          [<JsonPropertyName("total_tokens")>]
          TotalTokens: int }

    type CreateResponse =
        { Object: string
          Created: int
          Choices: Choice[]
          Usage: Usage }

    let edits (config: Config) : Config =
        { config with ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/edits" } }

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> config.ApiConfig request
