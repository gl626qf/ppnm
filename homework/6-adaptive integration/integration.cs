using System;
using static System.Math;
using static System.Console;

public class integration{


    
	public static double integrate(Func<double,double> f, double a, double b,
		double acc=0.001, double eps=0.001, double f2=Double.NaN, double f3=Double.NaN){
		double h=b-a;
		if(Double.IsNaN(f2)){f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
		double f1=f(a+h/6), f4=f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
		double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
		double err = Abs(Q-q);
		if (err <= acc+eps*Abs(Q)) return Q;
		else return integrate(f,a,(a+b)/2,acc/Sqrt(2),eps,f1,f2)+integrate(f,(a+b)/2,b,acc/Sqrt(2),eps,f3,f4);
	}



	public static double ccTransform2
		(Func<double, double> f, double a, double b, double delta = 0.001, double epsilon = 0.001)
	{
		Func<double,double> h = (theta) => f((a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2;
		return integrate(h,0,PI,delta,epsilon);
	}
}