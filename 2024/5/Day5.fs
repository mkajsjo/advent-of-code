module Day5

let getRulesAndUpdates (input: array<string>) =
    let rules, updates = input |> Array.splitAt 1176

    let ruleSet =
        rules
        |> Seq.map (fun s ->
            let arr = s.Split('|')
            (arr[0], arr[1])
        )
        |> Set.ofSeq

    ruleSet,
    updates
    |> Seq.tail
    |> Seq.map (fun s -> s.Split(',') |> List.ofSeq)

let sortByRules rules update =
    update |> List.sortWith (fun a b -> if Set.contains (a, b) rules then -1 else 1)

let takeMiddleElem update = (update |> Array.ofSeq)[Seq.length update / 2] |> int

let solve1 (input: array<string>) =
    let rules, updates = getRulesAndUpdates input

    updates
    |> Seq.filter (fun update -> update |> sortByRules rules |> (=) update)
    |> Seq.sumBy takeMiddleElem

let solve2 (input: array<string>) =
    let rules, updates = getRulesAndUpdates input

    updates
    |> Seq.choose (fun update ->
        let u = update |> sortByRules rules
        if u <> update then Some u else None
    )
    |> Seq.sumBy takeMiddleElem
