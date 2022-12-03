let input = System.IO.File.ReadAllText("day01/input.txt")

let parseInventory (s: string) =
    s.Split("\n") |> Seq.filter ((<>) "") |> Seq.map int

let calories = input.Split("\n\n") |> Seq.map (parseInventory >> Seq.sum)

calories |> Seq.max |> printfn "%d"
calories |> Seq.sortDescending |> Seq.take 3 |> Seq.sum |> printfn "%d"
