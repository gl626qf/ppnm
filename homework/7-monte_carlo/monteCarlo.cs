using System;
using static System.Math;
using static System.Console;

public class monteCarlo{



	// int[] bs = new int[]
	// {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
	// int n = 0,s=0,d=1;


	public static double corput(int n, int b){
		double q=0,bk=1.0/b;
		while(n>0){q+=(n%b)*bk;n/=b;bk/=b;}
		return q;
	}



	public static vector halton(int n, int d, int shift=0){
		int[] Base = {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67};
		int maxd = Base.Length;
		if(d > maxd){
			throw new System.Exception("Dimension is too high");
		} 
		vector x = new vector(d);
		for (int i = 0;i<d; i++){
			x[i] = corput(n,Base[i+shift]);
		}
		return x;
	} 





	public static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
		int dim = a.size;
		double V = 1;
		for(int i=0; i<dim; i++) V*=b[i]-a[i];
		double sum = 0, sum2 = 0;
		vector x = new vector(dim);
		var rnd = new Random();
		for(int i=0; i<N; i++){
			for(int k=0; k<dim; k++) x[k] = a[k]+rnd.NextDouble()*(b[k]-a[k]);
			double fx = f(x);
			sum += fx;
			sum2 += fx*fx;
		}
		double mean = sum/N;
		double sigma = Sqrt(sum2/N - mean*mean);
		var result = (mean*V,sigma*V/Sqrt(N));
		return result;
	}


	public static (double,double) qmc(Func<vector,double> f, vector a , vector b, int N, int[] shift){
		int dim = a.size; double V=1;
		for(int i = 0;i<dim;i++)V*=b[i]-a[i]; 
			double sum1=0,sum2=0;
			var x = new vector(dim); 
		for(int i = 1; i<N/2;i++){
				var qRnd = halton(i,dim,shift:shift[0]);
				for(int k = 0;k<dim;k++)x[k]=a[k]+qRnd[k]*(b[k]-a[k]); 
				double fx = f(x); sum1+=fx;
				}
		for(int i = 1; i<N/2;i++){
				var qRnd = halton(i,dim,shift:shift[1]);
				for(int k = 0;k<dim;k++)x[k]=a[k]+qRnd[k]*(b[k]-a[k]); 
				double fx = f(x); sum2+=fx;
				}
		double mean = (sum1+sum2)/N;
		double sigma = Math.Abs(sum1-sum2)/N*2;
		var result = (mean*V,sigma*V);
		return result;
		}





}