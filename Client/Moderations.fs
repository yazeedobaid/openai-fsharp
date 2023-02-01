namespace OpenAI

open System.Text.Json.Serialization
open FsHttp.Helper
open OpenAI

module Moderations =
    type CreateRequest = { Model: string; Input: string }

    type Categories =
        { Hate: bool
          [<JsonPropertyName("hate/threatening")>]
          HateOrThreatening: bool
          [<JsonPropertyName("self-harm")>]
          SelfHarm: bool
          Sexual: bool
          [<JsonPropertyName("sexual/minors")>]
          SexualOrMinors: bool
          Violence: bool
          [<JsonPropertyName("violence/graphic")>]
          ViolenceOrGraphic: bool }

    type CategoryScores =
        { Hate: double
          [<JsonPropertyName("hate/threatening")>]
          HateOrThreatening: double
          [<JsonPropertyName("self-harm")>]
          SelfHarm: double
          Sexual: double
          [<JsonPropertyName("sexual/minors")>]
          SexualOrMinors: double
          Violence: double
          [<JsonPropertyName("violence/graphic")>]
          ViolenceOrGraphic: double }

    type Result =
        { Categories: Categories
          [<JsonPropertyName("category_scores")>]
          CategoryScores: CategoryScores
          Flagged: bool }

    type CreateResponse =
        { Id: string
          Model: string
          results: Result[] }


    let moderations (config: Config) : Config =
        { config with
            ApiConfig = { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/moderations" } }

    let create (request: CreateRequest) (config: Config) : CreateResponse =
        config.HttpRequester.sendRequest<CreateRequest, CreateResponse> config.ApiConfig request
