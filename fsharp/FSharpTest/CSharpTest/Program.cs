using System;
using System.IO;
using System.Text;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong? a = null;
            const string fname = @"c:\temp\seq.txt";

            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            using (var sr = new StreamReader(fname))
            using (var sw = new StreamWriter(fname + ".resultc", false, Encoding.ASCII))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var b = Convert.ToUInt64(line);
                    if (a != null) 
                        sw.WriteLine(Gcd(a.Value, b));
                    a = b;
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Elapsed: " + stopWatch.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }

        static ulong Gcd(ulong m, ulong n)
        {
            if (m == 0) return n;
            if (n == 0) return m;
            if (n == m) return n;
            if (n == 1 || m == 1) return 1;

            var evm = (m & 1) == 0;
            var evn = (n & 1) == 0;
            if (evm && evn) return 2 * Gcd(m >> 1, n >> 1);
            if (evm) return Gcd(m >> 1, n);
            if (evn) return Gcd(m, n >> 1);
            if (n > m) return Gcd(m, (n - m) >> 1);
            return Gcd((m - n) >> 1, n);
        }

        static void PrepareFile(long count)
        {
            var rnd = new Random();
            using (var sw = new StreamWriter(@"c:\temp\seq.txt", false, Encoding.ASCII))
            for (long i = 0; i < count; i++)
                    sw.WriteLine((ulong)rnd.Next() * (ulong)rnd.Next());
        }
    }
}
