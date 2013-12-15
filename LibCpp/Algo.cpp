#include <stdio.h>      /* printf, scanf, puts, NULL */
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */
#define _USE_MATH_DEFINES
#include <math.h>


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

	int fsize = size * size;

	/* create new array*/
	int* map = (int*)malloc(fsize*sizeof(int));

	for (int i = 0; i < fsize; i++) {
		/* generate secret number between 1 and types */
		map[i] = rand() % types + 1;
	}

	// Perlin Noise
	int a, b, c, d;
	double x, y;
	
		for (int i = 0; i < fsize; i++) {
 
			a = (i < size) ? rand () % types + 1 : map[i - size];
			b = ((i % size) == (size - 1)) ? rand () % types + 1 : map[i + 1];
			c = (i + size >= fsize) ? rand () % types + 1 : map[i + size];
			d = ((i % size) == 0) ? rand () % types + 1 : map[i - 1];

			x = rand () % 2;
			y = rand () % 2;
			map[i] = interpolation_cos2D (a, b, c, d, x, y);
		}

	return map;
}

int Algo::interpolation_cos (int a, int b, double x) {
	return a * (1 - x) + b * x;
}

int Algo::interpolation_cos2D (int a, int b, int c, int d, double x, double y) {
	int x1 = interpolation_cos (a, b, x);
	int x2 = interpolation_cos (c, d, x);
	return interpolation_cos (x1, x2, y);
}

