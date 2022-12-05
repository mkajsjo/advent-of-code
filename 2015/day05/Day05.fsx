open System.Text.RegularExpressions

let niceString str =
    let m1 = Regex.Match(str, @"[aeiou].*[aeiou].*[aeiou]")
    let m2 = Regex.Match(str, @"(\w)\1")
    let m3 = Regex.Match(str, @"(ab|cd|pq|xy)")
    m1.Success && m2.Success && not m3.Success

let niceString2 str =
    let m1 = Regex.Match(str, @"(\w{2}).*\1")
    let m2 = Regex.Match(str, @"(\w).\1")
    m1.Success && m2.Success

let input = System.IO.File.ReadLines("day05/input.txt")

input |> Seq.filter niceString |> Seq.length |> printfn "%d"
input |> Seq.filter niceString2 |> Seq.length |> printfn "%d"
