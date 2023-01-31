namespace OpenAI

open FsHttp
open FsHttp.Domain

// General Types

type ApiConfig = { Endpoint: string; ApiKey: string }

type IHttpRequester =
    abstract member sendRequest<'T, 'R> : config: ApiConfig -> data: 'T -> 'R
    abstract member PrepareRequestForMultiPart: config: ApiConfig -> HeaderContext
    abstract member sendRequestMultiPart<'R> : httpRequest: MultipartContext -> 'R
    abstract member sendRequestGet<'R> : config: ApiConfig -> 'R

type Config =
    { ApiConfig: ApiConfig
      HttpRequester: IHttpRequester }
