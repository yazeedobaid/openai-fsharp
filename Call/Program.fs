// For more information see https://aka.ms/fsharp-console-apps

open System.IO
open FsHttp.Dsl
open OpenAI
open OpenAI.Client
open OpenAI.Models
open OpenAI.Completions
open OpenAI.Edits
open OpenAI.Images
open OpenAI.Moderations
open OpenAI.Files
open OpenAI.FineTunes

// let client =
//     Config(
//         { Endpoint = "https://api.openai.com/v1"
//           ApiKey = "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" },
//         HttpRequester()
//     )
//
// //-------------------------------------------------------------------------------------------
//
// let result = client |> models |> list
//
// printfn "List models result"
// printfn "Id: %s" result.Object
// printfn "Choices: %A" result.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result2 = client |> models |> retrieve "text-davinci-003"
//
// printfn "Retrieve model result"
// printfn "Id: %s" result2.Id
// printfn "Choices: %A" result2.OwnedBy
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result3 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      models
//      list
//  }
//
// printfn "List models CE result"
// printfn "Id: %s" result3.Object
// printfn "Choices: %A" result3.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result4 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      models
//      retrieve "text-davinci-003"
//  }
//
// printfn "Retrieve model CE result"
// printfn "Id: %s" result4.Object
// printfn "Choices: %A" result4.OwnedBy
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result5 =
//  client
//  |> completions
//  |> Completions.create
//      { Model = "text-davinci-003"
//        Prompt = "What is the meaning of living?"
//        Temperature = 0.5
//        Stop = "." }
//
// printfn "Completions create result"
// printfn "Id: %s" result5.Id
// printfn "Choices: %A" result5.Choices
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result6 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      completions
//      create
//          { Model = "text-davinci-003"
//            Prompt = "What is the meaning of living?"
//            Temperature = 0.5
//            Stop = "." }
//  }
//
// printfn "Completions CE result"
// printfn "Id: %s" result6.Id
// printfn "Choices: %A" result6.Choices
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result7 =
//  client
//  |> edits
//  |> Edits.create {
//              Model = "text-davinci-edit-001"
//              Input = "What day of the wek is it?"
//              Instruction = "Fix the spelling mistakes" }
//
//
// printfn "Completions create result"
// printfn "Id: %s" result7.Object
// printfn "Choices: %A" result7.Choices
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result8 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      edits
//      create
//          { Model = "text-davinci-edit-001"
//            Input = "What day of the wek is it?"
//            Instruction = "Fix the spelling mistakes" }
//  }
//
// printfn "Edits CE result"
// printfn "Id: %s" result8.Object
// printfn "Choices: %A" result8.Choices
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result9 =
//  client
//  |> images
//  |> create
//      { Prompt = "A cute baby sea otter"
//        N = 2
//        Size = "1024x1024"
//        responseFormat = "url" }
//
// printfn "Images create result"
// printfn "Id: %d" result9.Created
// printfn "Choices: %A" result9.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result10 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      images
//      create
//          { Prompt = "A cute baby sea otter"
//            N = 2
//            Size = "1024x1024"
//            responseFormat = "url" }
//  }
//
// printfn "Images create CE result"
// printfn "Id: %d" result10.Created
// printfn "Choices: %A" result10.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result11 =
//  client
//  |> images
//  |> edit
//      { Image = "C:\Users\YazeedObaid\Downloads\5a384f485d0cc8.9132443915136397523811.png"
//        Mask = "C:\Users\YazeedObaid\Downloads\5a384f485d0cc8.9132443915136397523811.png"
//        Prompt = "A cute baby sea otter wearing a beret"
//        N = 2
//        Size = "1024x1024"
//        responseFormat = "url" }
//
// printfn "Images edit result"
// printfn "Id: %d" result11.Created
// printfn "Choices: %A" result11.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result12 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      images
//      edit
//          { Image = "C:\Users\YazeedObaid\Downloads\5a384f485d0cc8.9132443915136397523811.png"
//            Mask = "C:\Users\YazeedObaid\Downloads\5a384f485d0cc8.9132443915136397523811.png"
//            Prompt = "A cute baby sea otter wearing a beret"
//            N = 2
//            Size = "1024x1024"
//            responseFormat = "url" }
//  }
//
// printfn "Images edit CE result"
// printfn "Id: %d" result12.Created
// printfn "Choices: %A" result12.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result13 =
//  client
//  |> images
//  |> variation
//      { Image = "C:\Users\YazeedObaid\Downloads\5a384f485d0cc8.9132443915136397523811.png"
//        N = 2
//        Size = "1024x1024"
//        responseFormat = "url" }
//
// printfn "Images variation result"
// printfn "Id: %d" result13.Created
// printfn "Choices: %A" result13.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result14 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      images
//      variation
//          { Image = "C:\Users\YazeedObaid\Downloads\5a384f485d0cc8.9132443915136397523811.png"
//            N = 2
//            Size = "1024x1024"
//            responseFormat = "url" }
//  }
//
// printfn "Images variation CE result"
// printfn "Id: %d" result14.Created
// printfn "Choices: %A" result14.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result15 =
//  client
//  |> embeddings
//  |> create
//      { Model = "text-embedding-ada-002"
//        Input = "The food was delicious and the waiter..." }
//
// printfn "Embeddings create result"
// printfn "Id: %s" result15.Object
// printfn "Choices: %A" result15.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result16 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      embeddings
//      create
//          { Model = "text-embedding-ada-002"
//            Input = "The food was delicious and the waiter..." }
//  }
//
// printfn "Embeddings create CE result"
// printfn "Id: %s" result16.Object
// printfn "Choices: %A" result16.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result17 =
//  client
//  |> moderations
//  |> create
//      { Model = "text-moderation-latest"
//        Input = "I want to kill them." }
//
// printfn "Moderations create result"
// printfn "Id: %s" result17.Id
// printfn "Choices: %A" result17.results
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result18 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      moderations
//      create
//          { Model = "text-moderation-latest"
//            Input = "I want to kill them." }
//  }
//
// printfn "Moderations create CE result"
// printfn "Id: %s" result18.Id
// printfn "Choices: %A" result18.results
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result19 =
//  client
//   |> files
//   |> list
//
// printfn "File list result"
// printfn "Id: %s" result19.Object
// printfn "Data: %A" result19.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result20 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      files
//      list
//  }
//
// printfn "File list CE result"
// printfn "Id: %s" result20.Object
// printfn "Data: %A" result20.Data
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result21 =
//  client
//   |> files
//   |> upload
//       { File = @"C:\Code\ExternalLibraries\openai-fsharp\Tests\bin\Debug\net7.0\Fixtures\sample-json.txt"
//         Purpose = "fine-tune" }
//
// printfn "File upload result"
// printfn "Id: %s" result21.Id
// printfn "FileName: %A" result21.FileName
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result22 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      files
//      upload
//          { File = @"C:\Code\ExternalLibraries\openai-fsharp\Tests\bin\Debug\net7.0\Fixtures\sample-json.txt"
//            Purpose = "fine-tune" }
//  }
//
// printfn "File upload CE result"
// printfn "Id: %s" result22.Id
// printfn "FileName: %A" result22.FileName
// printfn "------------------------------"
//
// // -------------------------------------------------------------------------------------------
//
// let result23 =
//  client
//   |> files
//   |> delete "file-qtUwySute1Zf2yT6mWIGTCwq"
//
// printfn "File delete result"
// printfn "Id: %s" result23.Id
// printfn "Deleted: %A" result23.Deleted
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result24 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      files
//      delete "file-qtUwySute1Zf2yT6mWIGTCwq"
//  }
//
// printfn "File delete CE result"
// printfn "Id: %s" result24.Id
// printfn "Deleted: %A" result24.Deleted
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result25 = client |> files |> retrieve "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
//
// printfn "File retrieve result"
// printfn "Id: %s" result25.Id
// printfn "FileName: %A" result25.FileName
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result26 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      files
//      retrieve "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
//  }
//
// printfn "File retrieve CE result"
// printfn "Id: %s" result26.Id
// printfn "FileName: %A" result26.FileName
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result27 = client |> files |> download "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
//
// printfn "File download result"
// printfn "File: %s" result27
// printfn "------------------------------"
//
// //-------------------------------------------------------------------------------------------
//
// let result28 =
//  openAI {
//      endPoint "https://api.openai.com/v1"
//      apiKey "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"
//      files
//      download "file-Lpe0n5tOHtoG6OVVbk5d4iXA"
//  }
//
// printfn "File download CE result"
// printfn "File: %s" result28
// printfn "------------------------------"