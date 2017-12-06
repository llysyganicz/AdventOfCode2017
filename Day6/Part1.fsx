#!/usr/bin/fsharpi

open System.IO
open System.Linq

let findLoop (banks: int[]) =
    let rec step states =
        let max = banks |> Array.max
        let maxIndex = banks |> Array.findIndex(fun e -> e = max)
        banks.[maxIndex] <- 0
        for i = 1 to max do
            let index = (maxIndex + i) % banks.Length
            banks.[index] <- banks.[index] + 1
        if states |> List.exists(fun e -> Enumerable.SequenceEqual(e, banks)) then states.Length
        else step ([(Array.toList banks)] @ states)
    
    step [(Array.toList banks)]

let banks = (File.ReadAllText "input.txt").Split [| '\t' |] |> Array.map(fun e -> int(e))
let result = findLoop banks
printfn "%d" result