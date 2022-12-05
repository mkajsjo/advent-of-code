open System
open System.Text.RegularExpressions

let isCapitalLetter c = c >= 'A' && c <= 'Z'

let parseStacks =
    Seq.transpose
    >> Seq.map (Seq.skipWhile (not << isCapitalLetter) >> List.ofSeq)
    >> Seq.filter (not << Seq.isEmpty)
    >> Array.ofSeq

let parseInstruction line =
    let m = Regex.Match(line, "move (\d+) from (\d+) to (\d+)")
    let f (n: int) = m.Groups[n].Value |> int
    f 1, (f 2) - 1, (f 3) - 1

let stacks, instructions =
    System.IO.File.ReadLines("day05/input.txt")
    |> fun seq -> Seq.take 8 seq |> parseStacks, Seq.skip 10 seq |> Seq.map parseInstruction

let move f (stacks: char list[]) (nr, fromIndex, toIndex) =
    let toMove, remaining = List.splitAt nr stacks[fromIndex]
    stacks[fromIndex] <- remaining
    stacks[toIndex] <- f toMove @ stacks[toIndex]
    stacks

let solve f =
    instructions
    |> Seq.fold (move f) (Array.copy stacks)
    |> Seq.map Seq.head
    |> String.Concat
    |> printfn "%s"

solve List.rev
solve id
