module Day9

open System.Text.RegularExpressions

let rec findPath sorter travelRoutes unvisited distance currentLoc =
    let next (loc, dist) =
        findPath sorter travelRoutes (Set.remove loc unvisited) (distance + dist) loc

    match Set.isEmpty unvisited with
    | true -> Some distance
    | false ->
        Map.find currentLoc travelRoutes
        |> Seq.filter (fun (l, _) -> Set.contains l unvisited)
        |> sorter snd
        |> Seq.map next
        |> Seq.tryFind Option.isSome
        |> Option.flatten

let parse (input: array<string>) =
    input
    |> Seq.collect (fun row ->
        let m = Regex.Match(row, "(\w+) to (\w+) = (\d+)")
        let f (n: int) = m.Groups[n].Value
        [ f 1, (f 2, f 3 |> int); f 2, (f 1, f 3 |> int) ])
    |> Seq.groupBy fst
    |> Seq.map (fun (from, locs) -> from, locs |> Seq.map snd)
    |> Map.ofSeq

let solve1 (input: array<string>) =
    let travelRoutes = parse input

    let unvisited start =
        (travelRoutes.Keys |> Set.ofSeq |> Set.remove start)

    travelRoutes.Keys
    |> Seq.choose (fun start -> findPath Seq.sortBy travelRoutes (unvisited start) 0 start)
    |> Seq.min

let solve2 (input: array<string>) =
    let travelRoutes = parse input

    let unvisited start =
        (travelRoutes.Keys |> Set.ofSeq |> Set.remove start)

    travelRoutes.Keys
    |> Seq.choose (fun start -> findPath Seq.sortByDescending travelRoutes (unvisited start) 0 start)
    |> Seq.max
