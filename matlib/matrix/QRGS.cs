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
		
		// public static matrix inverse(matrix A){
		// 	matrix R = new matrix(A.size1, A.size2);
		// 	matrix Q_inv = new matrix(A.size1, A.size2);
		// 	for(int i=0;i<A.size2;i++){
		// 		vector ei = new vector(A.size2);
		// 		ei[i] = 1;
		// 		Q_inv[i] = solve(A, R, ei);
		// 	}
		// 	return Q_inv;

		// }
		public static matrix inverse(matrix A, matrix R){
			matrix Q_inv = new matrix(A.size1, A.size2);
			for(int i=0;i<A.size2;i++){
				vector ei = new vector(A.size2);
				ei[i] = 1;
				Q_inv[i] = solve(A, R, ei);
			}
			return Q_inv;

		}



		public static matrix inverseATA(matrix A_){
			matrix ATA = A_.T*A_;
			int n = ATA.size1;
			var I = new matrix(n,n);
			I.set_identity();
			(matrix Q_, matrix R_) = decomp(ATA);
			var invB = new matrix(n,n);
			for(int i=0;i<n;i++){
				invB[i] = solve(Q_, R_, I[i]);
			}
			return invB;
	}
}
