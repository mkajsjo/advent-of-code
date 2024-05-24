open System

let input = System.IO.File.ReadAllText("01/input.txt")

let lines (s: string) =
    s.Split("\n") |> Seq.filter ((<>) "")

let getNr (line: string) =
    let first = line |> Seq.find Char.IsDigit
    let last = line |> Seq.findBack Char.IsDigit
    int $"{first}{last}"

let rec txtToDigit charList =
    match charList with
    | [] -> []
    | _ ->
        match charList with
        | 'z' :: 'e' :: 'r' :: 'o' :: _ -> '0'
        | 'o' :: 'n' :: 'e' :: _ -> '1'
        | 't' :: 'w' :: 'o' :: _ -> '2'
        | 't' :: 'h' :: 'r' :: 'e' :: 'e' :: _ -> '3'
        | 'f' :: 'o' :: 'u' :: 'r' :: _ -> '4'
        | 'f' :: 'i' :: 'v' :: 'e' :: _ -> '5'
        | 's' :: 'i' :: 'x' :: _ -> '6'
        | 's' :: 'e' :: 'v' :: 'e' :: 'n' :: _ -> '7'
        | 'e' :: 'i' :: 'g' :: 'h' :: 't' :: _ -> '8'
        | 'n' :: 'i' :: 'n' :: 'e' :: _ -> '9'
        | c :: _ -> c
        | [] -> failwith "cannot happen"
        :: txtToDigit (List.tail charList)

input
|> lines
|> Seq.sumBy getNr
|> printfn "%A"

input
|> lines
|> Seq.sumBy (List.ofSeq >> txtToDigit >> List.toArray >> System.String >> getNr)
|> printfn "%A"
