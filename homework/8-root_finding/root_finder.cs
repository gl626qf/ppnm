using System;
using static System.Console;
using static System.Math;

public static class root_finder{

	public static vector newtonMethod(Func<vector, vector> f, vector x, double epsilon = 1e-9){
		vector fx=f(x),z,fz;	
		vector deltaX, dx;
		dx = null;

		int n = x.size;
		vector df = new vector(n);
		matrix A = new matrix(n,n);
		double Delta = Pow(2,-26);	
		
		do{
			if(dx == null) dx = x.map(t => Abs(t)*Delta);
			for (int k = 0;k<n; k++){
				x[k] += dx[k];	
				df = (f(x)-fx);
				for(int i = 0; i<n; i++){
					A[i,k] = df[i]/dx[k];
				}
				x[k]-=dx[k];
				}
			(matrix Q, matrix R) = QRGS.decomp(A);
			deltaX = QRGS.solve(Q,R,-1.0*f(x));
			double lambda = 2;
			//backtracing linesearch
			do {
				lambda /= 2.0;
				z = x + lambda * deltaX;
				fz = f(z);
			}while(fz.norm() > (1-lambda/2.0)*fx.norm() && lambda > 1.0/1024);
			x = z;
			fx = fz;
		}while(fx.norm() > epsilon);
		return x;

	}
}
