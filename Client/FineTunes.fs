namespace OpenAI

open System.Text.Json.Serialization
open FsHttp.Helper
open OpenAI

module FineTunes =

    type CreateRequest =
        { [<JsonPropertyName("training_file")>]
          TrainingFile: string
          [<JsonPropertyName("validation_file")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          ValidationFile: string option
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          Model: string option
          [<JsonPropertyName("n_epochs")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          NEpochs: int option
          [<JsonPropertyName("batch_size")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          BatchSize: int option
          [<JsonPropertyName("learning_rate_multiplier")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          LearningRateMultiplier: float option
          [<JsonPropertyName("prompt_loss_weight")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          PromptLossWeight: float option
          [<JsonPropertyName("compute_classification_metrics")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          ComputeClassificationMetrics: bool option
          [<JsonPropertyName("classification_n_classes")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          ClassificationNClasses: int option
          [<JsonPropertyName("classification_positive_class")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          ClassificationPositiveClass: string option
          [<JsonPropertyName("classification_betas")>]
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          ClassificationBetas: float[] option
          [<JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)>]
          Suffix: string option }

        static member Default =
            { TrainingFile = ""
              ValidationFile = None
              Model = None
              NEpochs = None
              BatchSize = None
              LearningRateMultiplier = None
              PromptLossWeight = None
              ComputeClassificationMetrics = None
              ClassificationNClasses = None
              ClassificationPositiveClass = None
              ClassificationBetas = None
              Suffix = None }

    type Event =
        { Object: string
          [<JsonPropertyName("created_at")>]
          CreatedAt: int
          Level: string
          Message: string }

    type HyperParam =
        { [<JsonPropertyName("batch_size")>]
          BatchSize: int option
          [<JsonPropertyName("learning_rate_multiplier")>]
          LearningRate_Multiplier: float option
          [<JsonPropertyName("n_epochs")>]
          NEpochs: int
          [<JsonPropertyName("prompt_loss_weight")>]
          PromptLossWeight: float }

    type FineTuneFile =
        { Id: string
          Object: string
          Bytes: int
          [<JsonPropertyName("created_at")>]
          CreatedAt: int
          FileName: string
          Purpose: string }

    type FineTune =
        { Id: string
          Object: string
          Model: string
          [<JsonPropertyName("created_at")>]
          CreatedAt: int
          Events: Event[]
          [<JsonPropertyName("fine_tuned_model")>]
          FineTunedModel: string option
          [<JsonPropertyName("hyperparams")>]
          HyperParams: HyperParam
          [<JsonPropertyName("organization_id")>]
          OrganizationId: string
          [<JsonPropertyName("result_files")>]
          ResultFiles: FineTuneFile[]
          Status: string
          [<JsonPropertyName("validation_files")>]
          ValidationFiles: FineTuneFile[]
          [<JsonPropertyName("training_files")>]
          TrainingFiles: FineTuneFile[]
          [<JsonPropertyName("updated_at")>]
          UpdatedAt: int }

    type CreateResponse = FineTune

    type ListResponse = { Object: string; Data: FineTune[] }

    type RetrieveFineTuneResponse = FineTune

    type CancelFineTuneResponse = FineTune

    type ListFineTuneEventsResponse = { Object: string; Data: Event[] }

    let fineTunes (config: Config) : ConfigWithFineTuneContext =
        ConfigWithFineTuneContext(
            { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint "/fine-tunes" },
            config.HttpRequester
        )

    let create (request: CreateRequest) (config: ConfigWithFineTuneContext) : CreateResponse =
        config.HttpRequester.postRequest<CreateRequest, CreateResponse> config.ApiConfig request

    let list (config: ConfigWithFineTuneContext) : ListResponse =
        config.HttpRequester.getRequest<ListResponse> config.ApiConfig

    let retrieve (fineTuneId: string) (config: ConfigWithFineTuneContext) : RetrieveFineTuneResponse =
        { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint fineTuneId }
        |> config.HttpRequester.getRequest<RetrieveFineTuneResponse>

    let cancel (fineTuneId: string) (config: ConfigWithFineTuneContext) : CancelFineTuneResponse =
        config.HttpRequester.postRequestEmpty<CancelFineTuneResponse>
            { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint (fineTuneId + "/cancel") }

    let listEvents (fineTuneId: string) (config: ConfigWithFineTuneContext) : ListFineTuneEventsResponse =
        { config.ApiConfig with Endpoint = Url.combine config.ApiConfig.Endpoint (fineTuneId + "/events") }
        |> config.HttpRequester.getRequest<ListFineTuneEventsResponse>
