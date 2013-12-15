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
<<<<<<< HEAD
	DLL int Algo::interpolation_cos (int a, int b, double x);
	DLL int Algo::interpolation_cos2D (int a, int b, int c, int d, double x, double y);
=======
	DLL int* initCoordonates(int map[], int size);
>>>>>>> 135a0490bf2590c7d636e4d5d77b7a0d97d9c3b6
};

