public static class QRGS{
	   public static void decomp(matrix a, matrix r){
		   matrix Q=A.copy(), R=new matrix(m,m);
		for (int i =0; i<m; i++){
			R[i,i]=Q[i].norm(); /* Q[i] points to the i−th columb */
			Q[i]/=R[i,i];
			for (int j=i+1; j<m; j++){
				R[ i , j ]=Q[ i ].dot(Q[j]) ;
				Q[j]−=Q[i]∗R[i,j]; } }
	  
	  
	  
	  
	  
	  
	   }
	      public static vector solve(matrix Q, matrix R, vector b){ ... }
	         public static double det(matrix R){ ... }
}
