#!/usr/bin/fsharpi

open System.IO

let mutable maxValue = 0

type Register(name: string) =
    member this.Name = name
    member val Value = 0 with get,set

type Instruction(register: string, operation: string, value: int, registerToCheck: string, condition: string, conditionValue: int) =
    let checkCondition (reg: Register) =
        match condition with
        | "<" -> reg.Value < conditionValue
        | "<=" -> reg.Value <= conditionValue
        | ">" -> reg.Value > conditionValue
        | ">=" -> reg.Value >= conditionValue
        | "==" -> reg.Value = conditionValue
        | "!=" -> reg.Value <> conditionValue
        | _ -> false

    member this.Register = register
    member this.RegisterToCheck = registerToCheck
    member this.ProcessInstruction (registers: Register[]) =
        let toCheck = registers |> Array.find(fun e -> e.Name = this.RegisterToCheck)
        if (checkCondition toCheck) then
            let reg = registers |> Array.find(fun e -> e.Name = this.Register)
            match operation with
            | "inc" -> reg.Value <- reg.Value + value
            | "dec" -> reg.Value <- reg.Value - value
            | _ -> ()
            if(reg.Value > maxValue) then maxValue <- reg.Value

let parseLine (line: string) =
    let chunks = line.Split [| ' ' |]
    Instruction(chunks.[0], chunks.[1], int(chunks.[2]), chunks.[4], chunks.[5], int(chunks.[6]))

let instructions = File.ReadAllLines "./input.txt" |> Array.map parseLine
let registers = Array.append (instructions 
                |> Array.map(fun e -> e.Register)) (instructions 
                |> Array.map(fun e -> e.RegisterToCheck)) 
                |> Array.distinct |> Array.map(fun e -> Register(e))
instructions |> Array.iter(fun e -> e.ProcessInstruction registers)
printfn "%d" maxValue