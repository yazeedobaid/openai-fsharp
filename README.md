<p align="center">
    <img width="80%" src="https://raw.githubusercontent.com/yazeedobaid/openai-fsharp/main/art/example-snippet.png?token=GHSAT0AAAAAABQGBEGGXODFOYM7QILUN5RIY63W4ZQ" alt="OpenAI F#">
</p>

------
**OpenAI F#** is library that allows you to interact with [Open AI API](https://beta.openai.com/docs/api-reference/introduction) in an easy,
fluent, and typed way!

## Get Started

Add the library to your project using NuGet:

```bash

```

Or Paket:

```bash

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

## Usage

### `Models` Resource

List and describe the various models available in the API. You can refer to the Models documentation to understand 
what models are available and the differences between them.

#### `list`

Lists the currently available models, and provides basic information about each one such as the owner and availability.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> models |> list
```

</td>
<td>

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        list
    }
```

</td>
</tr>
</table>

#### `retrieve`

Retrieves a model instance, providing basic information about the model such as the owner and permissioning.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> models |> retrieve "text-davinci-003"
```

</td>
<td>

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        retrieve "text-davinci-003"
    }
```

</td>
</tr>
</table>

#### `delete`

Delete a fine-tuned model.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> models |> delete "curie:ft-acmeco-2021-03-03-21-44-20"
```

</td>
<td>

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        models
        delete "curie:ft-acmeco-2021-03-03-21-44-20"
    }
```

</td>
</tr>
</table>

### `Completions` Resource

Given a prompt, the model will return one or more predicted completions, and can also return the probabilities 
of alternative tokens at each position.

#### `create`

Creates a completion for the provided prompt and parameters.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

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

</td>
<td>

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

</td>
</tr>
</table>

### `Edits` Resource

Given a prompt and an instruction, the model will return an edited version of the prompt.

#### `create`

Creates a new edit for the provided input, instruction, and parameters.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result =
    client
    |> edits
    |> Edits.create
           { Model = "text-davinci-edit-001"
             Input = "What day of the wek is it?"
             Instruction = "Fix the spelling mistakes" }
```

</td>
<td>

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

</td>
</tr>
</table>

### `Images` Resource

Given a prompt and/or an input image, the model will generate a new image.

#### `create`

Creates an image given a prompt.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

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

</td>
<td>

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

</td>
</tr>
</table>

#### `edit`

Creates an edited or extended image given an original image and a prompt.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

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

</td>
<td>

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

</td>
</tr>
</table>

#### `variation`

Creates a variation of a given image.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

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

</td>
<td>

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

</td>
</tr>
</table>

### `Embeddings` Resource

Get a vector representation of a given input that can be easily consumed by machine learning models and algorithms.

#### `create`

Creates an embedding vector representing the input text.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result =
    client
    |> embeddings
    |> create
        { Model = "text-embedding-ada-002"
          Input = "The food was delicious and the waiter..." }
```

</td>
<td>

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

</td>
</tr>
</table>

### `Files` Resource

Files are used to upload documents that can be used with features like Fine-tuning.

#### `list`

Returns a list of files that belong to the user's organization.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> files |> list
```

</td>
<td>

```fsharp
let result =
     openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         list
     }
```

</td>
</tr>
</table>

#### `upload`

Upload a file that contains document(s) to be used across various endpoints/features.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result =
    client
    |> files
    |> upload
        { File = @"sample-json.txt"
          Purpose = "fine-tune" }
```

</td>
<td>

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

</td>
</tr>
</table>

#### `delete`

Delete a file.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result =
    client
    |> files
    |> delete "file-qtUwySute1Zf2yT6mWIGTCwq"
```

</td>
<td>

```fsharp
let result =
    openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         delete "file-qtUwySute1Zf2yT6mWIGTCwq"
    }
```

</td>
</tr>
</table>

#### `retrieve`

Returns information about a specific file.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> files |> retrieve "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
```

</td>
<td>

```fsharp
let result =
    openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         retrieve "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
    }
```

</td>
</tr>
</table>

#### `download`

Returns the contents of the specified file.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> files |> download "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
```

</td>
<td>

```fsharp
let result =
    openAI {
         endPoint "https://api.openai.com/v1"
         apiKey "your-api-key"
         files
         download "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
    }
```

</td>
</tr>
</table>

### `FineTunes` Resource

Manage fine-tuning jobs to tailor a model to your specific training data.

#### `create`

Creates a job that fine-tunes a specified model from a given dataset.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result =
    client
    |> fineTunes
    |> create { CreateRequest.Default with TrainingFile = "file-Lpe0n5tOHtoG6OVVbk5d4iXA" }
```

</td>
<td>

```fsharp
let result = 
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        fineTunes
        create { CreateRequest.Default with TrainingFile = "file-Lpe0n5tOHtoG6OVVbk5d4iXA" }
    }
```

</td>
</tr>
</table>

#### `list`

List your organization's fine-tuning jobs.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> fineTunes |> list
```

</td>
<td>

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        fineTunes
        list
    }
```

</td>
</tr>
</table>

#### `retrieve`

Gets info about the fine-tune job.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> fineTunes |> retrieve "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
```

</td>
<td>

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        retrieve
        retrieve "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
    }
```

</td>
</tr>
</table>

#### `cancel`

Immediately cancel a fine-tune job.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> fineTunes |> cancel "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
```

</td>
<td>

```fsharp
let result =
 openAI {
     endPoint "https://api.openai.com/v1"
     apiKey "your-api-key"
     fineTunes
     cancel "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
 }
```

</td>
</tr>
</table>

#### `list events`

Get fine-grained status updates for a fine-tune job.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result = client |> fineTunes |> listEvents "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
```

</td>
<td>

```fsharp
let result =
    openAI {
        endPoint "https://api.openai.com/v1"
        apiKey "your-api-key"
        fineTunes
        listEvents "ft-kNJeZjAhlmFLdCuIzcpkrmNI"
    }
```

</td>
</tr>
</table>

### `Moderations` Resource

#### `create`

Classifies if text violates OpenAI's Content Policy.

<table>
<tr>
<td>Method Calls</td><td>CE Builder</td>
</tr>
<tr>
<td>

```fsharp
let result =
 client
 |> moderations
 |> create
     { Model = "text-moderation-latest"
       Input = "I want to kill them." }
```

</td>
<td>

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

</td>
</tr>
</table>

## Credits
This library was inspired from [openai-php](https://github.com/openai-php/client) library and [FsHttp](https://github.com/fsprojects/FsHttp)
