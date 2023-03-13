<div align="center">
    <img width="80%" src="https://raw.githubusercontent.com/yazeedobaid/openai-fsharp/main/art/example-snippet.png" alt="OpenAI F#">
    <br />
    <br />
    <p align="center">
        <a href="https://github.com/yazeedobaid/openai-fsharp/actions"><img alt="GitHub Workflow Status (main)" src="https://img.shields.io/github/actions/workflow/status/yazeedobaid/openai-fsharp/build.yml?branch=main&label=build&style=round-square"></a>
        <a href="https://github.com/yazeedobaid/openai-fsharp/blob/main/LICENSE"><img alt="License" src="https://img.shields.io/github/license/yazeedobaid/openai-fsharp"></a>
        <a href="https://www.nuget.org/packages/OpenAI.Client"><img alt="NuGet Version" src="https://img.shields.io/nuget/v/openai.client?color=blue"></a>
        <a href="https://www.nuget.org/packages/OpenAI.Client"><img alt="NuGet Version" src="https://img.shields.io/nuget/dt/openai.client?color=green"></a>
    </p>
</div>

------
**OpenAI F#** is a library that allows you to interact with [Open AI API](https://beta.openai.com/docs/api-reference/introduction) in an easy,
fluent, and typed way!

## Get Started

Add the library to your project using DotNet CLI:

```bash
dotnet add package OpenAI.Client
```

Or using Paket:

```bash
paket add OpenAI.Client
```

The library provide two styles to consume the APIs, either a methods calls through pipe operator as shown below:

```fsharp
open OpenAI
open OpenAI.Client
open OpenAI.Models

let client =
    Config(
        { Endpoint = "https://api.openai.com/v1"
          ApiKey = "your-api-key" },
        HttpRequester()
    )
    
let result = client |> models |> list
```

Or using a computation expression builder object as shown below:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        list
    }
```

You can check OpenAI API reference at [API reference](https://platform.openai.com/docs/api-reference).

## Usage

### `Models` Resource

List and describe the various models available in the API. You can refer to the Models documentation to understand 
what models are available and the differences between them.

#### `list`

Lists the currently available models, and provides basic information about each one such as the owner and availability.

```fsharp
let result = client |> models |> list
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        list
    }
```

#### `retrieve`

Retrieves a model instance, providing basic information about the model such as the owner and permissioning.

```fsharp
let result = client |> models |> retrieve "text-davinci-003"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        retrieve "text-davinci-003"
    }
```

#### `delete`

Delete a fine-tuned model.

```fsharp
let result = client |> models |> delete "curie:ft-acmeco-2021-03-03-21-44-20"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        delete "curie:ft-acmeco-2021-03-03-21-44-20"
    }
```

<br />

### `Completions` Resource

Given a prompt, the model will return one or more predicted completions, and can also return the probabilities 
of alternative tokens at each position.

#### `create`

Creates a completion for the provided prompt and parameters.

```fsharp
let result =
    client
    |> completions
    |> Completions.create
        { Model = "text-davinci-003"
          Prompt = "What is the meaning of living?"
          Temperature = 0.5
          Stop = "." }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
     endPoint "https://api.openai.com/v1"
     apiKey "your-api-key"
     completions
     create
        { Model = "text-davinci-003"
          Prompt = "What is the meaning of living?"
          Temperature = 0.5
          Stop = "." }
    }
```

<br />

### `Chat` Resource

Given a chat conversation, the model will return a chat completion response.

#### `create`

Creates a completion for the chat message.

```fsharp
let result =
    client
    |> chat
    |> create
      { Model = "text-davinci-003"
        Messages = [| {Role = "user"; Content = "Hello!"} |] }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
    endPoint (url "")
    apiKey "apiKey"
    chat
    create
      { Model = "text-davinci-003"
        Messages = [| {Role = "user"; Content = "Hello!"} |] }
    }
```

<br />

### `Edits` Resource

Given a prompt and an instruction, the model will return an edited version of the prompt.

#### `create`

Creates a new edit for the provided input, instruction, and parameters.

```fsharp
let result =
    client
    |> edits
    |> Edits.create
           { Model = "text-davinci-edit-001"
             Input = "What day of the wek is it?"
             Instruction = "Fix the spelling mistakes" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
     endPoint "https://api.openai.com/v1"
     apiKey "your-api-key"
     edits
     create
        { Model = "text-davinci-edit-001"
         Input = "What day of the wek is it?"
         Instruction = "Fix the spelling mistakes" }
    }
```

<br />

### `Images` Resource

Given a prompt and/or an input image, the model will generate a new image.

#### `create`

Creates an image given a prompt.

```fsharp
let result =
    client
    |> images
    |> create
         { Prompt = "A cute baby sea otter"
           N = 2
           Size = "1024x1024"
           responseFormat = "url" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        images
        create
            { Prompt = "A cute baby sea otter"
              N = 2
              Size = "1024x1024"
              responseFormat = "url" }
    }
```

#### `edit`

Creates an edited or extended image given an original image and a prompt.

```fsharp
let result =
    client
    |> images
    |> edit
        { Image = "sample.png"
          Mask = "sample.png"
          Prompt = "A cute baby sea otter wearing a beret"
          N = 2
          Size = "1024x1024"
          responseFormat = "url" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        images
        edit
            { Image = "sample.png"
              Mask = "sample.png"
              Prompt = "A cute baby sea otter wearing a beret"
              N = 2
              Size = "1024x1024"
              responseFormat = "url" }
    }
