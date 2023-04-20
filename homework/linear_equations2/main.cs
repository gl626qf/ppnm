using System;
using static System.Console;
using static System.Math;



public static class main{


    
    // public static bool CheckUpperTriangular(matrix A){
    //     int N = A.size1;
    //     for (int i = 1; i < N; i++){
    //         for (int j = 0; j < i; j++){
    //             if (A[i, j] != 0){
    //                 return false;
    //             }
    //         }
    //     }
    //     return true;
    // }




    

    public static void Main(){

            WriteLine("------------TASK A------------"); // Maybe make it not hardcoded


            //Making make the Next to Nextdouble

            //random tall
            // var random = new Random(Guid.NewGuid().GetHashCode());
            var random = new Random();
            int random_n = random.Next(2,7);
            int random_m = random.Next(2,random_n);
            // Here the matrix library is used 
            matrix random_a = new matrix(random_n, random_m);
            for(int i=0;i<random_n;i++){
                for(int j=0;j<random_m;j++){
                    random_a[i,j] = random.NextDouble();
                }
            }
            
            matrix Q = random_a.copy();
            matrix R = new matrix(random_m, random_m);

            Q.print("This is Q before decomposition");
            R.print("This is R before decomposition");


            //We use decomposition
            QRGS.decomp(Q, R);
            
            //We check the different matrices after decomp
            Q.print("This is Q after decomposition");
            R.print("This is R after decomposition");


            //We need to check that R is upper triangular

            // int N = R.size1;
            // WriteLine(N);
            // for (int i = 1; i < N; i++){
            //     for (int j = 0; j < i; j++){
            //         if (R[i, j] != 0){
            //             WriteLine("yes");
            //         }
            //     }
            // }

            // checkUpperTriangular(Q);
            

            //We need to check if Q**T * Q = 1
            matrix trans_check = Q.T * Q;
            trans_check.print("Q.T * Q = 1 check");
            
            // bool d_ = checkUpperTriangular(Q);
            



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

            matrix A_square = random_square.copy();

            matrix R_square = new matrix(random_n, random_n);
            vector b_square = random_b.copy();

            A_square.print("A before QR");
            R_square.print("R before QR");
            
            QRGS.decomp(A_square,R_square);
            
            A_square.print("A after QR");
            R_square.print("R after QR");
            matrix trans_check_square = A_square.T * A_square;

            // We check
            trans_check_square.print("A.T * A = 1 check");


            //Now we need to solve 

            vector x = QRGS.solve(A_square, R_square, b_square);
            x.print("Vector x");

            //Checking Ax = b. Need to Convert the A matrix back by multiplying with R
            vector Ax = (A_square * R_square) * x;


            WriteLine("We see if Ax = b");
            Ax.print("Ax");
            b_square.print("b");
            WriteLine("We can see they are equal");
            // Need to use approx to see if close !!!!!! 



            WriteLine("------------TASK B------------");
        


    }
}
