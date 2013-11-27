#include <stdio.h>      /* printf, scanf, puts, NULL */
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */


#include "Algo.h"


Algo::Algo(void)
{
}


Algo::~Algo(void)
{
}

int Algo::fTest(int n)
{
	return n;
}

int* Algo::mapGeneration (int size, int types) {
 
	/* initialize random seed: */
	srand (time (NULL));

	/* generate secret number between 1 and 10: */
	int i = rand () % 10 + 1;

	return &size;
}