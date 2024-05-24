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
