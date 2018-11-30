// dllmain.cpp : Defines the entry point for the DLL application.
// https://www.youtube.com/watch?v=hwmRtnJag4A&t=328s

#include "stdafx.h"
#include "D:\Egyetem\Allamvizsga\Modeler\DiffEqDLL\ODESolving.h"
#include "D:\Egyetem\Allamvizsga\Modeler\DiffEqDLL\ODESolving.cpp"

//extern "C" _declspec(dllexport) double sumTwo(double var_x, double var_y)
//{
//	myClass MC(var_x, var_y);
//	return MC.sumX_Y();
//}

extern "C" _declspec(dllexport) int ODESolverLibrary(double mu, double omega, double eps)
{
	double x_firstArg=1.0;
	double x_secondArg=0.0;
	double t = 0.0;
	ODESolving odeSolving(x_firstArg, x_secondArg, t);
	return odeSolving.ODEResult(mu, omega, eps);
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

