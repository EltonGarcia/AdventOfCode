open System.IO

let sonarSweeps = File.ReadAllLines "input.txt" |> Array.map int |> Array.toList

let rec increaseMeasurementsCount prev list count = 
    match list with
    | [] -> count
    | x::xs -> increaseMeasurementsCount x xs (count + (if prev < x then 1 else 0))


increaseMeasurementsCount sonarSweeps.Head sonarSweeps.Tail 0


let rec increaseMeasurementsInSlidingWindowCount a b c list count = 
    match list with
    | [] -> count
    | x::xs -> increaseMeasurementsInSlidingWindowCount b c x xs (count + (if a + b + c < b + c + x then 1 else 0))


let x::y::z::xs = sonarSweeps
increaseMeasurementsInSlidingWindowCount x y z xs 0