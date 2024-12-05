
[<EntryPoint>]
let main args =
    let input = System.IO.File.ReadAllText $"{args[0]}/input.txt"

    match args[0] with
    | "1" ->
        printfn "%A" (Day1.solve1 input)
        printfn "%A" (Day1.solve2 input)
    | "2" ->
        printfn "%A" (Day2.solve1 input)
        printfn "%A" (Day2.solve2 input)
    | "3" ->
        printfn "%A" (Day3.solve1 input)
        printfn "%A" (Day3.solve2 input)
    | "4" ->
        printfn "%A" (Day4.solve1 input)
        printfn "%A" (Day4.solve2 input)
    | "5" ->
        printfn "%A" (Day5.solve1 input)
        printfn "%A" (Day5.solve2 input)
    | "6" ->
        printfn "%A" (Day6.solve1 input)
        printfn "%A" (Day6.solve2 input)
    | "7" ->
        printfn "%A" (Day7.solve1 input)
        printfn "%A" (Day7.solve2 input)
    | "8" ->
        printfn "%A" (Day8.solve1 input)
        printfn "%A" (Day8.solve2 input)
    | "9" ->
        printfn "%A" (Day9.solve1 input)
        printfn "%A" (Day9.solve2 input)
    | "10" ->
        printfn "%A" (Day10.solve1 input)
        printfn "%A" (Day10.solve2 input)
    | "11" ->
        printfn "%A" (Day11.solve1 input)
        printfn "%A" (Day11.solve2 input)
    | "12" ->
        printfn "%A" (Day12.solve1 input)
        printfn "%A" (Day12.solve2 input)
    | "13" ->
        printfn "%A" (Day13.solve1 input)
        printfn "%A" (Day13.solve2 input)
    | "14" ->
        printfn "%A" (Day14.solve1 input)
        printfn "%A" (Day14.solve2 input)
    | "15" ->
        printfn "%A" (Day15.solve1 input)
        printfn "%A" (Day15.solve2 input)
    | "16" ->
        printfn "%A" (Day16.solve1 input)
        printfn "%A" (Day16.solve2 input)
    | "17" ->
        printfn "%A" (Day17.solve1 input)
        printfn "%A" (Day17.solve2 input)
    | "18" ->
        printfn "%A" (Day18.solve1 input)
        printfn "%A" (Day18.solve2 input)
    | "19" ->
        printfn "%A" (Day19.solve1 input)
        printfn "%A" (Day19.solve2 input)
    | "20" ->
        printfn "%A" (Day20.solve1 input)
        printfn "%A" (Day20.solve2 input)
    | "21" ->
        printfn "%A" (Day21.solve1 input)
        printfn "%A" (Day21.solve2 input)
    | "22" ->
        printfn "%A" (Day22.solve1 input)
        printfn "%A" (Day22.solve2 input)
    | "23" ->
        printfn "%A" (Day23.solve1 input)
        printfn "%A" (Day23.solve2 input)
    | "24" ->
        printfn "%A" (Day24.solve1 input)
        printfn "%A" (Day24.solve2 input)
    | _ -> failwith "Invalid day"

    0
