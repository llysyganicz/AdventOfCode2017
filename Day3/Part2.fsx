#!/usr/bin/fsharpi

open System

type Direction = | Up | Right | Down | Left

let input = 361527
let n = 10

let calculateValue(x, y, arr: int[,]) =
    if x = n / 2 && y = n / 2 then arr.[x, y] <- 1
    for i = -1 to 1 do
        for j = -1 to 1 do
            let ix = x + i
            let iy = y + j
            let currentCell = (i = 0 && j = 0)
            let lowerOut = (ix < 0 || iy < 0)
            let upperOut = (ix >= n || iy >= n)
            if not currentCell && not lowerOut && not upperOut then
                arr.[x, y] <- arr.[x, y] + arr.[ix, iy]
                
let changeDirection currentDirection =
    match currentDirection with
    | Up -> Left    
    | Right -> Up
    | Down -> Right
    | Left -> Down

let spiral = Array2D.zeroCreate<int> n n
let mutable x = n / 2
let mutable y = x
let mutable currentDirection = Down
let mutable segmentSize = 1
let mutable segmentSteps = 0
let mutable rotationsCount = 0
let mutable result = 0

while result <= input do
    calculateValue(x, y, spiral)
    result <- spiral.[x, y]
    match currentDirection with
    | Up -> y <- y - 1
    | Right -> x <- x + 1
    | Down -> y <- y + 1
    | Left -> x <- x - 1
    
    segmentSteps <- segmentSteps + 1
    if segmentSteps = segmentSize then
        segmentSteps <- 0
        currentDirection <- changeDirection currentDirection
        if currentDirection = Up || currentDirection = Down then
            segmentSize <- segmentSize + 1
            
printfn "%d" result            