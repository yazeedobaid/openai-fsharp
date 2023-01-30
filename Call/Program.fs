// For more information see https://aka.ms/fsharp-console-apps

open OpenAI
open OpenAI.Client
open OpenAI.Completions

let client =
    { ApiConfig =
        { Endpoint = "https://api.openai.com/v1/completions"
          ApiKey = "" }
      HttpRequester = HttpRequester() }

let result =
    client
    |> completions
    |> create
        { Model = "text-davinci-003"
          Prompt = "What is the meaning of living?"
          Temperature = 0.5
          Stop = "." }

printfn "Id: %s" result.Id
printfn "Choices: %A" result.Choices
