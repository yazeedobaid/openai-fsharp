namespace OpenAI

open OpenAI.Completions

type OpenAIComputed() =
    // Required - creates default "starting" values
    member _.Yield _ =
        { ApiConfig = { Endpoint = ""; ApiKey = "" }
          HttpRequester = HttpRequester() }

    [<CustomOperation "endPoint">]
    // Sets OpenAI end point
    member _.EndPoint(state: Config, endPoint: string) =
        { state with
            ApiConfig =
                { Endpoint = endPoint
                  ApiKey = state.ApiConfig.ApiKey } }

    [<CustomOperation "apiKey">]
    // Sets OpenAI API Key
    member _.ApiKey(state: Config, apiKey: string) =
        { state with
            ApiConfig =
                { Endpoint = state.ApiConfig.Endpoint
                  ApiKey = apiKey } }

    [<CustomOperation "completions">]
    // Start OpenAI Completions resource handling
    member _.Completions(state: Config) = completions state

    [<CustomOperation "create">]
    // Start OpenAI Completions resource handling
    member _.Create(state: Config, request: CreateRequest) = create request state


module Client =
    let sendRequest (config: Config) (data: (string * string) list) =
        config.HttpRequester.sendRequest config.ApiConfig data

    let openAI = OpenAIComputed()
