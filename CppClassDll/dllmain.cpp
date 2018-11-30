// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"
#include "D:\Egyetem\Allamvizsga\Modeler\DiffEqDLL\header.h"
#include "D:\Egyetem\Allamvizsga\Modeler\DiffEqDLL\body.cpp"

extern "C" _declspec(dllexport) int sumTwo(double var_x, double var_y)
{
	myClass MC(var_x, var_y);
	return MC.sumX_Y();
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

