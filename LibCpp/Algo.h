#pragma once
#define WANTDLLEXP
#ifdef WANTDLLEXP
#define DLL __declspec(dllexport)
#else
#define DLL
#endif

class Algo
{
public:
	DLL Algo(void);
	DLL ~Algo(void);
	DLL int fTest(int n);
	DLL int* mapGeneration (int size, int types);
	DLL int Algo::interpolation_cos (int a, int b, double x);
	DLL int Algo::interpolation_cos2D (int a, int b, int c, int d, double x, double y);
	DLL int* initCoordonates(int map[], int size);
	DLL int* getBestMove(int map[], int size, int unitType, int pos, int opponents[], int nbOpponents, int *nbMoves);
	DLL int getNbOpponents(int pos, int* opponents, int nbAllOpponents);
	DLL int getPoints(int pos, int* map, int size, int unitType);
	DLL bool hasWaterBorder(int pos, int* map, int size);
};

