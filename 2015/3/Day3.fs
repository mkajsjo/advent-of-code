module Day3

let move (input: string) =
    input
    |> Seq.scan
        (fun (x, y) dir ->
            match dir with
            | '^' -> (x, y - 1)
            | 'v' -> (x, y + 1)
            | '>' -> (x + 1, y)
            | '<' -> (x - 1, y)
            | _ -> failwith "err")
        (0, 0)

let solve1 (input: array<string>) =
    input |> Seq.head |> move |> Seq.distinct |> Seq.length

let solve2 (input: array<string>) =
    let moves1, moves2 =
        input
        |> Seq.head
        |> Seq.indexed
        |> List.ofSeq
        |> List.partition (fun (i, _) -> i % 2 = 0)

    moves1
    |> Seq.map snd
    |> System.String.Concat
    |> move
    |> Seq.append (moves2 |> Seq.map snd |> System.String.Concat |> move)
    |> Seq.distinct
    |> Seq.length
