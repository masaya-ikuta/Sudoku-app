#pragma once
#include "Sudoku.h"

#ifdef __cplusplus
#define DLLEXPORT extern "C" __declspec(dllexport)
#else
#define DLLEXPORT __declspec(dllexport)
#endif

extern "C" {
	DLLEXPORT bool __stdcall solve(char* dst, const char* src);
}
