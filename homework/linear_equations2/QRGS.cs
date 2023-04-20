using System;
using static System.Console;
using static System.Math;
public static class QRGS{
	   public static void decomp(matrix A, matrix R){
		matrix Q = A.copy();
        int m = Q.size2;
		for (int i =0; i<m; i++){
			R[i,i]=Q[i].norm(); /* Q[i] points to the i−th columb */
			Q[i]/=R[i,i];
			for (int j=i+1; j<m; j++){
				R[ i , j ]=Q[ i ].dot(Q[j]);
				Q[j] -= Q[i]*R[i,j]; } }
	  
	  
	  
	   }



		// public static vector solve(matrix Q, matrix R, vector b){
		// 	matrix Q=A.copy(), R=new matrix(m,m);
		// 	for (int i=0;i<m;i++){
		// 		R[i,i]=Q[i].norm();
		// 		Q[i]/=R[i,i];
		// 		for (int j = i+1; j<m;j++){
		// 			R[i,j] = Q[i].dot(Q[j]);
		// 			Q[j]-=Q[i]*R[i,j];}
		// 		}
		// 	}

		


	    // public static double det(matrix R){ ... }
}
