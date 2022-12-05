let input = System.IO.File.ReadLines("day01/input.txt") |> Seq.head

let followInstruction x = if x = '(' then 1 else -1

input |> Seq.map followInstruction |> Seq.sum |> printfn "%d"

input
|> Seq.scan (fun acc x -> acc + followInstruction x) 0
|> Seq.takeWhile ((<>) -1)
|> Seq.length
|> printfn "%d"
