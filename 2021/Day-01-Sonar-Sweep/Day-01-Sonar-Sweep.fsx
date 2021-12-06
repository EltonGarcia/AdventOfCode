open System.IO

let sonarSweeps = File.ReadAllLines "input.txt" |> Array.map int |> Array.toList

let increaseMeasurementsCount list  =
    list 
        |> List.pairwise
        |> List.filter (fun (a,b) -> a < b)
        |> List.length


//Fold version
(*
let increaseMeasurementsCount list  =
    let folder (prev, count) curr = if prev < curr then (curr, count + 1) else (curr, count)
    let x::xs = list
    xs |> List.fold folder (x, 0) |> snd
*)    

increaseMeasurementsCount sonarSweeps


let windowed = 
    sonarSweeps 
    |> List.windowed 3 
    |> List.map (List.reduce (+))

increaseMeasurementsCount windowed