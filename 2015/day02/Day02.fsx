let readLines filePath = System.IO.File.ReadLines(filePath)

let parseDimensions str =
    let m = System.Text.RegularExpressions.Regex.Match(str, @"(\d+)x(\d+)x(\d+)")
    let f (n: int) = m.Groups[n].Value |> int
    f 1, f 2, f 3

let calcPaperRequired (w, h, l) =
    let dims = [ l * w; w * h; h * l ]
    2 * Seq.sum dims + Seq.min dims

let calcRibbonRequired (w, h, l) =
    let sides = [ w; h; l ]
    let shortestDistance = sides |> Seq.sort |> Seq.take 2 |> Seq.sum |> (*) 2
    let volume = Seq.reduce (*) sides
    shortestDistance + volume

let input = System.IO.File.ReadLines("day02/input.txt") |> Seq.map parseDimensions

input |> Seq.sumBy calcPaperRequired |> printfn "%d"
input |> Seq.sumBy calcRibbonRequired |> printfn "%d"
