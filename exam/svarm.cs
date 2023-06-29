// The main algorithm is copied from the matlib folder and is made by Dmitri Fedorov
using System;
using System.Diagnostics;
using static System.Console;

public static class svarm{


	// Generates random vector for the algorithm
	public static vector randomvec(vector a,vector b,Random rnd){
		var x=new vector(a.size);
		for(int i=0;i<a.size;i++)x[i]=a[i]+(b[i]-a[i])*rnd.NextDouble();
		return x;
		}



	// The algorithm
	public static vector run
	(Func<vector,double>f,vector a,vector b,int seconds=1,double w=0.723)
	{
	int dim=a.size, N=8*dim;
	vector[] x=new vector[N], v=new vector[N], p=new vector[N];
	var fp=new double[N];
	var rnd=new Random();
	var g=randomvec(a,b,rnd);
	double fg=f(g);
	for(int i=0;i<N;i++){
		x[i]=randomvec(a,b,rnd);
		p[i]=x[i].copy();
		fp[i]=f(p[i]);
		if(fp[i]<fg){g=p[i].copy();fg=fp[i];}
		v[i]=randomvec(a-b,b-a,rnd)/2;
		}
	var start_time=DateTime.Now;
	do{
		for(int i=0;i<N;i++){
			v[i]=w*v[i]
				+rnd.NextDouble()*(p[i]-x[i])
				+rnd.NextDouble()*(g-x[i]);
			x[i]+=v[i];
			var fxi=f(x[i]);
			if(fxi<fp[i]){fp[i]=fxi;p[i]=x[i].copy();}
			if(fxi<fg)   {fg=fxi;   g=x[i].copy();}
		}
	}while((DateTime.Now-start_time).TotalSeconds < seconds);
	return g;	
	}



}