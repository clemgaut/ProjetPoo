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
		

	protected:
		!WrapperAlgo(){delete algoCpp;}
	};
}
