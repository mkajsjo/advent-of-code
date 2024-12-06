module Day2

let isSafe row =
    let pairs = row |> Seq.pairwise
    let all pred = pairs |> Seq.forall (fun (a, b) -> pred a b)

    (all (>) || all (<)) &&
    all (fun a b ->
        let diff = abs (a - b)
        diff >= 1 && diff <= 3
    )

let dampener row =
    [0..Seq.length row - 1]
    |> Seq.map (fun i ->
        row |> Seq.indexed |> Seq.filter (fst >> (<>) i) |> Seq.map snd
    )

let countReports predicate (input: array<string>) =
    input
    |> Seq.map (fun s -> s.Split(' ') |> Seq.map int)
    |> Seq.filter predicate
    |> Seq.length

let solve1 = countReports isSafe
let solve2 = countReports (dampener >> Seq.exists isSafe)
