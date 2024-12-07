module Day1

let walk =
    function
    | '(' -> 1
    | _ -> -1

let solve1 (input: array<string>) = input |> Seq.head |> Seq.sumBy walk

let solve2 (input: array<string>) =
    input
    |> Seq.head
    |> Seq.scan (fun acc n -> acc + walk n) 0
    |> Seq.findIndex ((=) -1)
    |> (+) 1
