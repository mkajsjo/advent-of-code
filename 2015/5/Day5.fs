module Day5

open System.Text.RegularExpressions

let solve1 (input: array<string>) =
    input
    |> Seq.filter (fun row ->
        Regex.Matches(row, "[aoeui]") |> Seq.length >= 3
        && (Regex.Match(row, "(.)\1")).Success
        && not (Regex.Match(row, "ab|cd|pq|xy")).Success)
    |> Seq.length

let solve2 (input: array<string>) =
    input
    |> Seq.filter (fun row -> (Regex.Match(row, "(.{2}).*\1")).Success && (Regex.Match(row, "(.).\1")).Success)
    |> Seq.length
