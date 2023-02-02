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

    let edits (config: Config) : ConfigWithEditContext =
        ConfigWithEditContext(
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/edits" },
            config.HttpRequester
        )

    let create (request: CreateRequest) (config: ConfigWithEditContext) : CreateResponse =
        config.HttpRequester.postRequest<CreateRequest, CreateResponse> config.ApiConfig request
