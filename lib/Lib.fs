module Lib

open System
open System.Text.RegularExpressions

let getInput (n: string) =
    System.IO.File.ReadAllText($"{n}/input.txt")
    |> fun s -> s.Split("\n")
    |> Seq.filter ((<>) "")

let solve (n: string) (solver: seq<string> -> 't) = getInput n |> solver |> printfn "%A"

let parseNr input pattern =
    let m = Regex.Match(input, pattern)
    if m.Success then int m.Groups[1].Value else 0

let parseNrs (str: string): seq<int> =
    System.Text.RegularExpressions.Regex.Matches(str, @"\d+")
    |> Seq.map (fun m -> int m.Value)

let indexed2d (rows: #seq<#seq<'t>>) : seq<(int * int) * 't> =
    rows
    |> Seq.indexed
    |> Seq.collect (fun (y, row) -> row |> Seq.indexed |> Seq.map (fun (x, n) -> (x, y), n))

module List =
    let rec merge (f: 't -> 't -> 't) (aSeq: list<'t>) (bSeq: list<'t>) =
        match aSeq, bSeq with
        | x :: xs, y :: ys -> f x y :: merge f xs ys
        | xs, [] -> xs
        | [], ys -> ys
