// TestWrapperCLR.cpp : main project file.

#include "stdafx.h"
using namespace System;
using namespace Wrapper;

int main(array<System::String ^> ^args)
{
	WrapperAlgo^ mAlgo = gcnew WrapperAlgo();
	Console::WriteLine(mAlgo->fTest(10));
    return 0;
}
