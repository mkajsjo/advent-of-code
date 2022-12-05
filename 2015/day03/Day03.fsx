let readLines filePath = System.IO.File.ReadLines(filePath)

let move (x, y) c =
    match c with
    | '<' -> (x - 1, y)
    | '>' -> (x + 1, y)
    | '^' -> (x, y + 1)
    | 'v' -> (x, y - 1)
    | _ -> (x, y)

let input = System.IO.File.ReadLines("day03/input.txt") |> Seq.head

let visitHouses seq = Seq.scan move (0, 0) seq

let countDistinct = Seq.distinct >> Seq.length

let divideInstructions = List.ofSeq >> List.pairwise >> List.unzip

let visitHouses2 (even, odd) =
    [ even; odd ] |> Seq.collect visitHouses

input |> visitHouses |> countDistinct |> printfn "%d"
input |> divideInstructions |> visitHouses2 |> countDistinct |> printfn "%d"
