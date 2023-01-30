module test
open Expecto

[<EntryPoint>]
let main argv =
    Tests.runTestsInAssembly { defaultConfig with parallelWorkers = 1 } argv
