module Day7

open System.Text.RegularExpressions

type Expr =
    | BinOp of string * string * string
    | UnOp of string * string
    | Const of string
    | Number of string

let parse row =
    let m = Regex.Match(row, @"(\w+) (\w+)? ?(\w+)? ?-> (\w+)")
    let f (n: int) = m.Groups[n].Value

    f 4,
    match f 1 with
    | "NOT" -> UnOp("NOT", f 2)
    | _ ->
        match f 2 with
        | "AND"
        | "OR"
        | "LSHIFT"
        | "RSHIFT" -> BinOp(f 1, f 2, f 3)
        | _ -> Const(f 1)

let mutable memo: Map<string, int> = Map.empty

let rec solve (wires: Map<string, Expr>) (s: string) =
    let next = solve wires

    match Map.tryFind s memo with
    | Some r -> r
    | None ->
        match Map.tryFind s wires |> Option.defaultValue (Number s) with
        | BinOp(a, "AND", b) -> next a &&& next b
        | BinOp(a, "OR", b) -> next a ||| next b
        | BinOp(a, "LSHIFT", b) -> next a <<< next b
        | BinOp(a, "RSHIFT", b) -> next a >>> next b
        | UnOp("NOT", a) -> ~~~(next a)
        | Const a -> next a
        | Number n -> int n
        | _ -> failwith "err"
        |> fun r ->
            memo <- Map.add s r memo
            r

let solve1 (input: array<string>) =
    let wires = input |> Seq.map parse |> Map.ofSeq

    solve wires "a"

let solve2 (input: array<string>) =
    let wires = input |> Seq.map parse |> Map.ofSeq
    memo <- Map.add "b" (Map.find "a" memo) Map.empty

    solve wires "a"
