module Day4

let toArray = Seq.cast<char> >> Array.ofSeq
let toString = Seq.cast<char> >> System.String.Concat

let solve1 (input: array<string>) =
    let grid = array2D input

    Seq.allPairs [0..Array2D.length1 grid - 1] [0..Array2D.length2 grid - 1]
    |> Seq.collect (fun (x, y) ->
        let arrs =
            match grid[x..x+3, y..y+3] |> toArray with
            | chars when Seq.length chars = 16 ->
                [
                    grid[x..x+3,y]
                    grid[x, y..y+3]
                    [| chars[0]; chars[5]; chars[10]; chars[15] |]
                    [| chars[3]; chars[6]; chars[9]; chars[12] |]
                ]
            | _ ->
                [ grid[x..x+3,y]; grid[x, y..y+3] ]

        arrs
        @ (List.map Array.rev arrs)
        |> Seq.map toString
    )
    |> Seq.filter ((=) "XMAS")
    |> Seq.length

let solve2 (input: array<string>) =
    let grid = array2D input
    let isMas s = s = "MAS" || s = "SAM"

    Seq.allPairs [0..Array2D.length1 grid - 1] [0..Array2D.length2 grid - 1]
    |> Seq.map (fun (x, y) ->
        match grid[x..x+2, y..y+2] |> toArray with
        | chars when Seq.length chars = 9 ->
            [| chars[0]; chars[4]; chars[8] |] |> toString,
            [| chars[2]; chars[4]; chars[6] |] |> toString
        | _ -> "", ""
    )
    |> Seq.filter (fun (dia1, dia2) -> isMas dia1 && isMas dia2)
    |> Seq.length

