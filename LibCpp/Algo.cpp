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
Second step : coherent map : TODO

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

/**
* map[i] :  DESERT = 1,
    FOREST,
    LOWLAND,
    MOUTAIN,
    SEA,

* unitType : GAUL = 1,
    NAIN,
    VIKING,

* nbMoves : pointer referencing the number of moves found.

* return : an array containing nbMoves triple : (row, col, weight)
*/

int* Algo::getBestMoves(int map[], int size, int unitType, int pos, int opponents[], int nbOpponents, int *nbMoves) {
	int * bestMoves = NULL;
	(*nbMoves) = 0;

	int unitRow = pos / size;
	int unitCol = pos % size;

	for(int row = 0; row < size; row ++) {
		for(int col = 0; col < size; col++) {
			// If (the tile isn't too far and not a sea (except for viking)) or is a mountain for nain on a mountain
			if(((abs(unitRow - row) + abs(unitCol - col)) <= 1 && (unitType == 3 || map[row*size+col] != 5)) 
				|| (unitType == 2 && map[row*size+col] == 4 && map[pos] == 4)) {
				(*nbMoves)++;
				bestMoves = (int*)realloc(bestMoves, 3 * (*nbMoves)*sizeof(int));

				if(bestMoves != NULL) {
					bestMoves[((*nbMoves) - 1) * 3] = row;
					bestMoves[((*nbMoves) - 1) * 3 + 1] = col;
					bestMoves[((*nbMoves) - 1) * 3 + 2] = getPoints(row*size + col, map, size, unitType) - getNbOpponents(row*size + col, opponents, nbOpponents);
				}
			}
		}
	}
	return bestMoves;
}

int Algo::getNbOpponents(int pos, int* opponents, int nbAllOpponents) {
	int nbOpponents = 0;

	for(int i = 0; i < nbAllOpponents; i++) {
		if(opponents[i] == pos)
			nbOpponents++;
	}
	return nbOpponents;
}

/**
* tileType[i] :  DESERT = 1,
FOREST,
LOWLAND,
MOUTAIN,
SEA,

* unitType : GAUL = 1,
NAIN,
VIKING,
*/
int Algo::getPoints(int pos, int* map, int size, int unitType) {
	int points = 1;

	if(unitType == 1 && map[pos] == 3)
		points++;
	if(unitType == 1 && map[pos] == 4)
		points--;

	if(unitType == 2 && map[pos] == 2)
		points++;
	if(unitType == 2 && map[pos] == 3)
		points--;

	if(unitType == 3 && hasWaterBorder(pos, map, size))
		points++;
	if(unitType == 3 && map[pos] == 1)
		points--;
	if(unitType == 3 && map[pos] == 5)
		points--;

	return points;
}

bool Algo::hasWaterBorder(int pos, int* map, int size) {
	int unitRow = pos / size;
	int unitCol = pos % size;

	bool hasWater = false;

	for(int row = unitRow - 1; row <= unitRow + 1; row++) {
		for(int col = unitCol - 1; col <= unitCol + 1; col++) {
			if(row > 0 && col > 0 && row < size && col < size) {
				if(map[row*size + col] == 5)
					hasWater = true;
			}
		}
	}
	return hasWater;
}
