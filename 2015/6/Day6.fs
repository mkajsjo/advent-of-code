module Day6

open System.Text.RegularExpressions

let parse (str: string) =
    let m = Regex.Match(str, @"(\w+) (\d+),(\d+) through (\d+),(\d+)")
    let f (n: int) = m.Groups[n].Value |> int
    m.Groups[1].Value, f 2, f 3, f 4, f 5

let instruction1 op n =
    match op with
    | "on" -> 1
    | "off" -> 0
    | _ -> (n + 1) % 2

let instruction2 op n =
    match op with
    | "on" -> n + 1
    | "off" -> max 0 (n - 1)
    | _ -> n + 2

let applyInstructions instructionSet (input: array<string>) =
    let grid = Array2D.zeroCreate 1000 1000

    input
    |> Seq.map parse
    |> Seq.iter (fun (op, x1, y1, x2, y2) ->
        grid[y1..y2, x1..x2] <- grid[y1..y2, x1..x2] |> Array2D.map (instructionSet op))

    grid |> Seq.cast<int> |> Seq.sum

let solve1 (input: array<string>) = applyInstructions instruction1 input
let solve2 (input: array<string>) = applyInstructions instruction2 input
