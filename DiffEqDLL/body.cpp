#pragma once
#include "header.h"

myClass::myClass(double var_x, double var_y)
{
	x = var_x;
	y = var_y;
}

int myClass::sumX_Y() {
	return x + y;
}