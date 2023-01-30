namespace OpenAI

module Client =
    type Config =
        { ApiConfig: ApiConfig
          HttpRequester: IHttpRequester }

    let sendRequest (config: Config) (data: (string * string) list) =
        config.HttpRequester.sendRequest config.ApiConfig data




