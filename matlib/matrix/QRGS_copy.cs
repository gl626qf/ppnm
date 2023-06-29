using System;

public class QRGS_copy{
public static (matrix, matrix) dec(matrix A){/* decomposition*/
                var m = A.size2;
                var Q = A.copy();
           	var R = new matrix(m,m);
                for (int i = 0; i<m;i++){
                        R[i,i] = Q[i].norm();
                        Q[i] /= R[i,i]; //qi = ai/Rii
                        for (int j = i+1;j<m;j++){
                                R[i,j]=Q[i].dot(Q[j]); //Rij = qi*aj
                                Q[j] -= Q[i]*R[i,j];
                        }
                }

                return (Q,R);

}//dec
public static vector solve(matrix Q, matrix R, vector b){/* soling equationQRx=b given Q and R from dec */
                var c = Q.T*b;
                var U = R;
                for (int i =c.size - 1; i >= 0;i--){
                        double sum = 0;
                        for(int k=i+1;k<c.size; k++) sum+=U[i,k]*c[k];
                        c[i]=(c[i]-sum)/U[i,i];
                }
        return c;
}//solve

public static matrix inverse(matrix Q, matrix R){/* inverse of A (symmetric) by using GS QR factorization, using lineq.pdf (46)*/
	var I = new matrix(Q.size1,Q.size2);
	I.set_identity(); //makes identity matrix from B dimensions
	var B = new matrix(Q.size1,Q.size2); // empyt matrix to put in inverse A
	for(int i=0;i<Q.size1;i++){
		B[i] = solve(Q,R,I[i]); //solves Axi=ei i times
	}
	return B;
} //inverse	
public static matrix inverse_of_ATA(matrix A){/*inverse of A^TA*/
	var B = A.T*A;
	int n = B.size1;
	var I = new matrix(n,n);
	I.set_identity();
	var (Q,R) = dec(B);
	var invB = new matrix(n,n);
	for(int i=0;i<n;i++){
		invB[i] = solve(Q,R,I[i]);
	}
	return invB;
}//inverse A
}//class QRGS
