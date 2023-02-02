namespace OpenAI

open FsHttp
open FsHttp.Domain

// General Types

type ApiConfig = { Endpoint: string; ApiKey: string }

type IHttpRequester =
    abstract member postRequest<'T, 'R> : config: ApiConfig -> data: 'T -> 'R
    abstract member postRequestEmpty<'R> : config: ApiConfig -> 'R
    abstract member PrepareRequestForMultiPart: config: ApiConfig -> HeaderContext
    abstract member postRequestMultiPart<'R> : httpRequest: MultipartContext -> 'R
    abstract member getRequest<'R> : config: ApiConfig -> 'R
    abstract member getRequestString: config: ApiConfig -> string
    abstract member deleteRequest<'R> : config: ApiConfig -> 'R

type Config(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    member this.ApiConfig = apiConfig
    member this.HttpRequester = httpRequester

// following types act like context switchers. To be able to use same API
// name for different resources. For example, models and files resources
// both have list and retrieve APIs. So to make it consistent and use same
// API name for both, below types were added to APIs signatures.

type ConfigWithModelContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithCompletionContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithEditContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithImageContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithEmbeddingContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithModerationContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithFileContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)

type ConfigWithFineTuneContext(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    inherit Config(apiConfig, httpRequester)
