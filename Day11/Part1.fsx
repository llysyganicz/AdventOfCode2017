#!/usr/bin/fsharpi

open System
open System.IO

let reduceDirections a b =
    if a > b then (a - b, 0)
    else (0, b - a)

let reduceDirections2 a b c =
    let m = min a b
    if m % 2 = 0 then (a - m / 2, 0, c + m / 2)
    else (a - m / 2, 1, c + m / 2)

let countDirections directions =
    let mutable nw = directions |> List.filter(fun e -> e = "nw") |> List.length
    let mutable n = directions |> List.filter(fun e -> e = "n") |> List.length
    let mutable ne = directions |> List.filter(fun e -> e = "ne") |> List.length
    let mutable sw = directions |> List.filter(fun e -> e = "sw") |> List.length
    let mutable s = directions |> List.filter(fun e -> e = "s") |> List.length
    let mutable se = directions |> List.filter(fun e -> e = "se") |> List.length

    //transform pairs of nw and ne to n
    let a = min nw ne
    nw <- nw - a
    ne <- ne - a
    n <- n + a

    //transform pairs of sw and se to s
    let a = min sw se
    sw <- sw - a
    se <- se - a
    s <- s + a

    //reduce oposite directions
    let x, y = reduceDirections n s
    n <- x
    s <- y

    let x, y = reduceDirections ne sw
    ne <- x
    sw <- y

    let x, y = reduceDirections nw se
    nw <- x
    se <- y

    //final reduction
    if nw <> 0 && s <> 0 then
        let x, y, z = reduceDirections2 nw s sw
        nw <- x
        s <- y
        sw <- z

    if ne <> 0 && s <> 0 then
        let x, y, z = reduceDirections2 ne s se
        ne <- x
        s <- y
        se <- z

    if sw <> 0 && n <> 0 then
        let x, y, z = reduceDirections2 sw n nw
        sw <- x
        n <- y
        nw <- z

    if se <> 0 && n <> 0 then
        let x, y, z = reduceDirections2 se n ne
        se <- x
        n <- y
        ne <- z

    printfn "nw: %d n: %d ne: %d sw: %d s: %d se: %d" nw n ne sw s se
    nw + n + ne + sw + s + se

// let directions = [ "se"; "sw"; "se"; "sw"; "sw" ]
let directions = (File.ReadAllText "input.txt").Split [| ',' |] |> Array.toList
let result = countDirections directions
printfn "%d" result