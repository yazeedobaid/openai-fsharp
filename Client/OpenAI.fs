namespace OpenAI

open OpenAI.Models
open OpenAI.Completions
open OpenAI.Edits

type OpenAIComputed() =
    // Required - creates default "starting" values
    member _.Yield _ =
        { ApiConfig = { Endpoint = ""; ApiKey = "" }
          HttpRequester = HttpRequester() }

    [<CustomOperation "endPoint">]
    // Sets OpenAI end point
    member _.EndPoint(config: Config, endPoint: string) =
        { config with
            ApiConfig =
                { Endpoint = endPoint
                  ApiKey = config.ApiConfig.ApiKey } }

    [<CustomOperation "apiKey">]
    // Sets OpenAI API Key
    member _.ApiKey(config: Config, apiKey: string) =
        { config with
            ApiConfig =
                { Endpoint = config.ApiConfig.Endpoint
                  ApiKey = apiKey } }

    [<CustomOperation "models">]
    // Start OpenAI Models resource handling
    member _.Models(config: Config) = models config

    [<CustomOperation "list">]
    // Models List Endpoint
    member _.List(config: Config) : ListModelsResponse = list config

    [<CustomOperation "retrieve">]
    // Models List Endpoint
    member _.Retrieve(config: Config, modelName: string) : ModelResponse = retrieve modelName config

    [<CustomOperation "completions">]
    // Start OpenAI Completions resource handling
    member _.Completions(config: Config) = Completions.completions config

    [<CustomOperation "create">]
    // Completions Create Endpoint
    member _.Create(config: Config, request: Completions.CreateRequest) : Completions.CreateResponse =
        Completions.create request config

    [<CustomOperation "edits">]
    // Start OpenAI Edits resource handling
    member _.Edits(config: Config) = edits config

    [<CustomOperation "create">]
    // Edits Create Endpoint
    member _.Create(config: Config, request: Edits.CreateRequest) : Edits.CreateResponse =
        Edits.create request config


module Client =
    let sendRequest (config: Config) (data: (string * string) list) =
        config.HttpRequester.sendRequest config.ApiConfig data

    let openAI = OpenAIComputed()
