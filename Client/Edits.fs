namespace OpenAI.Edits

open OpenAI
open FsHttp.Helper

[<AutoOpen>]
module Edits =
    let edits (config: Config) : Config =
        { config with
            ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/edits" } }

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> config.ApiConfig request
