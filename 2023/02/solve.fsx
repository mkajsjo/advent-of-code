#r "../../lib/bin/lib.dll"
open Lib

let parseGame (line: string): int * seq<list<int>> =
    let parseRound (round: string): list<int> =
        ["red"; "green"; "blue"] |> List.map ((+) "(\d+) " >> parseNr round)

    parseNr line @"Game (\d+)",
    line.Split(';') |> Seq.map parseRound

let bagRestriction =
    function
    | [r; g; b] when r <= 12 && g <= 13 && b <= 14 -> true
    | _ -> false

solve "02" (Seq.map parseGame >> Seq.filter (snd >> Seq.forall bagRestriction) >> Seq.sumBy fst)
solve "02" (Seq.sumBy (parseGame >> snd >> Seq.transpose >> Seq.map Seq.max >> Seq.reduce (*)))
