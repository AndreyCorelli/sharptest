module FMath

let rec Gcd (m : uint64, n : uint64) =
    let d =
        if m = 0UL then n
        elif n = 0UL then m
        elif n = m then n
        elif n = 1UL then 1UL
        elif m = 1UL then 1UL
        else 0UL

    if d > 0UL then d
    else
       let evm = (m &&& 1UL) = 0UL
       let evn = (n &&& 1UL) = 0UL
       if (evm && evn) then 2UL * Gcd (m >>> 1, n >>> 1)
       elif (evm && evn = false) then Gcd (m >>> 1, n)
       elif (evm = false && evn) then Gcd (m, n >>> 1)
       elif (n > m) then Gcd (m, (n - m) >>> 1)
       else Gcd ((m - n) >>> 1, n)

