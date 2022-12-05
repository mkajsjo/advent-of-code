let input = "yzbqklnj"

let md5 (str: string) =
    use md5 = System.Security.Cryptography.MD5.Create()

    str
    |> System.Text.Encoding.ASCII.GetBytes
    |> md5.ComputeHash
    |> Seq.map (fun c -> c.ToString("X2"))
    |> Seq.reduce (+)

let rec mine m n =
    let zeros = String.replicate m "0"
    let hash = md5 <| input + (string) n
    if hash[0 .. m - 1] = zeros then n else mine m (n + 1)

mine 5 1 |> printfn "%d"
mine 6 1 |> printfn "%d"
