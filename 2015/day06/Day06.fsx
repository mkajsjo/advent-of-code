open System.Text.RegularExpressions

let instructions1 str =
    match str with
    | "turn off" -> fun _ -> 0
    | "turn on" -> fun _ -> 1
    | _ -> fun x -> (x + 1) % 2

let instructions2 str =
    match str with
    | "turn off" -> fun x -> max (x - 1) 0
    | "turn on" -> fun x -> x + 1
    | _ -> fun x -> x + 2

let applyInstructions instructionSet (grid: int[,]) (instruction, (x1, y1), (x2, y2)) =
    grid[x1..x2, y1..y2] <- grid[x1..x2, y1..y2] |> Array2D.map (instructionSet instruction)
    grid

let parseLine line =
    let m =
        Regex.Match(line, @"(turn off|turn on|toggle) (\d+),(\d+) through (\d+),(\d+)")

    let f (n: int) = m.Groups[n].Value |> int
    let instruction = m.Groups[1].Value
    instruction, (f 2, f 3), (f 4, f 5)

let newGrid () = Array2D.create 1000 1000 0

let input = System.IO.File.ReadLines("day06/input.txt") |> Seq.map parseLine

let solve instructionSet =
    input
    |> Seq.fold (applyInstructions instructionSet) (newGrid ())
    |> Seq.cast<int>
    |> Seq.sum
    |> printfn "%d"

solve instructions1
solve instructions2
