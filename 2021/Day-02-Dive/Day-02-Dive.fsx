open System.IO

let parseEntry (input: string) : string * int =
    input.Split ' ' |> (fun o -> (o.[0], o.[1] |> int))

let commands = File.ReadAllLines "input.txt" |> Array.map parseEntry |> Array.toList


let applyCommand (distance, depth) command =
    match command with
    | "up", v -> distance, depth - v
    | "down", v -> distance, depth + v
    | "forward", v -> distance + v, depth
    | _, _ -> 0,0

let part1 = List.fold applyCommand (0, 0) commands ||> (*)


let applyCommand2 (distance, depth, aim) command =
    match command with
    | "up", v -> distance, depth, aim - v
    | "down", v -> distance, depth, aim + v
    | "forward", v -> distance + v, depth + (aim * v), aim
    | _, _ -> 0,0,0

let part2 = List.fold applyCommand2 (0, 0, 0) commands 
            |> fun (h, d, _) -> (h,d) 
            ||> (*)