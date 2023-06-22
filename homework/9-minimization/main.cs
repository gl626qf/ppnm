using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;



// public class genlist<T>{
// 	public T[] data;
// 	public int size => data.Length;
// 	public T this[int i] => data[i]; 
// 	public genlist(){ data = new T[0]; }
// 	public void add(T item){
// 		T[] newdata = new T[size+1];
// 		System.Array.Copy(data,newdata,size);
// 		newdata[size]=item;
// 		data=newdata;
// 	}
// }
public class func{
	public static vector qnewton(
	Func<vector,double> f, /* objective function */
	vector start, /* starting point */
	double acc /* accuracy goal, on exit |gradient| should be < acc */
)
}



public class integrate{


	public static double Integrate
	(Func<double,double> f, double a, double b,
	double delta=0.001, double eps=0.001, double f2=double.NaN, double f3=double.NaN)
	{
	double h=b-a;
	if(double.IsNaN(f2)){ f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
	double f1=f(a+h/6), f4=f(a+5*h/6);
	double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
	double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
	double err = Math.Abs(Q-q);
	if (err <= delta+eps*Math.Abs(Q)) return Q;
	else return Integrate(f,a,(a+b)/2,delta/Math.Sqrt(2),eps,f1,f2) + Integrate(f,(a+b)/2,b,delta/Math.Sqrt(2),eps,f3,f4);
	}


}

public class main{
public static void Main(string[] args){


	foreach(var arg in args){
		if(arg == "-test"){
			WriteLine("Hej");
			Func<double,double> f = (double x) => Pow(x,0.5);

			integrate.Integrate(f, 2, 4);
		}


	}//foreach	


	}//Main
}//main










