#!/usr/bin/fsharpi

open System.IO

let rec reverse(numbers: int[], lengths: int list, startIndex: int, skipSize: int) =
    match lengths with
    | x::t ->
        for i = 0 to (x  - 1) / 2 do
            let j = (startIndex + i) % numbers.Length
            let k = (startIndex + x - 1 - i) % numbers.Length
            let t = numbers.[j]
            numbers.[j] <- numbers.[k]
            numbers.[k] <- t
        reverse(numbers, t, (startIndex + x + skipSize) % numbers.Length, skipSize + 1)
    | _ -> numbers

let input = File.ReadAllText "input.txt"
let lengths = input.Split[| ',' |] |> Array.map(fun e -> int(e)) |> Array.toList
let numbers = [| 0..255 |]

let reversed = reverse(numbers, lengths, 0, 0)
let result = reversed.[0] * reversed.[1]
printfn "%d" result