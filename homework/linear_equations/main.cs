using System;
using static System.Console;
using static System.Math;

public static class main{

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
            
            matrix a = random_a.copy();
            matrix r = new matrix(random_m, random_m);

            a.print("This is A before decomposition");
            r.print("This is R before decomposition");


            //We use decomposition



            // QRGS.decomp(a, r);
            




    }
}
