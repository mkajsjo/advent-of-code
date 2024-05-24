#r "../../lib/bin/lib.dll"
open Lib
open System

let getNr (line: string) =
    let first = line |> Seq.find Char.IsDigit
    let last = line |> Seq.findBack Char.IsDigit
    int $"{first}{last}"

let (|TextDigit|_|) (charList: list<char>) =
    match charList with
    | 'z' :: 'e' :: 'r' :: 'o' :: _ -> Some '0'
    | 'o' :: 'n' :: 'e' :: _ -> Some '1'
    | 't' :: 'w' :: 'o' :: _ -> Some '2'
    | 't' :: 'h' :: 'r' :: 'e' :: 'e' :: _ -> Some '3'
    | 'f' :: 'o' :: 'u' :: 'r' :: _ -> Some '4'
    | 'f' :: 'i' :: 'v' :: 'e' :: _ -> Some '5'
    | 's' :: 'i' :: 'x' :: _ -> Some '6'
    | 's' :: 'e' :: 'v' :: 'e' :: 'n' :: _ -> Some '7'
    | 'e' :: 'i' :: 'g' :: 'h' :: 't' :: _ -> Some '8'
    | 'n' :: 'i' :: 'n' :: 'e' :: _ -> Some '9'
    | _ -> None

let replaceTextDigits: string -> string =
    let rec replace charList =
        match charList with
        | TextDigit c
        | c :: _ -> c :: replace (List.tail charList)
        | [] -> []

    List.ofSeq >> replace >> List.toArray >> System.String

solve "01" (Seq.sumBy getNr)
solve "01" (Seq.sumBy (replaceTextDigits >> getNr))
