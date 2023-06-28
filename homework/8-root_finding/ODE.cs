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
