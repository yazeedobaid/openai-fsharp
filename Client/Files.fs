namespace OpenAI

open System.Text.Json.Serialization
open FsHttp.Helper
open FsHttp
open OpenAI

module Files =

    type UploadRequest = { Purpose: string; File: string }

    type File =
        { Id: string
          Object: string
          Bytes: int
          [<JsonPropertyName("created_at")>]
          CreatedAt: int
          FileName: string
          Purpose: string }

    type ListResponse = { Object: string; Data: File[] }

    type UploadFileResponse = File

    type RetrieveFileResponse = File

    type DeleteResponse =
        { Id: string
          Object: string
          Deleted: bool }

    let files (config: Config) : ConfigWithFileContext =
        ConfigWithFileContext(
            { config.ApiConfig with
                Endpoint = Url.combine config.ApiConfig.Endpoint "/files" },
            config.HttpRequester
        )

    let list (config: ConfigWithFileContext) : ListResponse =
        config.HttpRequester.getRequest<ListResponse> config.ApiConfig

    let upload (request: UploadRequest) (config: ConfigWithFileContext) : UploadFileResponse =
        let httpRequest =
            config.HttpRequester.PrepareRequestForMultiPart config.ApiConfig {
                multipart
                filePartWithName "file" request.File
                stringPart "purpose" request.Purpose
            }

        config.HttpRequester.postRequestMultiPart<UploadFileResponse> httpRequest

    let delete (fileId: string) (config: ConfigWithFileContext) : DeleteResponse =
        { config.ApiConfig with
            Endpoint = Url.combine config.ApiConfig.Endpoint fileId }
        |> config.HttpRequester.deleteRequest<DeleteResponse>

    let retrieve (fileId: string) (config: ConfigWithFileContext) : RetrieveFileResponse =
        { config.ApiConfig with
            Endpoint = Url.combine config.ApiConfig.Endpoint fileId }
        |> config.HttpRequester.getRequest<RetrieveFileResponse>

    let download (fileId: string) (config: ConfigWithFileContext) : string =
        { config.ApiConfig with
            Endpoint = Url.combine config.ApiConfig.Endpoint (fileId + "/content") }
        |> config.HttpRequester.getRequestString
