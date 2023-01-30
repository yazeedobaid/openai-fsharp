namespace OpenAI

// General Types

type ApiConfig = { Endpoint: string; ApiKey: string }

type IHttpRequester =
    abstract member sendRequest<'T, 'R> : config: ApiConfig -> data: 'T -> 'R
    abstract member sendRequestGet<'R> : config: ApiConfig -> 'R

type Config =
    { ApiConfig: ApiConfig
      HttpRequester: IHttpRequester }


// Models Resource Types

namespace OpenAI.Models

open System.Text.Json.Serialization

type ModelPermissionResponse =
    { Id: string
      Object: string
      Created: int
      [<JsonPropertyName("allow_create_engine")>]
      AllowCreateEngine: bool
      [<JsonPropertyName("allow_sampling")>]
      AllowSampling: bool
      [<JsonPropertyName("allow_logprobs")>]
      AllowLogprobs: bool
      [<JsonPropertyName("allow_search_indices")>]
      AllowSearchIndices: bool
      [<JsonPropertyName("allow_view")>]
      AllowView: bool
      [<JsonPropertyName("allow_fine_tuning")>]
      AllowFineTuning: bool
      Organization: string
      Group: string option
      IsBlocking: bool }

type ModelResponse =
    { Id: string
      Object: string
      Created: int
      [<JsonPropertyName("owned_by")>]
      OwnedBy: string
      Permission: ModelPermissionResponse[]
      Root: string
      Parent: string option }

type ListModelsResponse =
    { Object: string
      Data: ModelResponse[] }


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


// Edits Resource Types

namespace OpenAI.Edits

open System.Text.Json.Serialization

type CreateRequest =
    { Model: string
      Input: string
      Instruction: string }

type CreateResponseChoiceLogProbs =
    { Tokens: string list
      [<JsonPropertyName("token_logprobs")>]
      tokenLogProbs: float list
      [<JsonPropertyName("top_logprobs")>]
      topLogProbs: (int * string) list option
      [<JsonPropertyName("text_offset")>]
      textOffset: int list }

type Choice = { Text: string; Index: int }

type CreateResponseUsage =
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
      Usage: CreateResponseUsage }
