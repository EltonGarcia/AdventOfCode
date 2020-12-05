open System.IO

let boardingPasses = File.ReadAllLines "05-binary-boarding.txt" |> Array.toList

let toInt (binary: string) letter =
    let size = binary.Length
    let bits = binary 
               |> Seq.indexed 
               |> Seq.filter (fun (_, o) -> o = letter)
    match bits with
    | v when Seq.isEmpty v -> 0
    | v -> v 
        |> Seq.map (fun (i, _) -> (float(2) ** float(size - i - 1)) |> int) 
        |> Seq.reduce (+)

let column id =
    toInt id 'B'

let row id =
    toInt id 'R'

let seatId (column, row) =
    (column * 8) + row

let part1 = 
    boardingPasses
    |> List.map (fun item -> (column (item.Substring(0, 7)), row (item.Substring(7))) |> seatId)
    |> List.max

let part2 = 
    let rec searchSeat list number =
        match list with
        | x::xs -> if x <> number then Some number else searchSeat xs (number + 1)
        | [] -> None
    let sorted = boardingPasses
                 |> List.map (fun item -> (column (item.Substring(0, 7)), row (item.Substring(7))) |> seatId)
                 |> List.sort
    searchSeat sorted sorted.Head