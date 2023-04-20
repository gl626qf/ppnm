using System;
using static System.Console;
using static System.Math;



public static class main{


    
    // public static bool CheckUpperTriangular(Matrix A){
    //     int N = A.RowCount;
    //     for (int i = 1; i < N; i++){
    //         for (int j = 0; j < i; j++){
    //             if (A[i, j] != 0){
    //                 return false;
    //             }
    //         }
    //     }
    //     return true;
    //     return false;
    // }




    

    public static void Main(){

            WriteLine("------------TASK A------------"); // Maybe make it not hardcoded


            //random tall
            // var random = new Random(Guid.NewGuid().GetHashCode());
            var random = new Random();
            int random_n = random.Next(2,7);
            // Here we might implement + 1, so it is not quadratic
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
            

            //We need to check if Q**T * Q = 1
            matrix trans_check = Q.T * Q;
            trans_check.print("Q.T * Q = 1 check");
            
            // bool d_ = checkUpperTriangular(Q);
            





            




    }
}
