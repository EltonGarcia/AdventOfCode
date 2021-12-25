open System.IO

let parseEntry (input: string) : string * int =
    input.Split ' ' |> (fun o -> (o.[0], o.[1] |> int))

let commands = File.ReadAllLines "input.txt" |> Array.map parseEntry |> Array.toList


let applyCommand (command, distance, depth) =
    match command with
    | "up", v -> distance, depth - v
    | "down", v -> distance, depth + v
    | "forward", v -> distance + v, depth
    | _, _ -> 0,0


let rec calculate (list: List<string * int>, distance: int, depth: int) =
    match list with
    | x::xs -> applyCommand (x, distance, depth) |> (fun (h,d) -> calculate(xs, h, d)) 
    | [] -> (distance, depth)


let horizotal, depth = calculate (commands, 0, 0)
let part1 = horizotal * depth

let applyCommand2 (command, aim, distance, depth) =
    match command with
    | "up", v -> aim - v, distance, depth
    | "down", v -> aim + v, distance, depth
    | "forward", v -> aim, distance + v, depth + (aim * v)
    | _, _ -> 0,0,0


let rec calculate2 (list: List<string * int>, aim: int, distance: int, depth: int) =
    match list with
    | x::xs -> applyCommand2 (x, aim, distance, depth) |> (fun (a,h,d) -> calculate2(xs, a, h, d)) 
    | [] -> (aim, distance, depth)


let aim, horizotal2, depth2 = calculate2 (commands, 0, 0, 0)
let part2 = horizotal2 * depth2