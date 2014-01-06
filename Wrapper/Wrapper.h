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
		/**
		Generate a coherent square map.
		size : the size of the map (only the width) : example : 5 for a 5x5 map
		types : the number of different tiles

		return : A list representing the map. The 2D map is coded as an 1D array and map[line,column] = generatedMap[line*width+column].
				 Moreover, 1 <= generatedMap[line*width+column] <= types
		*/
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

		/**
		Get the init coordonates of a nation.
		map : the current map
		size : the map size
		return a list with the init line at index 0 and the init column at index 1.
		*/
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

		/**
		Get all possible moves for a given unit
		map : the map
		* unitType : The type of the current unit
		* pos : the position of the unit
		* opponents : The opponents' position

		* return : an array containing some pair : (row, col) of possible moves
		*/
		System::Collections::Generic::List<int>^ possibleMoves(System::Collections::Generic::List<int>^ map, int unitType, int pos, System::Collections::Generic::List<int>^ opponents) {
			pin_ptr<int> pmap = &map->ToArray()[0];
			int* mapC = pmap;

			int* oppC = 0;

			if(opponents->Count > 0) {
				pin_ptr<int> popp = &opponents->ToArray()[0];
				oppC = popp;
			}

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
