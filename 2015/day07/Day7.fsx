module Day7

open System.Text.RegularExpressions

let readLines filePath =
    System.IO.File.ReadLines(filePath)

type BinOp =
    | And
    | Or
    | Lshift
    | Rshift

type UnOp =
    | Not

type Expr =
    | Variable of string
    | Constant of int
    | BinExpr of BinOp * Expr * Expr
    | UnExpr of UnOp * Expr

let evalBinOp op =
    match op with
    | And -> (&&&)
    | Or -> (|||)
    | Lshift -> (<<<)
    | Rshift -> (>>>)

let evalUnOp op =
    match op with
    | Not -> (~~~)

let rec eval (expr: Expr) (map: Map<string, Expr>) =
    match expr with
    | Variable v ->
        printfn "%s" v
        eval map[v] map
    | Constant c ->
        c
    | BinExpr (op, a, b) ->
        (evalBinOp op) (eval a map) (eval b map)
    | UnExpr (op, e) ->
        (evalUnOp op) (eval e map)

let parseConstantOrVariable (str: string) =
    match System.Int32.TryParse str with
    | true, value ->
        Constant value
    | _ ->
        Variable str

let parseBinOp op =
    match op with
    | "AND" -> And
    | "OR" -> Or
    | "LSHIFT" -> Lshift
    | "RSHIFT" -> Rshift
    | _ -> raise <| System.Exception($"Could not parse operator: {op}")

let parseUnExpr e =
    UnExpr (Not, parseConstantOrVariable e)

let parseBinExpr aStr opStr bStr =
    let op = parseBinOp opStr
    let a = parseConstantOrVariable aStr
    let b = parseConstantOrVariable bStr
    BinExpr (op, a, b)

let parseLine line =
    let m1 = Regex.Match(line, @"^(\w+) -> (\w+)$")
    let m2 = Regex.Match(line, @"^NOT (\w+) -> (\w+)$")
    let m3 = Regex.Match(line, @"^(\w+) (\w+) (\w+) -> (\w+)$")
    let get (m: Match) (n: int) = m.Groups[n].Value
    match m1.Success, m2.Success, m3.Success with
        | true, _, _ ->
            (get m1 2), parseConstantOrVariable (get m1 1)
        | _, true, _ ->
            (get m2 2), parseUnExpr (get m2 1)
        | _, _, true ->
            (get m3 4), parseBinExpr (get m3 1) (get m3 2) (get m3 3)
        | _ ->
            raise <| System.Exception($"Could not parse expression: {line}")

let first () =
    let exprMap =
        readLines "day7/input.txt"
        |> Seq.map parseLine
        |> Map.ofSeq
    eval exprMap["a"] exprMap
    |> printfn "%d"

let second () =
    ()

let solve () =
    first ()
    second ()

