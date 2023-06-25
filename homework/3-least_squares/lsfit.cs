using System;
using static System.Math;
using static System.Console;
public static class lsfit{
	public static (vector,matrix) LS(vector x, vector y, vector dy, Func<double,double>[] fs){
		int n = x.size;
		int m = fs.Length;
	
		// for(int i = 0;i<n;i++){
		// 	for(int k = 0;k<m;k++){
		// 	double d = dy[i];	
		// 	A[i,k]=f[k](x[i])/d;
		// 	}
		// b[i] = y[i]/dy[i];
		// }


		matrix A = new matrix(n,m);
		vector b = new vector(n);
		for(int i=0 ; i<n ; i++){
			b[i] = y[i]/dy[i];
			for(int j=0 ; j<m ; j++){
				A[i,j] = fs[j](x[i])/dy[i];
			}
		}

		//decomposing A=QR with QRGS.cs
		(matrix Q, matrix R) = QRGS.decomp(A);
		//solvingi with QRGS.cs
		vector c = QRGS.solve(Q,R,b);
		matrix RTR = R.T * R;
		R.print("R = ");
		RTR.print("RTR = ");
		// matrix S = QRGS.inverse(RTR, R); 
		matrix S = QRGS.inverseATA(R);

		S.print("S = ");

	
	return (c,S);	
        }
	

}



