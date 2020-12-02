open System
open System.IO

type Policy = {
    Value1: int
    Value2: int
    Char: char
}

let parse (data: string[]) : Policy * string =
    let maxAndMin = data.[0].Split('-') |> Array.map int
    let char = data.[1].Replace(":", "").ToCharArray().[0]
    let password = data.[2]
    ({ Value1=maxAndMin.[0]; Value2=maxAndMin.[1];Char=char; }, password)

let passwords = File.ReadAllLines "02-password-philosophy.txt" 
                |> Array.map ((fun o -> o.Split(' ')) >> parse)


let rule1 (policy, password: string) =
    let amount = password.ToCharArray() |> Array.filter (fun o -> o = policy.Char) |> Array.length
    amount >= policy.Value1 && amount <= policy.Value2

let rule2 (policy, password: string) =
    let chars = password.ToCharArray()
    let position1 = chars.[policy.Value1 - 1] = policy.Char
    let position2 = chars.[policy.Value2 - 1] = policy.Char
    position1 <> position2

let validate rule items = 
    items
    |> Array.filter rule
    |> Array.length

let part1 = 
    passwords
        |> validate rule1
        |> printfn "Number of valid passwords with rule 1 is: %d"

let part2 =
    passwords
        |> validate rule2
        |> printfn "Number of valid passwords with rule 2 is: %d"
