#include "stdafx.h"
#include <stdint.h>
#include <fstream>
#include <ctime>

uint64_t Gcd(uint64_t m, uint64_t n)
{
	if (m == 0) return n;
	if (n == 0) return m;
	if (n == m) return n;
	if (n == 1 || m == 1) return 1;

	int evm = (m & 1) == 0;
	int evn = (n & 1) == 0;
	if (evm && evn) return 2 * Gcd(m >> 1, n >> 1);
	if (evm) return Gcd(m >> 1, n);
	if (evn) return Gcd(m, n >> 1);
	if (n > m) return Gcd(m, (n - m) >> 1);
	return Gcd((m - n) >> 1, n);
}

int main()
{
	clock_t begin = clock();

	std::ifstream infile("c:\\temp\\seq.txt");
	std::ofstream outfile("c:\\temp\\seq.txt.resultp");

	uint64_t a, b = 0;

	while (infile >> a)
	{
		if (b != 0)		
		{
			uint64_t g = Gcd(a, b);
			outfile << g << "\n";
		}
		b = a;
	}
	clock_t end = clock();

	printf("%d mils elapsed", end - begin);
	getchar();

    return 0;
}
