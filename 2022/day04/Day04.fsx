let parseLine (s: string) =
    let m = System.Text.RegularExpressions.Regex.Match(s, "(\d+)-(\d+),(\d+)-(\d+)")
    let f (n: int) = int m.Groups[n].Value
    f 1, f 2, f 3, f 4

let input = System.IO.File.ReadLines("day04/input.txt") |> Seq.map parseLine

let contains (a, b, x, y) = a >= x && b <= y || x >= a && y <= b

let overlaps (a, b, x, y) = a <= y && b >= x

input |> Seq.filter contains |> Seq.length |> printfn "%d"
input |> Seq.filter overlaps |> Seq.length |> printfn "%d"
