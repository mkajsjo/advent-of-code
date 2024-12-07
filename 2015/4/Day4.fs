module Day4

let md5 (str: string) =
    use md5 = System.Security.Cryptography.MD5.Create()

    str
    |> System.Text.Encoding.ASCII.GetBytes
    |> md5.ComputeHash
    |> Seq.map (fun c -> c.ToString("X2"))
    |> Seq.reduce (+)

let findHash (n: int) (input: array<string>) =
    let secret = input |> Seq.head
    let zeros = System.String('0', n)

    Seq.initInfinite id
    |> Seq.findIndex (fun i -> (md5 $"{secret}{i}")[0 .. n - 1] = zeros)

let solve1 (input: array<string>) = findHash 5 input
let solve2 (input: array<string>) = findHash 6 input
