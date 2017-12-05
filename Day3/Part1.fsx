#!/usr/bin/fsharpi

open System
open System.Drawing

let getSqrCoordinates (a: int) =
    if a % 2 = 0 then
        let c = a / 2
        Point(-c + 1, c)
    else
        let c = int(Math.Floor(float(a) / 2.0))
        Point(c, c)

let getInputCoordinates (sqrCoord: Point) sqrBase input =
    let diff = int(sqrBase**2.0) - input
    let diffX = int(sqrBase) - diff
    match (diffX, int(sqrBase)) with
    | (d, s) when d < 0 && s % 2 = 0 ->
        Point(sqrCoord.X + s - 1, sqrCoord.Y + d - 1)
    | (d, s) when d > 0 && s % 2 = 0 ->
        Point(sqrCoord.X + diff, sqrCoord.Y)
    | (d, s) when d = 0 && s % 2 = 0 ->
        Point(sqrCoord.X + s - 1, sqrCoord.Y)
    | (d, s) when d < 0 && s % 2 = 1 ->
        Point(sqrCoord.X - s + 1, -sqrCoord.Y - d + 1)
    | (d, s) when d > 0 && s % 2 = 1 ->
        Point(sqrCoord.X - diff, -sqrCoord.Y)
    | (d, s) when d = 0 && s % 2 = 1 ->
        Point(sqrCoord.X - s + 1, -sqrCoord.Y)
    | _ -> Point(0, 0)
    
let getDistance (point: Point) =
    Math.Abs(point.X) + Math.Abs(point.Y)

let input = 361527
let inputSqrt = sqrt (float(input))
let sqrBase = Math.Ceiling(inputSqrt)
let sqrCoordinates = getSqrCoordinates (int(sqrBase))
let inputCoordinates = getInputCoordinates sqrCoordinates sqrBase input
let result = int(getDistance inputCoordinates)
printfn "%d" result