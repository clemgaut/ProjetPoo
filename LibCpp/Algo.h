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
};

