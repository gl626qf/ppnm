using System;
using static System.Console;
using static System.Math;



public static class main{


    

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

    } //Main
} //main
