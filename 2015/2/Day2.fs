module Day2

open System.Text.RegularExpressions

let parse (input: array<string>) =
    input
    |> Seq.map (fun row ->
        let m = Regex.Match(row, @"(\d+)x(\d+)x(\d+)")
        int m.Groups[1].Value, int m.Groups[2].Value, int m.Groups[3].Value)

let solve1 (input: array<string>) =
    input
    |> parse
    |> Seq.sumBy (fun (l, w, h) ->
        let a, b, c = l * w, w * h, h * l
        2 * (a + b + c) + min a (min b c))

let solve2 (input: array<string>) =
    input
    |> parse
    |> Seq.sumBy (fun (l, w, h) ->
        let a, b, c = l + w, w + h, h + l
        2 * min a (min b c) + l * w * h)
