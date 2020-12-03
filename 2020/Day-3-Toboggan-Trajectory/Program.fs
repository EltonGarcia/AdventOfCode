open System.IO

let map = File.ReadAllLines "03-toboggan-trajectory.txt" |> Array.toList

let columns = map.[0].Length

let countTrees map right down =
    let rec traverse (map: list<string>) right down pos treesCount =
        if List.length map < down then
            treesCount
        else
            let position = pos % columns
            let tree = if map.Head.[position] = '#' then 1 else 0
            let line = map |> List.skip(down-1)
            traverse line.Tail right down (position + right) (treesCount + tree)
    traverse map right down 0 0

let part1 = countTrees map 3 1

let part2 =
    [
        countTrees map 1 1;
        part1;
        countTrees map 5 1;
        countTrees map 7 1;
        countTrees map 1 2;
    ] 
    |> List.reduce (*)