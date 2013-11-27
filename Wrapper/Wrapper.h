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
		

	protected:
		!WrapperAlgo(){delete algoCpp;}
	};
}
