open System
open System.IO
open System.Text.RegularExpressions

let requiredFields = ["byr"; "iyr"; "eyr"; "hgt"; "hcl"; "ecl"; "pid"]
let optionalField = "cid"

let input = File.ReadAllText "04-passport-processing.txt"

let parsePassport (data: array<string>) =
    data
    |> Array.map (fun item -> item.Split(':') |> (fun arr -> (arr.[0], arr.[1])))
    |> dict

let passports = input.Split("\n\n") 
                |> Array.map (fun lines -> lines.Split('\n', ' ') |> parsePassport)

let part1 = 
    let validatePassport (passport: Collections.Generic.IDictionary<string, string>) =
        requiredFields 
        |> List.map (fun field -> passport.ContainsKey(field))
        |> List.reduce (&&)
    passports 
        |> Array.filter validatePassport
        |> Array.length

let validateYear (data: string) min max =
    match System.Int32.TryParse(data) with
    | true, year -> year >= min && year <= max
    | _ -> false

let validateBYR year = validateYear year 1920 2002
let validateIYR year = validateYear year 2010 2020
let validateEYR year = validateYear year 2020 2030
let validateHGT heigth = 
    let extractInt data =
        let value = Regex.Matches(heigth, "\d+")
        if value.Count > 0 then
            Some (value.[0].Value |> int)
        else None
    
    match extractInt heigth with
    | None -> false
    | Some size -> 
        let matches = Regex.Matches(heigth, "cm|in") 
        if matches.Count > 0 then
            match matches.[0].Value with
            | "cm" -> size >= 150 && size <= 193
            | "in" -> size >= 59 && size <= 76
            | _ -> false
        else false
let validateHCL color = Regex.Match(color, "^#(?:[0-9a-f]{3}){1,2}$", RegexOptions.IgnoreCase).Success
let validateECL color = ["amb"; "blu"; "brn"; "gry"; "grn"; "hzl"; "oth"] |> List.contains color
let validatePID id = Regex.Match(id, "^\d{9}$", RegexOptions.IgnoreCase).Success

let part2 = 
    let validations = [
        ("byr", validateBYR);
        ("iyr", validateIYR);
        ("eyr", validateEYR);
        ("hgt", validateHGT);
        ("hcl", validateHCL);
        ("ecl", validateECL);
        ("pid", validatePID);
    ] 
    
    let validatePassport (passport: Collections.Generic.IDictionary<string, string>) =
        validations 
        |> List.map (fun (field, isValid) -> field = optionalField || (passport.ContainsKey field && isValid (passport.Item(field))))
        |> List.reduce (&&)
    passports 
        |> Array.filter validatePassport
        |> Array.length