// Wrapper.h
#pragma once

#include "Algo.h"

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
		

	protected:
		!WrapperAlgo(){delete algoCpp;}
	};
}
