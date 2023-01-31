namespace OpenAI

open FsHttp

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

        member this.PrepareRequestForMultiPart(config: ApiConfig) =
            http {
                POST config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
            }

        member this.sendRequestMultiPart<'R>(httpRequest: MultipartContext) =
            httpRequest |> Request.send |> Response.deserializeJson<'R>

        member this.sendRequestGet<'R>(config: ApiConfig) =
            http {
                GET config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
            }
            |> Request.send
            |> Response.deserializeJson<'R>
