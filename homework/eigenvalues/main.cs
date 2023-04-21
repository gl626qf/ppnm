using System;
using static System.Console;
using static System.Math;
using static jacobiRotate;



public static class main{



    

    public static void Main(){

            WriteLine("------------TASK A------------"); // Maybe make it not hardcoded


            // jacobiRotate.timesJ()

            //We make the symmetric matrix A:
            var random = new Random();
            int random_n = random.Next(2,10);
            // int random_m = random.Next(2,random_n);
            // Here the matrix library is used 
            matrix random_a = new matrix(random_n, random_n);
            for(int i=0;i<random_n;i++){
                for(int j=0;j<i;j++){
                    double value = random.NextDouble();

                    // Here I mirror the value to get the off-diagonal
                    random_a[i,j] = value;
                    random_a[j,i] = value;
                }
            }
            for (int i = 0; i < random_n; i++)
            {
                random_a[i,i] = random.NextDouble();
            }

            matrix A = random_a.copy();

            A.print("Symmetric matrix A");

            // jacobiRotate.timesJ(A, 4, 4, 1.8);


            // A.print("After rotate timesJ");


            // Here it could be smart to just make the random matrix to a method in matrix.dll
            // jacobiRotate.Jtimes(A, 4, 4, 1.8);


            A.print("After rotate Jtimes");


            //Now the 3. job in exercise A, is to use the cyclic method

            jacobiRotate.cyclic(A);

            A.print("cyclic method on A");



            






    }

}