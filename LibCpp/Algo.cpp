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

/*
Generate the map (first step : random -> done)

size : size of the generated map
types : number of case types (generated number is between 1 and value of types)
*/
int* Algo::mapGeneration (int size, int types) {
 
	/* initialize random seed: */
	srand (time (NULL));

	/* create new array*/
	int* map = (int*)malloc(size*sizeof(int));

	for (int i = 0; i < size; i++)
	{
		/* generate secret number between 1 and types */
		map[i] = rand() % types + 1;
	}

	return map;
}