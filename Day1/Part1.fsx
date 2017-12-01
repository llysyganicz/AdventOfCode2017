#!/usr/bin/fsharpi
open System
open System.IO

let calculateSum (input: int list) =
    let firstElement = List.head input
    let rec calculateSumIter ((list, numbersToAdd): list<int>*list<int>) =
        match list with
        | [x] -> if x = firstElement then (numbersToAdd @ [x]) else numbersToAdd
        | x1::x2::t when x1 = x2 -> calculateSumIter (([x2] @ t), (numbersToAdd @ [x1]))
        | x1::x2::t when x1 <> x2 -> calculateSumIter (([x2] @ t), (numbersToAdd))
        | _ -> numbersToAdd
    
    let result = calculateSumIter (input, [])
    result |> List.sum


let inputData = File.ReadAllLines "input.txt"
let numbers = inputData.[0] |> Seq.map (fun c -> int c - int '0') |> Seq.toList
let result = calculateSum numbers
printfn "%d" result