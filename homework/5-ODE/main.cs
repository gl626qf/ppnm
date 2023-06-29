using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Collections.Generic;





public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i]; 
	public genlist(){ data = new T[0]; }
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
}

public static class runge_kutta{
		
	public static (vector,vector) rkstep12(
	Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
	double x,                    /* the current value of the variable */
	vector y,                    /* the current value y(x) of the sought function */
	double h                     /* the step to be taken */
	)
{
	vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
	vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
	vector yh = y+k1*h;              /* y(x+h) estimate */
	vector er = (k1-k0)*h;           /* error estimate */
	return (yh,er);
}	

	
	public static (genlist<double>,genlist<vector>) driver(
	Func<double,vector,vector> F, /* the f from dy/dx=f(x,y) */
	double a,                    /* the start-point a */
	vector ya,                   /* y(a) */
	double b,                    /* the end-point of the integration */
	double h=0.01,               /* initial step-size */
	double acc=0.01,             /* absolute accuracy goal */
	double eps=0.01              /* relative accuracy goal */
	){
	if(a>b) throw new ArgumentException("driver: a>b");
	double x=a; vector y=ya.copy();
	var xlist=new genlist<double>(); xlist.add(x);
	var ylist=new genlist<vector>(); ylist.add(y);
	do{ if(x>=b) return (xlist,ylist);
	if(x+h>b) h=b-x;
		var (yh,erv) = rkstep12(F,x,y,h);
		double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
		double err = erv.norm();

	// Including tolerance
	if(err<=tol){ 
		x+=h; y=yh;
		xlist.add(x);
		ylist.add(y);
	}
		h *= Min( Pow(tol/err,0.25)*0.95 , 2); 
	}while(true);
	} //driver with rkstep12


	public static vector driverImproved(
	Func<double,vector,vector> F, /* the f from dy/dx=f(x,y) */
	double a,                    /* the start-point a */
	vector ya,                   /* y(a) */
	double b,                    /* the end-point of the integration */
	genlist<double> xlist=null, genlist<vector> ylist=null,
	double h=0.01,               /* initial step-size */
	double acc=0.01,             /* absolute accuracy goal */
	double eps=0.01              /* relative accuracy goal */
	){
	if(a>b) throw new ArgumentException("driver: a>b");
	double x=a; vector y=ya.copy();
	if(xlist!=null){xlist.add(x);}
	if(ylist!=null){ylist.add(y);}

	do{
		if(x>=b) return y; 
		if(x+h>b) h=b-x;  
		var (yh,err) = rkstep12(F,x,y,h);
		vector tol = new vector(err.size);
		for(int i=0;i<y.size;i++)
			tol[i]=Max(acc,Abs(yh[i])*eps)*Sqrt(h/(b-a));
		bool ok=true;
		for(int i=0;i<y.size;i++)
			if(!(err[i]<tol[i])) ok=false;
		if(ok){ 
			x+=h; y=yh;
			if(xlist!=null)xlist.add(x);
			if(ylist!=null)ylist.add(y);
			}
		double factor = tol[0]/Abs(err[0]);
		for(int i=1;i<y.size;i++) factor=Min(factor,tol[i]/Abs(err[i]));
		h *= Min( Pow(factor,0.25)*0.95 ,2);
		}while(true);
	}//driverImproved


	



}





public class func{
	public static vector harmonic(double x, vector y){
        return new vector(y[1], -y[0]);
	}
	
	public static vector testFunc(double x, vector y){
		return new vector(y[1], -2*y[1] - y[0]);
	}

	public static vector hydrogen(double r, vector y){
		double E = -13.6;
		return new vector(y[1], -2/r*y[1] - 2*E / r);
	}

	public static vector pendulumFriction(double x, vector y){
		double b = 0.25;
		double c = 5.0;
		return new vector(y[1], -b * y[1] - c * Sin(y[0]));
	}


	public static Func<double,vector,vector> lotkavolterra = delegate(double x, vector y){
		double a = 1.5; 
		double b = 1.0; 
		double c = 3.0; 
		double d = 1.0;
		return new vector (a*y[0]-b*y[0]*y[1], -c*y[1]+d*y[0]*y[1]);
	};


	public static Func<double,vector,vector> planets = delegate(double x, vector y){
		// Making the masses
		double m1 = 2;
		double m2 = m1;
		double m3 = m1;

		double sum_ = 0;



		double a = 1.5; 
		double b = 1.0; 
		double c = 3.0; 
		double d = 1.0;
		return new vector (a*y[0]-b*y[0]*y[1], -c*y[1]+d*y[0]*y[1]);
	};





}


public class main{
public static void Main(string[] args){


	foreach(var arg in args){
		if(arg == "-harmonic"){
			vector init_y = new vector(0, 1);
			(var xs, var ys) = runge_kutta.driver(func.harmonic, 0, init_y, 30);
			for(int i=0; i<xs.size; i++) 
				WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
		}



		if(arg == "-testingODE"){
			vector init_y = new vector(0, 4);
			(var xs, var ys) = runge_kutta.driver(func.testFunc, 0, init_y, 30);
			for(int i=0; i<xs.size; i++) 
				WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
		}


		// Reproducing the scipy function

		if(arg == "-pendulumFriction"){
			vector ya = new vector(PI - 0.1, 0.0);
			(var xs, var ys) = runge_kutta.driver(func.pendulumFriction, 0, ya, 50);
			for(int i=0; i<xs.size; i++) 
				// WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][0]+ys[i][1]}");
				WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][0]+ys[i][1]}");
		}



		// Continuing with task B

		if(arg == "-lotkaVolterra"){
				double a = 0, b = 15;
				vector ya = new vector (10.0,5.0);
				var xs = new genlist<double>();
				var ys = new genlist<vector>();
				var y_end = runge_kutta.driverImproved(func.lotkavolterra, a, ya, b, xs, ys);
				WriteLine("Test of yend is returned");
				y_end.print("y end = ");
				for(int i = 0;i<xs.size;i++)
					WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");



		}

		if(arg == "-planets"){

		}



	}


	}
}










