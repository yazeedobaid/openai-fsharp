namespace OpenAI

open FsHttp
open FsHttp.Domain

// General Types

type ApiConfig = { Endpoint: string; ApiKey: string }

type IHttpRequester =
    abstract member postRequest<'T, 'R> : config: ApiConfig -> data: 'T -> 'R
    abstract member PrepareRequestForMultiPart: config: ApiConfig -> HeaderContext
    abstract member postRequestMultiPart<'R> : httpRequest: MultipartContext -> 'R
    abstract member getRequest<'R> : config: ApiConfig -> 'R
    abstract member getRequestString : config: ApiConfig -> string
    abstract member deleteRequest<'R> : config: ApiConfig -> 'R

type Config(apiConfig: ApiConfig, httpRequester: IHttpRequester) =
    member this.ApiConfig = apiConfig
    member this.HttpRequester = httpRequester

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
