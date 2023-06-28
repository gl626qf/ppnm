using System;
using static System.Console;
using static System.Math;
using System.IO;
public class main{
    
    public static bool checkUpperTriangular(matrix A){
        int N = A.size1;
        for (int i = 1; i < N; i++){
            for (int j = 0; j < i; j++){
                if (A[i, j] != 0){
                    return false;
                }
            }
        }
        return true;
    }



	public static void Main(string[] args){

	
		
		foreach(var arg in args){
			if(arg == "-checkQR"){
				matrix A_ = matrix.randomMatrix(9,3);
				A_.print("A = ");
				(matrix Q, matrix R) = QRGS.decomp(A_);
				Q.print("Q = ");
				R.print("R = ");


				WriteLine($"Testing if Q.T * Q is equal to the identity matrix: {((Q.T)*Q).approx(matrix.id(Q.size2))}");

				WriteLine($"Testing if R is upper triangular. Test returns: {checkUpperTriangular(R)}");

				WriteLine("---Checking if inverse works---");
				matrix A_square = matrix.randomMatrix(8,8);
				matrix A_test = A_square.copy();
				A_square.print("Random square matrix: A");

				(matrix Q_square, matrix R_square) = QRGS.decomp(A_square);

				matrix B = QRGS.inverse(Q_square, R_square);

				B.print("The inverse matrix: B");


				WriteLine($"Testing if A * B = I is: {((A_test) * B).approx(matrix.id(A_square.size1))}");



				
			}

			if(arg == "-THX"){
		

				StreamWriter thxData = new StreamWriter("Out.thx.data",false);
				
				
				vector t = new vector(new double [] {1,2,3,4,6,9,10,13,15});
				vector y = new vector(new double [] {117,100,88,72,53,29.5,25.2,15.2,11.1});
				vector dy = new vector(new double [] {5,5,5,4,4,3,3,2,2});


				
				var fs = new Func<double,double>[] {z=> 1.0, z => z};

				vector lny = new vector(y.size);
				vector dlny = new vector(dy.size);
				for(int i = 0;i<y.size;i++){
					lny[i] = Log(y[i]);
					dlny[i] = dy[i]/y[i];
				}
				
				(vector c, matrix S) = lsfit.LS(t, lny, dlny, fs); 	
				WriteLine("The coefficients c, and the covariance matrix is given as: ");	
				c.print("c = ");
				S.print("Covariance matrix S = ");
				double lna = c[0]; double lna_err = Sqrt(S[0,0]);
				double a = Exp(lna); double a_err = Exp(lna_err);
				double lambda = -c[1]; double lambda_err = Sqrt(S[1,1]);


				WriteLine($"lambda = {lambda:f5} pm {lambda_err:f4}");
				WriteLine($"T_0.5 = {Log(2)/lambda:f2} pm {(Log(2)/Pow(lambda,2)*lambda_err):f2} days");
				WriteLine("Theoretical halflife 3.8235 days from wikipedia https://en.wikipedia.org/wiki/Radon-222");
				WriteLine("The calculated T_0.5 is agrees with the theoretical halflife");
				
				for(int i = 0; i<t.size;i++)
				{
						thxData.WriteLine($"{t[i]} {y[i]} {dy[i]}");
				}
				thxData.Close();


				// The fitting begins: -------------------------------------------------------------------------------
					
				StreamWriter thxFit = new StreamWriter("Out.thxFit.data",false);
				for(double i = 1.0/64;i<22;i+=1.0/64){
						double y_fit = a*Exp(-lambda*i);
						double y_fit_minus = (a-2*a_err)*Exp(-(lambda-2*lambda_err)*i);
						double y_fit_plus = (a+2*a_err)*Exp(-(lambda+2*lambda_err)*i);
						double y_fit_a_plus = (a+a_err)*Exp(-lambda*i);
						double y_fit_a_minus = (a-a_err)*Exp(-lambda*i);

						double y_fit_l_plus = a*Exp(-(lambda+lambda_err)*i);
						double y_fit_l_minus = a*Exp(-(lambda-lambda_err)*i);
						thxFit.WriteLine($"{i} {y_fit} {y_fit_minus} {y_fit_plus} {y_fit_a_minus} {y_fit_a_plus} {y_fit_l_minus} {y_fit_l_plus}");
						}
				thxFit.Close();
				WriteLine("Plot is viewed in thx.svg");




			}
			// if(arg == "-fitTHX"){




			

			// }
		
		} 
	}

}