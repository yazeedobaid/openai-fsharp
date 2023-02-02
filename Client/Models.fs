namespace OpenAI

open OpenAI
open FsHttp.Helper

module Models =
    open System.Text.Json.Serialization

    type ModelPermission =
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
          Permission: ModelPermission[]
          Root: string
          Parent: string option }

    type ListModelsResponse =
        { Object: string
          Data: ModelResponse[] }

    type DeleteModelResponse =
        { Id: string
          Object: string
          Deleted: bool }

    let models (config: Config) : ConfigWithModelContext =
        ConfigWithModelContext(
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/models" },
            config.HttpRequester
        )

    let list (config: ConfigWithModelContext) : ListModelsResponse =
        config.HttpRequester.getRequest<ListModelsResponse> config.ApiConfig

    let retrieve (modelName: string) (config: ConfigWithModelContext) : ModelResponse =
        { config.ApiConfig with
            Endpoint = Url.combine config.ApiConfig.Endpoint modelName }
        |> config.HttpRequester.getRequest<ModelResponse>

    let delete (modelId: string) (config: ConfigWithModelContext) : DeleteModelResponse =
        { config.ApiConfig with
            Endpoint = Url.combine config.ApiConfig.Endpoint modelId }
        |> config.HttpRequester.deleteRequest<DeleteModelResponse>
