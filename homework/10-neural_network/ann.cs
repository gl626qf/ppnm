using System;
using static System.Math;
using static System.Console;


public class ann{
	public int n;
	Func<double,double> f;
	public vector p;

	public ann(int n, Func<double,double > f){
		this.n = n;
		this.f = f;
		int nparams = 3*n; 
		p = new vector(nparams);	

	}
	public double a(int i) {return p[i];}
	public double b(int i) {return p[i+n];}
	public double w(int i) {return p[i+2*n];}



	public double dGaussWavelet(double x){
		double sum = 0;
		Func<double,double> df = z => Exp(-z*z)*(1-2*z*z);
		for(int i = 0; i<n;i++){
			sum += w(i) * df((x-a(i))/b(i))/b(i);
		} return sum;
	}


	public double ddfGaussianWavelet(double x){
		double sum = 0;
		Func<double,double> ddf = z => Exp(-z*z)*(-6*z+4*z*z*z);
		for(int i = 0; i<n;i++){
			sum +=w(i)*ddf((x-a(i))/b(i))/(b(i)*b(i));
		} return sum;
	}


	public double intGaussianWavelet(double x,double start){
		double sum = 0;
		Func<double,double> F = z => Exp(-z*z)*(-1.0/2);
		for(int i = 0; i<n;i++){
			sum +=w(i)*F((x-a(i))/b(i))*b(i);
			sum -=w(i)*F((start-a(i))/b(i))*b(i);
		} return sum;
	}
	
	public double response(double x){
		double F = 0;
		for(int i = 0; i < n; i++){
			double ai = a(i); 
			double bi = b(i);
			double wi = w(i);
			F += f((x-ai)/bi)*wi;}
		return F;}




	public void train(vector x, vector y){
		double xmin = x.min();
		double xmax = x.max();	
		for(int i = 0; i<p.size;i++){
			if(i<n) {p[i] = xmin + (xmax-xmin)*i/(n-1);}
			
			else p[i] = 1;
		}
	
		
		Func<vector, double> Cp = C => {
			p = C;
			double sum = 0;
			for(int i = 0; i< x.size; i++){
				sum += Pow(response(x[i])-y[i],2);
			}
		return sum/x.size; 
		};

		vector v = p;
		var nstep = qnewton.minimum(Cp, ref v, 1e-3);
		var result = v;
		}


	// public void trainDiff(vector x, vector y){

	// 	// C(p)=∫ab Φ[Fp(x)]² dx + α (Fp(c)-yc)² + β (Fp'(c)-y'c)² ,
	// 	double xmin = x.min();
	// 	double xmax = x.max();	
	// 	for(int i = 0; i<p.size;i++){
	// 		if(i<n) {p[i] = xmin + (xmax-xmin)*i/(n-1);}
			
	// 		else p[i] = 1;
	// 	}
	
		
	// 	Func<vector, double> Cp = C => {
	// 		p = C;
	// 		double sum = 0;
	// 		for(int i = 0; i< x.size; i++){
	// 			sum += Pow(response(x[i])-y[i],2);
	// 		}
	// 	return sum/x.size; 
	// 	};

	// 	vector v = p;
	// 	var nstep = qnewton.minimum(Cp, ref v, 1e-3);
	// 	var result = v;
	// 	}


}
