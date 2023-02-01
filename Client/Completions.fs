namespace OpenAI

open System.Text.Json.Serialization
open OpenAI
open FsHttp.Helper

module Completions =
    type CreateRequest =
        { Model: string
          Prompt: string
          Temperature: float
          Stop: string }

    type ChoiceLogProbs =
        { Tokens: string list
          [<JsonPropertyName("token_logprobs")>]
          tokenLogProbs: float list
          [<JsonPropertyName("top_logprobs")>]
          topLogProbs: (int * string) list option
          [<JsonPropertyName("text_offset")>]
          textOffset: int list }

    type Choice =
        { Text: string
          Index: int
          LogProbs: ChoiceLogProbs option
          [<JsonPropertyName("finish_reason")>]
          FinishReason: string }

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

    let completions (config: Config) : ConfigWithCompletionContext =
        ConfigWithCompletionContext(
            { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/completions" },
            config.HttpRequester
        )

    let create (request: CreateRequest) (config: ConfigWithCompletionContext) : CreateResponse =
        config.HttpRequester.postRequest<CreateRequest, CreateResponse> config.ApiConfig request
