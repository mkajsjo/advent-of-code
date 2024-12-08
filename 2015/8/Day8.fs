module Day8

open System.Text.RegularExpressions

let solve1 (input: array<string>) =
    input
    |> Seq.sumBy (fun row ->
        row.Length - (Regex.Replace(row, @"\\\\|\\""|\\x[0-9a-fA-F]{2}", ".")).Length
        + 2)

let solve2 (input: array<string>) =
    input
    |> Seq.sumBy (fun row -> (Regex.Replace(row, @"\\|""", "\\$0")).Length - row.Length + 2)
