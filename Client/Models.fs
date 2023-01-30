namespace OpenAI.Models

open OpenAI
open FsHttp.Helper

[<AutoOpen>]
module Models =
    let models (config: Config) : Config =
        { config with ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/models" } }

    let list (config: Config) : ListModelsResponse =
        config.HttpRequester.sendRequestGet<ListModelsResponse> config.ApiConfig

    let retrieve (modelName: string) (config: Config) : ModelResponse =
        { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint modelName }
        |> config.HttpRequester.sendRequestGet<ModelResponse>
