using System;
using static System.Console;
using static System.Math;
// using static jacobi;



public static class main{



    

    public static void Main(){

            WriteLine("------------TASK A------------"); // Maybe make it not hardcoded


            // jacobiRotate.timesJ()

            //We make the symmetric matrix A:
            // var random = new Random();
            // int random_n = random.Next(3,8);
            // int random_m = random.Next(3,random_n);
            // int random_m = random.Next(2,random_n);
            // Here the matrix library is used 
            // matrix random_a = new matrix(random_n + 1, random_n + 1);
            // for(int i=0;i<random_n;i++){
            //     for(int j=0;j<i;j++){
            //         double value = random.NextDouble();

            //         // Here I mirror the value to get the off-diagonal
            //         random_a[i,j] = value;
            //         random_a[j,i] = value;
            //     }
            // }
            // for (int i = 0; i < random_n; i++)
            // {
            //     random_a[i,i] = random.NextDouble();
            // }
    
            var random = new Random();
            int random_n = random.Next(2,10);
            // WriteLine(random_n);
            // int random_n = 8;
            matrix A_square = new matrix(random_n, random_n);
            for(int i=0;i<random_n;i++){
                for(int j=i;j<random_n;j++){
                    A_square[i,j] = random.Next(1,100);
                    A_square[j,i] = A_square[i,j];
                }
            }
            A_square.print("random square matrix A:");

            // Creating the matrix
            matrix A = A_square.copy();



            // WriteLine("-----Part 1-----");
            // A.print("Symmetric matrix A");

            // jacobi.timesJ(A, random_n, random_n, 1.8);


            // A.print("After rotate timesJ");

            // WriteLine("-----Part 2-----");
            // Here it could be smart to just make the random matrix to a method in matrix.dll
            // jacobi.Jtimes(A, 4, 4, 1.8);


            // A.print("After rotate Jtimes");

            // WriteLine("-----Part 3-----");


            //Now the 3. job in exercise A, is to use the cyclic method

            (matrix D, vector w, matrix V) = jacobi.cyclic(A);

            V.print("matrix V:");
            // A.print("matrix A:");
            w.print("vector w");




            WriteLine("-------------------------");
            matrix check1 = V * D * V.T;
            // WriteLine($"Eigen value decomp if (V.T * A * V) = D:");
            check1.print($"Eigen value decomp: (V.T * A * V) = D. Matrix D");      
            // D.print("Matrix D:");        


            matrix check2 = V.T * A * V;
            WriteLine($"Testing if (V.T * A * V) = D: {check2.approx(D)}");           


            matrix check3 = V * D * V.T;
            WriteLine($"Testing if (V * D * V.T) = A: {check3.approx(A)}");            



            

            matrix check4 = V.T * V;
            WriteLine($"Testing if (V.T * V) = I: {check4.approx(matrix.id(A.size1))}");
            // Now the testing comes:
            matrix check5 = V * V.T;
            WriteLine($"Testing if (V * V.T) = I: {check5.approx(matrix.id(A.size1))}");

            




            // EVD.evd(A);
            // A.print("EVD on A");

            // V.print("V");
            // A.print("A");






            






    }

}