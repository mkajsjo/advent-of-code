module Day3

open System.Text.RegularExpressions

let mulGroups (m: Match) = int m.Groups[1].Value * int m.Groups[2].Value

let solve1 (input: array<string>) =
    input
    |> Seq.collect (fun row -> Regex.Matches (row, @"mul\((\d+),(\d+)\)"))
    |> Seq.sumBy mulGroups

let solve2 (input: array<string>) =
    let mutable enabled = true

    input
    |> Seq.collect (fun row -> Regex.Matches (row, @"mul\((\d+),(\d+)\)|(do|don't)\(\)"))
    |> Seq.sumBy (fun m ->
        match m.Groups[3].Value with
        | "do" ->
            enabled <- true
            0
        | "don't" ->
            enabled <- false
            0
        | _ ->
            match enabled with
            | true -> mulGroups m
            | false -> 0
    )


