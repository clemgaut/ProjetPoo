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
Second step : coherent map : TODO

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

/*
Return the init coordonates for the 2 nations of the map

(First step -> random)
Second step : TODO

map : the current map
size : the map size
*/
int* Algo::initCoordonates(int map[], int size)
{
	int* initCoord = (int*)malloc(2*sizeof(int));

	/* initialize random seed: */
	srand(time(NULL));

	initCoord[0] = rand() % size;

	initCoord[1] = initCoord[0];

	//we want different coordonates for the 2 nations
	while (initCoord[1] == initCoord[0])
		initCoord[1] = rand() % size;

	return initCoord;
}