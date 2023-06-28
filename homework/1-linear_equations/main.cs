using System;
using static System.Console;
using static System.Math;



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

                if(arg == "-AB"){
                                WriteLine("------------TASK A------------"); // Maybe make it not hardcoded



                                var random = new Random();
                                int random_n = random.Next(2,8);
                                int random_m = random.Next(2,random_n);
                                matrix random_a = matrix.randomMatrix(random_n, 2);

                                // WriteLine("\n \n");

                                WriteLine("----Decomp Testing----");


                                matrix A = random_a.copy();


                                A.print("This is A:");
                                //We use decomposition
                                (matrix Q, matrix R) = QRGS.decomp(A);
                                
                                //We check the different matrices after decomp
                                Q.print("This is Q after decomposition");
                                R.print("This is R after decomposition");


                                //We need to check that R is upper triangular
                                // WriteLine($"checkUpperTriangular(R)) is {checkUpperTriangular(R)}";


                                WriteLine($"Testing if R is upper triangular: {checkUpperTriangular(R)}");
                            
                                WriteLine($"Testing if Q.T * Q is equal to the identity matrix: {((Q.T)*Q).approx(matrix.id(random_m))}");
                                // R.print("Check that R is upper triangular, R = \n");

                                WriteLine($"Testing if Q * R is equal to the matrix A: {(Q*R).approx(A)}");


                                WriteLine($"QR = A: {A.approx(Q*R)}");


                                                    
                                

                                WriteLine("\n \n");
                                WriteLine("----Solve Testing----");
                                // Making square matrix
                                matrix random_square = new matrix(random_n, random_n);
                                for(int i=0;i<random_n;i++){
                                    for(int j=0;j<random_n;j++){
                                        random_square[i,j] = random.NextDouble();
                                    }
                                }



                                random_square.print("Random square matrix");


                                vector random_b = new vector(random_n);

                                for (int i=0; i<random_n;i++){
                                    random_b[i] = random.NextDouble();
                                }
                                random_b.print("Random vector of size b");


                                // Making square matrix
                                matrix A_square = random_square.copy();
                                // Making for later
                                matrix A2_square = random_square.copy();

                                // matrix R_square = new matrix(random_n, random_n);
                                vector b_square = random_b.copy();

                                // A_square.print("A before QR");
                                // R_square.print("R before QR");
                                
                                (matrix Q_square, matrix R_square) = QRGS.decomp(A_square);
                                
                                // Q_square.print("A after QR");
                                // R_square.print("R after QR");

                                //Now we need to solve 

                                vector x = QRGS.solve(Q_square, R_square, b_square);
                                x.print("Solution vector x");

                                //Checking Ax = b. Need to Convert the A matrix back by multiplying with R
                                vector Ax = (Q_square * R_square) * x;


                                // WriteLine("We see if Ax = b");
                                // Ax.print("Ax");
                                // b_square.print("b");
                                WriteLine($"Testing if Ax = b : {Ax.approx(b_square)}");




                                WriteLine("------------TASK B------------");

                                A2_square.print("Random square matrix: A");

                                // To test with later in the AB = I case
                                matrix A2_test = A2_square.copy();

                                (matrix Q2_square, matrix R2_square) = QRGS.decomp(A2_square);

                                matrix B = QRGS.inverse(Q2_square, R2_square);

                                B.print("The inverse matrix: B");

                                WriteLine($"Testing if A * B = I is: {((A2_test) * B).approx(matrix.id(A2_square.size1))}");


                }



                if(arg == "-time"){

                    // int ndim = 1;
                    
                    
                    // for(int i = 1; i < 20; i += 50){
                    //     var A = matrix.randomMatrix(i,i);
                    //     var (Q,R) = QRGS.decomp(A);
                    // }

                    


                }
        }
        


    }
}
