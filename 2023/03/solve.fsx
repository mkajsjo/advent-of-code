#r "../../lib/bin/lib.dll"
open Lib
open System
open FSharp.Collections

let getIndexedNrs (lines: #seq<string>): seq<(int * int * int) * int> =
    let parseNrWithIndex (y, line) =
        System.Text.RegularExpressions.Regex.Matches(line, @"\d+")
        |> Seq.map (fun m -> (m.Index, m.Index + m.Value.Length - 1, y), int m.Value)

    lines |> Seq.indexed |> Seq.collect parseNrWithIndex

let indexed (lines: #seq<#seq<'t>>): seq<(int * int) * 't> =
    lines |> Seq.indexed |> Seq.collect (fun (y, line) -> line |> Seq.indexed |> Seq.map (fun (x, n) -> (x, y), n))

let isSymbol (c: char) = not (c = '.' || Char.IsDigit c)

let isAdjacent (ax, ax2, ay) (bx, by) = abs (by - ay) <= 1 && bx >= ax - 1 && bx <= ax2 + 1

let getCoords (filter: char -> bool) (lines: #seq<#seq<char>>): seq<int * int> =
    lines |> indexed |> Seq.filter (snd >> filter) |> Seq.map fst

solve "03" (fun input ->
    let coords = getCoords isSymbol input
    input |> getIndexedNrs |> Seq.filter (fun (i, _) -> coords |> Seq.exists (isAdjacent i)) |> Seq.sumBy snd
)

solve "03" (fun input ->
    let coords = getCoords ((=) '*') input
    let groupByCoord =
        Seq.groupBy (fun (i, _) -> coords |> Seq.tryFind (isAdjacent i))
        >> Seq.map (snd >> Seq.map snd)

    input |> getIndexedNrs |> groupByCoord |> Seq.filter (Seq.length >> (=) 2) |> Seq.sumBy (Seq.reduce (*))
)
