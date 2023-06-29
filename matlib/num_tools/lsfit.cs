using System;
using static System.Math;
using static System.Console;
public static class lsfit{
	public static (vector,matrix) LS(vector x, vector y, vector dy, Func<double,double>[] fs){
		int n = x.size;
		int m = fs.Length;


		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0 ; i<n ; i++){
			b[i] = y[i]/dy[i];
			for(int j=0 ; j<m ; j++){
				A[i,j] = fs[j](x[i])/dy[i];
			}
		}

		(matrix Q, matrix R) = QRGS.decomp(A);

		vector c = QRGS.solve(Q,R,b);
		matrix S = QRGS.inverseATA(R);


	
	return (c,S);	
        }
	

}



