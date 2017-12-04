#!/usr/bin/fsharpi

open System.IO

let lines = File.ReadLines "input.txt"
let splittedLines = lines |> Seq.map (fun line -> line.Split [| ' ' |])
let filteredLines = splittedLines |> Seq.filter(fun e -> (Seq.length (Seq.distinct e) = (Seq.length e)))
printfn "%d" (Seq.length filteredLines)