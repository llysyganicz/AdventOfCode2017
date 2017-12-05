#!/usr/bin/fsharpi

open System.IO

let doInstructions (instructions: int[]) =
    let length = instructions.Length
    let rec jump (index, steps) =
        let jumpLength = instructions.[index]
        let newIndex = index + jumpLength
        if jumpLength < 3 then instructions.[index] <- jumpLength + 1
        else instructions.[index] <- jumpLength - 1
        if newIndex > length - 1 || newIndex < 0 then steps + 1
        else jump(newIndex, steps + 1)

    jump(0, 0)

let instructions = File.ReadLines "input.txt" |> Seq.map(fun e -> int(e)) |> Seq.toArray
let result = doInstructions instructions
printfn "%d" result