#pragma once
#include "header.h"
#include <iostream>
#include <fstream>
myClass::myClass(double x_firstArg, double x_secondArg, double t, double mu, double omega, double eps)
{
	x1[0] = x_firstArg;
	x1[1] = x_secondArg;
	this->t = t;
	this->mu = mu;
	this->eps = eps;
	this->omega = omega;
}

int myClass::sumX_Y() {
	odeint::runge_kutta4<state_type> rk4;
	pendulum p(mu, omega, eps);
	odeHelper helper;
	helper.t = this->t;
	helper.x0 = this->x1[0];
	helper.x1 = this->x1[1];
	rk4.do_step(p, x1, t, dt);
	t += dt;
	fstream outfile;
	outfile.open("D:\\Egyetem\\Allamvizsga\\Modeler\\results.txt", ios::out);
	if (!outfile)
		return 0;
	try {
		outfile << helper.t << " " << helper.x0 << " " << helper.x1 << endl;
	}
	catch (exception e)
	{
		return 0;
	}
	for (size_t i = 0; i < 10; ++i) {
		rk4.do_step(p, x1, t, dt);
		t += dt;
		helper.t = this->t;
		helper.x0 = this->x1[0];
		helper.x1 = this->x1[1];
		try {
			outfile << helper.t << " " << helper.x0 << " " << helper.x1 << endl;
		}
		catch (exception e) {
			return 0;
		}

	}
	return 1;
}