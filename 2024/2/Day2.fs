module Day2

let isSafe row =
    let pairs = row |> Seq.pairwise
    let diffs = pairs |> Seq.map (fun (a, b) -> abs (a - b))
    let ascending = pairs |> Seq.forall (fun (a, b) -> a > b)
    let descending = pairs |> Seq.forall (fun (a, b) -> a < b)
    let diffReq = diffs |> Seq.forall (fun d -> d >= 1 && d <= 3)
    (ascending || descending) && diffReq

let dampener row =
    [0..Seq.length row - 1]
    |> Seq.map (fun i ->
        row |> Seq.indexed |> Seq.filter (fst >> (<>) i) |> Seq.map snd
    )

let solve1 (input: array<string>) =
    input
    |> Seq.map (fun s -> s.Split(' ') |> Seq.map int)
    |> Seq.filter isSafe
    |> Seq.length

let solve2 (input: array<string>) =
    input
    |> Seq.map (fun s -> s.Split(' ') |> Seq.map int)
    |> Seq.filter (dampener >> Seq.exists isSafe)
    |> Seq.length
