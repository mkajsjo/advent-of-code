#r "../../lib/bin/lib.dll"
open Lib
open System
open FSharp.Collections

let getNumbersByAdjacent (lines: #seq<string>): Map<int * int, seq<int>> =
    lines
    |> Seq.indexed
    |> Seq.collect (fun (y, line) ->
        System.Text.RegularExpressions.Regex.Matches(line, @"\d+")
        |> Seq.collect (fun m -> Seq.allPairs [m.Index-1..m.Index + m.Value.Length] [y-1..y+1] |> Seq.map (fun i -> i, int m.Value))
    )
    |> Seq.groupBy fst
    |> Seq.map (fun (k, vs) -> k, Seq.map snd vs)
    |> Map.ofSeq

let isSymbol (c: char) = not (c = '.' || Char.IsDigit c)

let getNumbers input =
    let nrs = getNumbersByAdjacent input
    input |> indexed2d |> Seq.filter (snd >> isSymbol) |> Seq.choose (fun (i, _) -> Map.tryFind i nrs)

solve "03" (getNumbers >> Seq.sumBy Seq.sum)
solve "03" (getNumbers >> Seq.filter (Seq.length >> (=) 2) >> Seq.sumBy (Seq.reduce (*)))
