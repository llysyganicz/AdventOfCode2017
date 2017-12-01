#!/usr/bin/fsharpi
open System.IO

let calculateSum (input: int list) =
    let inputLength = List.length input
    let step = inputLength / 2
    let getElement i =
        let index = (i + step) % inputLength
        input.[index]
    let rec calculateSumIter ((list, numbersToAdd, index): list<int>*list<int>*int) =
        match list with
        | x::t ->
            if x = (getElement index) then calculateSumIter (t, numbersToAdd @ [x], index + 1)
            else calculateSumIter (t, numbersToAdd, index + 1)
        | _ -> numbersToAdd
    
    let result = calculateSumIter (input, [], 0)
    result |> List.sum


let inputData = File.ReadAllLines "input.txt"
let numbers = inputData.[0] |> Seq.map (fun c -> int c - int '0') |> Seq.toList
let result = calculateSum numbers
printfn "%d" result