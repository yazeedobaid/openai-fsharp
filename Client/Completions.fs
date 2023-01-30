namespace OpenAI

open System.Text.Json.Serialization
open OpenAI.Client

module Completions =

    type CreateRequest =
        { Model: string
          Prompt: string
          Temperature: float
          Stop: string }

    type CreateResponseChoiceLogProbs =
        { Tokens: string list
          [<JsonPropertyName("token_logprobs")>]
          tokenLogProbs: float list
          [<JsonPropertyName("top_logprobs")>]
          topLogProbs: (int * string) list option
          [<JsonPropertyName("text_offset")>]
          textOffset:  int list }

    type Choice =
        { Text: string
          Index: int
          LogProbs: CreateResponseChoiceLogProbs option
          [<JsonPropertyName("finish_reason")>]
          FinishReason: string }

    type CreateResponseUsage =
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
          Usage: CreateResponseUsage }

    let completions (config: Config) : Config = config

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> config.ApiConfig request
