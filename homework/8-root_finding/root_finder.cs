using System;
using static System.Console;
using static System.Math;

public static class root_finder{

	public static vector newton(Func<vector, vector> f, vector x, double epsi = 1e-7){
		vector fx=f(x),z,fz;	
		vector Deltax, dx;
		dx = null;
		int n = x.size;
		var df = new vector(n);
		matrix J = new matrix(n,n);
		double Delta = Pow(2,-26);	
		
		do{	
			//Calculate the Jacobian matrix J
			if(dx == null) dx = x.map(t => Abs(t)*Delta);
			for (int k = 0;k<n; k++){
				x[k] += dx[k];	
////				WriteLine($"{x[k]} xk =");
				df = (f(x)-fx);
				for(int i = 0; i<n; i++){
					J[i,k] = df[i]/dx[k];
				}//for loop 
				x[k]-=dx[k];
				}//forloop
			var (Q,R) = QRGS.dec(J);
			Deltax = QRGS.solve(Q,R,-1.0*f(x));
			double lambda = 2;
			do { //backtracing linesearch
				lambda /= 2.0;
				z = x + lambda*Deltax;
				fz = f(z);
			}while(fz.norm() > (1-lambda/2.0)*fx.norm() && lambda > 1.0/1024);
			x = z;
			fx = fz;
		
		}while(fx.norm() > epsi);
		return x;

	}//newton
}//class
