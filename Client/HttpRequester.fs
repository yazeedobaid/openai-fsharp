namespace OpenAI

open System.Text.Json
open FsHttp

type HttpRequester() =
    interface IHttpRequester with
        member this.postRequest<'T, 'R> (config: ApiConfig) (data: 'T) =
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
        
        member this.postRequestEmpty<'R> (config: ApiConfig) =
            http {
                POST config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
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

        member this.postRequestMultiPart<'R>(httpRequest: MultipartContext) =
            httpRequest |> Request.send |> Response.deserializeJson<'R>

        member this.getRequest<'R>(config: ApiConfig) =
            http {
                GET config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
            }
            |> Request.send
            |> Response.deserializeJson<'R>
        
        member this.getRequestString(config: ApiConfig) =
            http {
                GET config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
            }
            |> Request.send
            |> Response.toText
        
        member this.deleteRequest<'R>(config: ApiConfig) =
            http {
                DELETE config.Endpoint
                AuthorizationBearer config.ApiKey
                Accept "application/json"
                CacheControl "no-cache"
            }
            |> Request.send
            |> Response.deserializeJson<'R>
