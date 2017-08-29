module ConcoleTest
open FFileProcessor

[<EntryPoint>]
let main argv = 
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    
    processFile @"c:\temp\seq.txt"    
    stopWatch.Stop()
    printfn "%f" stopWatch.Elapsed.TotalMilliseconds

    System.Console.ReadKey ()
    0


