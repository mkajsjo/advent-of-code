let input = System.IO.File.ReadLines("day03/input.txt")

let intersect seqs =
    seqs |> Seq.map Set.ofSeq |> Seq.reduce Set.intersect

let priority (item: char) =
    let n = int item
    if item >= 'a' then n - 96 else n - 38

input
|> Seq.map (Seq.splitInto 2 >> intersect >> Seq.map priority >> Seq.sum)
|> Seq.sum
|> printfn "%d"

input
|> Seq.chunkBySize 3
|> Seq.map (intersect >> Seq.head >> priority)
|> Seq.sum
|> printfn "%d"
