module Day1

let solve1 (input: array<string>) =
    input
    |> Array.map (fun s -> s.Split("   ") |> Array.map int)
    |> Array.transpose
    |> Array.map Array.sort
    |> Array.transpose
    |> Array.sumBy (fun rows -> abs (rows[0] - rows[1]))

let solve2 (input: array<string>) =
    input
    |> Array.map (fun s -> s.Split("   ") |> Array.map int)
    |> Array.transpose
    |> fun columns ->
        let nrCounts = columns[1] |> Seq.countBy id |> Map.ofSeq
        columns[0] |> Array.sumBy (fun n -> n * (Map.tryFind n nrCounts |> Option.defaultValue 0))
