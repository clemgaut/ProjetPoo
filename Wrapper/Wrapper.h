// Wrapper.h
#pragma once

#include "Algo.h"
#include <math.h>

using namespace System;

namespace Wrapper {

	public ref class WrapperAlgo
	{
	private:
		Algo* algoCpp;

	public:
		WrapperAlgo(){algoCpp = new Algo();}
		~WrapperAlgo(){delete algoCpp;}
		System::Int32 fTest(int n){return algoCpp->fTest(n);}
		System::Collections::Generic::List<int>^ mapGeneration(int size, int types)
		{
			System::Collections::Generic::List<int>^ map = gcnew System::Collections::Generic::List<int>(size);

			int* mapGenerated = algoCpp->mapGeneration(size, types);

			for (int i = 0; i < size; i++)
			{
				map->Add(mapGenerated[i]);
			}

			delete[] mapGenerated;

			return map;
		}

		System::Collections::Generic::List<int>^ initCoordonates(System::Collections::Generic::List<int>^ map, int size)
		{
			pin_ptr<int> p = &map->ToArray()[0];
			int* mapC = p;

			int* initCoordC = algoCpp->initCoordonates(mapC, size);

			System::Collections::Generic::List<int>^ initCoord = gcnew System::Collections::Generic::List<int>(2);
			initCoord->Add(initCoordC[0]);
			initCoord->Add(initCoordC[1]);

			delete[] initCoordC;

			return initCoord;
		}

		System::Collections::Generic::List<int>^ possibleMoves(System::Collections::Generic::List<int>^ map, int unitType, int pos, System::Collections::Generic::List<int>^ opponents) {
			pin_ptr<int> pmap = &map->ToArray()[0];
			int* mapC = pmap;

			pin_ptr<int> popp = &opponents->ToArray()[0];
			int* oppC = popp;

			int nbMoves = 0;
			int* moves = algoCpp->getBestMoves(mapC, ((int)sqrt((double)map->Count)), unitType, pos, oppC, opponents->Count, &nbMoves);

			System::Collections::Generic::List<int>^ lMoves = gcnew System::Collections::Generic::List<int>();

			//We skip the weight for now
			for(int i = 0; i < 3*nbMoves;) {
				lMoves->Add(moves[i++]);
				lMoves->Add(moves[i++]);
				moves[i++];
			}

			delete[] moves;

			return lMoves;
		}
		

	protected:
		!WrapperAlgo(){delete algoCpp;}
	};
}
