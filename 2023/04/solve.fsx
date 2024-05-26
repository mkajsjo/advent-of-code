#r "../../lib/bin/lib.dll"
open Lib

let parseLine (line: string): int =
    let matchWinning = line |> regexMatch ":.*\|" |> parseNrs |> fun nrs -> @"\b" + System.String.Join(@"\b|\b", nrs) + @"\b"
    line.Split('|')[1] |> regexMatches matchWinning |> Seq.length

let getScore (n: int) = if n > 0 then pown 2 (n-1) else 0

let rec processCards (acc: list<int>) (cardScores: list<int>) =
    let next n ns c cs = processCards (List.merge (+) (List.replicate c (n+1)) ns) cs
    match acc, cardScores with
    | n :: ns, c :: cs -> (n+1) :: next n ns c cs
    | [], c :: cs -> 1 :: next 0 [] c cs
    | _ -> []

solve "04" (Seq.sumBy (parseLine >> getScore))
solve "04" (Seq.map parseLine >> List.ofSeq >> processCards [] >> Seq.sum)
