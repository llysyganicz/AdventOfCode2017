#!/usr/bin/fsharpi

open System.IO

let getNumbers (line: string) =
    line.Split([| '\t' |]) |> Seq.map (fun e -> int(e)) |> Seq.toList

let rec getRowSum (row: list<int>) =
    let len = row.Length
    let mutable sum = 0
    for i = 0 to len - 1 do
        for j = 0 to len - 1 do
            if i <> j && row.[i] % row.[j] = 0 then sum <- sum + row.[i] / row.[j]
    sum

let lines = File.ReadLines("input.txt")
let rows = lines |> Seq.map getNumbers
let result = Seq.sumBy getRowSum rows
printfn "%d" result