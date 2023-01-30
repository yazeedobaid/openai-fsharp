namespace OpenAI

// General Types

type ApiConfig = { Endpoint: string; ApiKey: string }

type IHttpRequester =
    abstract member sendRequest<'T, 'R> : config: ApiConfig -> data: 'T -> 'R

type Config =
    { ApiConfig: ApiConfig
      HttpRequester: IHttpRequester }

// Completions Resource Types

namespace OpenAI.Completions

open System.Text.Json.Serialization

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
      textOffset: int list }

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
