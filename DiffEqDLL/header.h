#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <D:\\Egyetem\\Allamvizsga\\Modeler\\boost_1_68_0\\boost\\numeric\\odeint.hpp>



using namespace std;
namespace odeint = boost::numeric::odeint;
class myClass
{
public:
	typedef std::array<double, 2> state_type;
	typedef struct odeHelper {
		double t;
		double x0;
		double x1;
	};
	myClass(double x_firstArg, double x_secondArg, double t, double mu, double omega, double eps);
	int sumX_Y();
private:
	const double dt = 0.01;
	double t;
	state_type x1;
	double mu, omega, eps;
	struct pendulum {
		double m_mu, m_omega, m_eps;
		pendulum(double mu, double omega, double eps) :
		m_mu(mu), m_omega(omega), m_eps(eps) { }
		void operator() (const state_type &x, state_type &dxdt, double t)const
		{
			dxdt[0] = x[1];
			dxdt[1] = -sin(x[0]) - m_mu * x[1] + m_eps * sin(m_omega*t);
		}
	};
};