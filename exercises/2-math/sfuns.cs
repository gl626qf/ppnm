using System;
using static System.Console;
using static System.Math;

public class sfuns{
	public static double lngamma(double x){
		///single precision gamma function (formula from Wikipedia)
		if(x<0)return PI/Sin(PI*x)/lngamma(1-x); // Euler's reflection formula
		if(x<9)return lngamma(x+1)/x; // Recurrence relation
		double lngamma_=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return lngamma_;
		}



	public static double gamma(double x){
		if(x <= 0) return double.NaN;
		if(x < 9) return gamma(x+1) - Log(x);
		return Exp(lngamma(x));
	}

}