```

#### `variation`

Creates a variation of a given image.

```fsharp
let result =
    client
    |> images
    |> variation
        { Image = "sample.png"
          N = 2
          Size = "1024x1024"
          responseFormat = "url" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
     endPoint "https://api.openai.com/v1"
     apiKey "your-api-key"
     images
     variation
        { Image = "sample.png"
          N = 2
          Size = "1024x1024"
          responseFormat = "url" }
    }
```

<br />

### `Embeddings` Resource

Get a vector representation of a given input that can be easily consumed by machine learning models and algorithms.

#### `create`

Creates an embedding vector representing the input text.

```fsharp
let result =
    client
    |> embeddings
    |> create
        { Model = "text-embedding-ada-002"
          Input = "The food was delicious and the waiter..." }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        embeddings
        create
             { Model = "text-embedding-ada-002"
               Input = "The food was delicious and the waiter..." }
    }
```

<br />

### `Audio` Resource

Turn audio into text.

#### `transcript`

Transcribes audio into the input language.

```fsharp
let result =
    client
    |> audio
    |> transcript
      { TranscriptRequest.Default with
          File = "sample-audio.mp3"
          Model = "whisper-1" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
      endPoint (url "")
      apiKey "apiKey"
      audio
      transcript
          { TranscriptRequest.Default with
              File = "sample-audio.mp3"
              Model = "whisper-1" }
    }
```

#### `translate`

Translates audio into into English.

```fsharp
let result =
    client
    |> audio
    |> translate
      { File = "sample-audio.mp3"
        Model = "whisper-1" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
      endPoint (url "")
      apiKey "apiKey"
      audio
      translate
          { File = "sample-audio.mp3"
            Model = "whisper-1" }
    }
```

<br />

### `Files` Resource

Files are used to upload documents that can be used with features like Fine-tuning.

#### `list`

Returns a list of files that belong to the user's organization.

```fsharp
let result = client |> files |> list
```

Or using a computation expression builder:

```fsharp
let result =
     openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         list
     }
```

#### `upload`

Upload a file that contains document(s) to be used across various endpoints/features.

```fsharp
let result =
    client
    |> files
    |> upload
        { File = @"sample-json.txt"
          Purpose = "fine-tune" }
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        files
        upload
             { File = @"sample-json.txt"
               Purpose = "fine-tune" }
    }
```

#### `delete`

Delete a file.

```fsharp
let result =
    client
    |> files
    |> delete "file-qtUwySute1Zf2yT6mWIGTCwq"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         delete "file-qtUwySute1Zf2yT6mWIGTCwq"
    }
```

#### `retrieve`

Returns information about a specific file.

```fsharp
let result = client |> files |> retrieve "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         retrieve "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
    }
```

#### `download`

Returns the contents of the specified file.

```fsharp
let result = client |> files |> download "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         download "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
    }
```

<br />

### `FineTunes` Resource

Manage fine-tuning jobs to tailor a model to your specific training data.

#### `create`

Creates a job that fine-tunes a specified model from a given dataset.

```fsharp
let result =
    client
    |> fineTunes
    |> create { CreateRequest.Default with TrainingFile = "file-Lpe0n5tOHtoG6OVVbk5d4iXA" }
```

Or using a computation expression builder:

```fsharp
let result = 
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        fineTunes
        create { CreateRequest.Default with TrainingFile = "file-Lpe0n5tOHtoG6OVVbk5d4iXA" }
    }
```

#### `list`

List your organization's fine-tuning jobs.

```fsharp
let result = client |> fineTunes |> list
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        fineTunes
        list
    }
```

#### `retrieve`

Gets info about the fine-tune job.

```fsharp
let result = client |> fineTunes |> retrieve "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        retrieve
        retrieve "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
    }
```

#### `cancel`

Immediately cancel a fine-tune job.

```fsharp
let result = client |> fineTunes |> cancel "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
```

Or using a computation expression builder:

```fsharp
let result =
 openAI {
     endPoint "https://api.openai.com/v1"
     apiKey "your-api-key"
     fineTunes
     cancel "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
 }
```

#### `list events`

Get fine-grained status updates for a fine-tune job.

```fsharp
let result = client |> fineTunes |> listEvents "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
```

Or using a computation expression builder:

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        fineTunes
        listEvents "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
    }
```

<br />

### `Moderations` Resource

Given a input text, outputs if the model classifies it as violating OpenAI's content policy.

#### `create`

Classifies if text violates OpenAI's Content Policy.

```fsharp
let result =
 client
 |> moderations
 |> create
     { Model = "text-moderation-latest"
       Input = "I want to kill them." }
```

Or using a computation expression builder:

```fsharp
let result =
 openAI {
     endPoint "https://api.openai.com/v1"
     apiKey "your-api-key"
     moderations
     create
         { Model = "text-moderation-latest"
           Input = "I want to kill them." }
 }
```

## Credits
This library was inspired from [openai-php](https://github.com/openai-php/client) and [FsHttp](https://github.com/fsprojects/FsHttp).
