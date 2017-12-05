#!/usr/bin/fsharpi

open System.IO

let sortLetters (word: string) =
    word.ToCharArray() |> Seq.sort |> Seq.toArray |> fun chars -> new string(chars)

let sortLettersForWords (words: string seq) =
    words |> Seq.map sortLetters

let filterLines lines = 
    lines |> Seq.filter(fun e -> (Seq.length (Seq.distinct e) = (Seq.length e)))

let lines = File.ReadLines "input.txt"
let splittedLines = lines |> Seq.map (fun line -> line.Split [| ' ' |])
let filteredLines = filterLines splittedLines
let sorted = filteredLines |> Seq.map(fun e -> e |> Seq.map sortLetters)
let result = filterLines sorted |> Seq.length

printfn "%d" result