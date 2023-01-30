namespace OpenAI.Completions

open OpenAI
open FsHttp.Helper

[<AutoOpen>]
module Completions =
    let completions (config: Config) : Config =
        { config with
            ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/completions" } }

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> config.ApiConfig request
