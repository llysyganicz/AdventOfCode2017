#!/usr/bin/fsharpi

open System.IO

let text = File.ReadAllText "input.txt"
let stream = text.ToCharArray() 

let mutable score = 0
let mutable level = 0
let mutable isGarbage = false
let mutable ignoreChar = false

let processChar c =
    if isGarbage && ignoreChar then ignoreChar <- false
    else if isGarbage && c = '!' then ignoreChar <- true
    else if isGarbage && c = '>' then isGarbage <- false
    else if (not isGarbage) && c = '<' then isGarbage <- true
    else if (not isGarbage) && c = '{' then level <- level + 1
    else if (not isGarbage) && c = '}' then
        score <- score + level
        level <- level - 1

stream |> Array.iter processChar
printfn "%d" score