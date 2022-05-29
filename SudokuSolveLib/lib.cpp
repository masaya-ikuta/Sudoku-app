#define _CRT_SECURE_NO_WARNINGS
#include"lib.h"
#include <vector>
#include <string.h>
#include <iostream>

using namespace std;

DLLEXPORT bool __stdcall solve(char* dst, const char* src)
{
	SudokuSolver solver;
	vector<vector<int>> a(9, vector<int>(9));
	strcpy(dst, src);
	for (int i = 0; i < 81; i++) {
		a[i / 9][i % 9] = src[i] - '0';
	}
	bool vs =  solver.solve(a);
	for (int i = 0; i < 81; i++) {
		dst[i] = a[i / 9][i % 9] + '0';
	}
	return vs;
}
