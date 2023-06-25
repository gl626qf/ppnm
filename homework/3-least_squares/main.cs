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

		// // definding some data and fitting it. Fitting results written to outPartA.txt
		// StreamWriter outPartB = new StreamWriter("OutPartB.txt", false);
		// StreamWriter dataPartABC = new StreamWriter("DataPartABC.data",false);



		// vector dy = new vector(new double [] {5,5,5,4,4,3,3,2,2});
		// var fs = new Func<double,double>[] {z=> 1.0, z => z};

		// vector lny = new vector(y.size);
		// vector dlny = new vector(dy.size);
		// for(int i = 0;i<y.size;i++){
		// 	lny[i] = Log(y[i]);
		// 	dlny[i] = dy[i]/y[i];
		// }
		
		// var (c,S) = lsfit.LS(t, lny, dlny, fs); 		
		// c.print("c = ");
		// S.print("covariance matrix S = ");
		// double lna = c[0]; double lna_err = Sqrt(S[0,0]);
		// double a = Exp(lna); double a_err = Exp(lna_err);
		// double lambda = -c[1]; double lambda_err = Sqrt(S[1,1]);
		// outPartB.WriteLine("Reults with calculated uncertanities from the covariance matrix (printed in Out.txt)");
		// outPartB.WriteLine($"lambda = {lambda:f5} pm {lambda_err:f4}");
		// outPartB.WriteLine($"T_0.5 = {Log(2)/lambda:f2} pm {(Log(2)/Pow(lambda,2)*lambda_err):f2} days");
		// outPartB.WriteLine("Theoretical is found to be 3.8215 days from wikipedia https://en.wikipedia.org/wiki/Radon-222. So the found halft life time does agree with modern value within two uncertainty");
		// outPartB.Close();
		// //data and generate fit data
		// for(int i = 0; i<t.size;i++){
		// 	dataPartABC.WriteLine($"{t[i]} {y[i]} {dy[i]}");
		// 	}
		// dataPartABC.Close();
		
		// StreamWriter dataPartABC_fit = new StreamWriter("DataPartABC_fit.data",false);
		// for(double i = 1.0/64;i<22;i+=1.0/64){
		// 	double y_fit = a*Exp(-lambda*i);
		// 	double y_fit_minus = (a-2*a_err)*Exp(-(lambda-2*lambda_err)*i);
		// 	double y_fit_plus = (a+2*a_err)*Exp(-(lambda+2*lambda_err)*i);
		// 	double y_fit_a_plus = (a+a_err)*Exp(-lambda*i);
		// 	double y_fit_a_minus = (a-a_err)*Exp(-lambda*i);

		// 	double y_fit_l_plus = a*Exp(-(lambda+lambda_err)*i);
		// 	double y_fit_l_minus = a*Exp(-(lambda-lambda_err)*i);
		// 	dataPartABC_fit.WriteLine($"{i} {y_fit} {y_fit_minus} {y_fit_plus} {y_fit_a_minus} {y_fit_a_plus} {y_fit_l_minus} {y_fit_l_plus}");
		// 	}
		// dataPartABC_fit.Close();


		// foreach(var arg in args){
		// 	if(var arg == "-checkQR"){
		// 		// WriteLine("QR-deccomp for tall matrices");
		// 		// var A = matrix.randomMatrix(8,3);
		// 		// A.print("A = ");
		// 		// WriteLine($" n ={A.size1},m = {A.size2}");	
		// 		// var (Q,R) = QRGS.decomp(A);
		// 		// Q.print("Q = ");
		// 		// R.print("R = ");
		// 		// var test1 = Q.T*Q;
		// 		// test1.print(" Q^T*Q = 1 ? =>");
		// 		// WriteLine("It is shown that QR decomposition works due to R is m x m upper triangular and Q is n x m and Q^T*Q=1");


		// 	}
		// }
	
		
		foreach(var arg in args){
			if(arg == "-checkQR"){
				matrix A_ = matrix.randomMatrix(8,3);
				A_.print("A = ");
				(matrix Q, matrix R) = QRGS.decomp(A_);
				Q.print("Q = ");
				R.print("R = ");

				// ((Q.T)*Q).print();
				// matrix.id(Q.size1).print();
				// WriteLine("size : " + Q.size1);
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
				c.print("c = ");
				S.print("covariance matrix S = ");
				double lna = c[0]; double lna_err = Sqrt(S[0,0]);
				double a = Exp(lna); double a_err = Exp(lna_err);
				double lambda = -c[1]; double lambda_err = Sqrt(S[1,1]);
				WriteLine($"lambda = {lambda:f5} pm {lambda_err:f4}");
				WriteLine($"T_0.5 = {Log(2)/lambda:f2} pm {(Log(2)/Pow(lambda,2)*lambda_err):f2} days");
				WriteLine("Theoretical is found to be 3.8215 days from wikipedia https://en.wikipedia.org/wiki/Radon-222");




			}
		
		} 
	}

}