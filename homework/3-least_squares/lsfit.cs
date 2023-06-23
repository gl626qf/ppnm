// using System;
// using static System.Console;


// namespace linalg{
// public static class LS{
// 	public static (vector, matrix) lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
// 		int n = x.size;
// 		int m = fs.Length;
// 		matrix A = new matrix(n,m);
// 		vector b = new vector(n);

// 		for(int i=0 ; i<n ; i++){
// 			b[i] = y[i]/dy[i];
// 			for(int j=0 ; j<m ; j++){
// 				A[i,j] = fs[j](x[i])/dy[i];
// 			}
// 		}
//         // matrix R = new matrix(n,m);
//         // WriteLine(R);
// 		(matrix Q, matrix R) = QRGS.decomp(A);
//         WriteLine(Q);
// 		vector c = QRGS.solve(Q,R,b);
//         matrix S = Q.copy();
// 		// matrix ATA = (A.T)*A;
// 		// matrix S = QRGS.inverse(ATA);
// 		return (c,S);
// 	}
// }
// }

using System;
using static System.Math;
using static System.Console;
public static class lsfit{
	public static (vector,matrix) LS(vector x, vector y, vector dy, Func<double,double>[] f){
		int n = x.size;
		int m = f.Length;
		//makes matrix A with Aik=fk(xi)/dyi and bi =yi/dyi
		matrix A = new matrix(n,m);
		vector b = new vector(n);
	
		for(int i = 0;i<n;i++){
			for(int k = 0;k<m;k++){
			double d = dy[i];	
			A[i,k]=f[k](x[i])/d;
			}
		b[i] = y[i]/dy[i];
		}

		//decomposing A=QR with QRGS.cs
		var (Q,R) = QRGS.decomp(A);
		//solvingi with QRGS.cs
		vector c = QRGS.solve(Q,R,b);
		matrix S = QRGS.inverse(Q); //finds (R^TR^)-1
	
	return (c,S);	
        }
	

}



// using System;
// public static partial class matlib{

// public static (vector,matrix) lsfit(
// 	Func<double,double>[] fs, vector x, vector y, vector dy){
// 	int n = x.size, m=fs.Length;
// 	var A = new matrix(n,m);
// 	var b = new vector(n);
// 	for(int i=0;i<n;i++){
// 		b[i]=y[i]/dy[i];
// 		for(int k=0;k<m;k++)A[i,k]=fs[k](x[i])/dy[i];
// 		}
// 	var qra = new GSQR(A);
// 	vector c = qra.solve(b);
// 	matrix invA = qra.pinverse();
// 	matrix S = invA*invA.T;
// //	var invR = (new GSQR(qra.R)).inverse();
// //	var S = invR*invR.T;
// 	return (c,S);
// 	}//lsfit

// }//class