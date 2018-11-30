#include "ODESolving.h"
#define _CRT_SECURE_NO_WARNINGS
#include <D:\\Egyetem\\Allamvizsga\\Modeler\\boost_1_68_0\\boost\\numeric\\odeint.hpp>
#include <list> 
#include <iterator> 
#include <vector>
#include <iostream>
#include <fstream>
using namespace std;
namespace odeint = boost::numeric::odeint;

ODESolving::ODESolving( double x_firstArg, double x_secondArg, double t) {
	
	
	x[0] = x_firstArg;
	x[1] = x_secondArg;
	this->t = t;
	
}
int ODESolving::ODEResult(double mu, double omega, double eps) {
	//odeint::runge_kutta4<state_type> rk4;
	//pendulum p(mu, omega, eps);
	//odeHelper helper;
	//helper.t = this->t;
	//helper.x0 = this->x[0];
	//helper.x1 = this->x[1];
	//rk4.do_step(p, x, t, dt);
	//t += dt;
	////ofstream outfile("D:\\Egyetem\\Allamvizsga\\Modeler\\results.txt");
	///*try {
	//	
	//	outfile << helper.t << " " << helper.x0 << " " << helper.x1 << endl;
	//}
	//catch (exception e)
	//{
	//	return 0;
	//}*/
	//
	//for (size_t i = 0; i < 10; ++i) {
	//	rk4.do_step(p, x, t, dt);
	//	t += dt;
	//	helper.t = this->t;
	//	helper.x0 = this->x[0];
	//	helper.x1 = this->x[1];
	//	/*try {
	//		outfile << helper.t << " " << helper.x0 << " " << helper.x1 << endl;
	//	}
	//	catch (exception e) {
	//		return 0;
	//	}*/
	//}

	return 1;
}
