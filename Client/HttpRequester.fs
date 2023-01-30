namespace OpenAI

open FsHttp

type IHttpRequester =
    abstract member sendRequest<'T, 'R> : config: ApiConfig -> data: 'T -> 'R


type HttpRequester() =
    interface IHttpRequester with
        member this.sendRequest<'T, 'R> (config: ApiConfig) (data: 'T) =
            http {
                POST config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
                body
                ContentType "application/json"
                jsonSerialize data
            }
            |> Request.send
            |> Response.deserializeJson<'R>
