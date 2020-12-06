open System.IO

let declarations = (File.ReadAllText "06-custom-customs.txt").Split("\n\n") 

let part1 = 
    declarations
        |> Array.map (fun lines -> 
            lines.Split('\n') 
            |> Array.collect (fun o -> o.ToCharArray()) 
            |> Array.distinct
            |> Array.length)
        |> Array.reduce (+)

let part2 = 
    declarations
        |> Array.map (fun lines -> 
            lines.Split('\n') 
            |> (fun group -> (group.Length, group |> Array.collect (fun pass -> pass.ToCharArray())))
            |> (fun (size, answers) -> (size, answers |> Array.groupBy id |> Array.map (fun (_, arr) -> arr |> Array.length)))
            |> (fun (size, answers) -> (size, answers |> Array.filter (fun o -> o = size) |> Array.length))
            |> snd
        )
        |> Array.reduce (+)