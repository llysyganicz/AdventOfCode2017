#!/usr/bin/fsharpi

open System.IO

let calculateChecksum (lines: string seq) =
    let getDifferemce (line: string) =
        let numbers = line.Split([| '\t' |]) |> Seq.map (fun e -> int(e))
        let min = numbers |> Seq.min
        let max = numbers |> Seq.max
        max - min

    lines |> Seq.sumBy getDifferemce

let result = calculateChecksum(File.ReadLines "input.txt")
printfn "%d" result