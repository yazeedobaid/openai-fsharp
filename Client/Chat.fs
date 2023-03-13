namespace OpenAI

open System.Text.Json.Serialization
open OpenAI
open FsHttp.Helper

module Chat =
    type RequestMessage = { Role: string; Content: string }

    type CreateRequest =
        { Model: string
          Messages: RequestMessage[] }

    type ResponseMessage = { Role: string; Content: string }

    type Choice =
        { Message: ResponseMessage
          Index: int
          [<JsonPropertyName("finish_reason")>]
          FinishReason: string option }

    type Usage =
        { [<JsonPropertyName("prompt_tokens")>]
          PromptTokens: int
          [<JsonPropertyName("completion_tokens")>]
          CompletionTokens: int option
          [<JsonPropertyName("total_tokens")>]
          TotalTokens: int }

    type CreateResponse =
        { Id: string
          Object: string
          Created: int
          Model: string
          Choices: Choice[]
          Usage: Usage }

    let chat (config: Config) : ConfigWithChatContext =
        ConfigWithChatContext(
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/chat" },
            config.HttpRequester
        )

    let create (request: CreateRequest) (config: ConfigWithChatContext) : CreateResponse =
        let apiConfig =
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/completions" }
        config.HttpRequester.postRequest<CreateRequest, CreateResponse> apiConfig request
