#!/usr/bin/fsharpi

open System.IO 
open System
 
type ProgramInfo(name: string, weight: int, children: string[]) = 
    member this.Name = name 
    member this.Weight = weight 
    member this.Children = children 
 
let parseLine (line: string) = 
    let chunks = line.Split([| ", "; " " |], StringSplitOptions.RemoveEmptyEntries) 
    let name = chunks.[0] 
    let weight = int(chunks.[1].Substring(1, chunks.[1].Length - 2)) 
    if chunks.Length > 2 then ProgramInfo(name, weight, chunks |> Array.skip 3)
    else ProgramInfo(name, weight, [||]) 
 
let lines = File.ReadAllLines "input.txt" 
let programs = lines |> Seq.map parseLine
let children = programs |> Seq.collect(fun e -> e.Children) |> Set.ofSeq
let names = programs |> Seq.map(fun e -> e.Name) |> Set.ofSeq
let result = names - children
printfn "%s" (Set.toArray result).[0]