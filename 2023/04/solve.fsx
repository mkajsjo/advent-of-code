#r "../../lib/bin/lib.dll"
open Lib

let parseLine (line: string): Set<int> * Set<int> =
    match line.Split(':') with
    | [| _; nrs |] ->
        match nrs.Split('|') with
        | [| winningNrs; myNrs |] ->
            winningNrs |> parseNrs |> Set.ofSeq, myNrs |> parseNrs |> Set.ofSeq
        | _ -> failwith "parse error"
    | _ -> failwith "parse error"

let countWinningNrs = (<||) Set.intersect >> Set.count

let getScore (n: int) = if n > 0 then pown 2 (n-1) else 0

let rec processCards (acc: list<int>) (cards: list<Set<int> * Set<int>>) =
    let next n ns c cs = processCards (List.merge (+) (List.replicate (countWinningNrs c) (n+1)) ns) cs
    match acc, cards with
    | n :: ns, c :: cs -> (n+1) :: next n ns c cs
    | [], c :: cs -> 1 :: next 0 [] c cs
    | _ -> []

solve "04" (Seq.sumBy (parseLine >> countWinningNrs >> getScore))
solve "04" (Seq.map parseLine >> List.ofSeq >> processCards [0] >> Seq.sum)
