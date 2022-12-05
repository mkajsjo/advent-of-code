let split (s: string) =
    let a = s.Split(" ")
    a[0], a[1]

let input = System.IO.File.ReadLines("day02/input.txt") |> Seq.map split

let score (theirs, yours) =
    let choiceScore =
        match yours with
        | "X" -> 1
        | "Y" -> 2
        | "Z" -> 3
        | _ -> raise <| System.Exception("Can't happen")

    let outcomeScore =
        match theirs, yours with
        | "A", "Y" -> 6
        | "B", "Z" -> 6
        | "C", "X" -> 6
        | "A", "X" -> 3
        | "B", "Y" -> 3
        | "C", "Z" -> 3
        | _ -> 0

    choiceScore + outcomeScore

let remapChoise (theirs, outcome) =
    let yours =
        match theirs, outcome with
        | "A", "Y" -> "X"
        | "B", "X" -> "X"
        | "C", "Z" -> "X"
        | "A", "Z" -> "Y"
        | "B", "Y" -> "Y"
        | "C", "X" -> "Y"
        | _ -> "Z"

    theirs, yours

input |> Seq.map score |> Seq.sum |> printfn "%d"
input |> Seq.map (remapChoise >> score) |> Seq.sum |> printfn "%d"
