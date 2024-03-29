using System;
using static System.Console;
using static System.Math;
public class QRGS{

		public static (matrix, matrix) decomp(matrix A){ // a: (nxm)
			matrix Q = A.copy();
			int m = A.size2;
			matrix R = new matrix(m,m);
			for(int i=0; i<m; i++){
				R[i,i] = Q[i].norm();
				Q[i]/= R[i,i];
				for(int j=i+1; j<m; j++){
					R[i,j] = Q[i].dot(Q[j]);
					Q[j] -= Q[i]*R[i,j];
				}
			}
			
			return (Q,R);
		}


		public static vector solve(matrix Q, matrix R, vector b){
			vector x = Q.T*b;
			for(int i=x.size-1;i>=0;i--){
				double sum=0;
				for(int k=i+1;k<x.size;k++) sum = sum + R[i,k]*x[k];
				x[i] = (x[i]-sum)/R[i,i];
			}
			return x;
		}
		
		public static matrix inverse(matrix A, matrix R){
			matrix Q_inv = new matrix(A.size1, A.size2);
			for(int i=0;i<A.size2;i++){
				vector ei = new vector(A.size2);
				ei[i] = 1;
				Q_inv[i] = solve(A, R, ei);
			}
			return Q_inv;

		}



			// int n = A.size1;
			// vector ei = new vector(n);
			// matrix invA = new matrix(n,n);
			// ei[0] = 1;
			// if((Q == null) || (R == null)){
			// 	(Q, R) = decomp(A, R);
			// }
			// vector xi = solve(Q,R,ei);
			// invA[0] = xi;
			// for(int i=1; i<n; i++){
			// 	ei[i-1] = 0;
			// 	ei[i] = 1;
			// 	xi = solve(Q,R,ei);
			// 	invA[i] = xi;
			// }
			// return invA;
		// }

		
		// public static matrix inverse(matrix A, matrix Q = null, matrix R = null){
		// 	//(int n, int m) = (A.size1, A.size2);
		// 	//Debug.Assert(n==m,string.Format("Only square matrices are invertible. A has dimension ({0},{1})",n,m));
		// 	//WriteLine($"n = {n}, m = {m}");

		// 	int n = A.size1;
		// 	matrix invA = new matrix(n,n);
		// 	vector ei = new vector(n);
		// 	ei[0] = 1;
			
		// 	if((Q == null) || (R == null)){
		// 		(Q, R) = decomp(A);
		// 	}
		// 	vector xi = solve(Q,R,ei);
		// 	invA[0] = xi;
		// 	for(int i=1; i<n; i++){
		// 		ei[i-1] = 0;
		// 		ei[i] = 1;
		// 		xi = solve(Q,R,ei);
		// 		invA[i] = xi;
		// 	}
		// 	return invA;
		// }


	    // public static double det(matrix R){ ... }
}
