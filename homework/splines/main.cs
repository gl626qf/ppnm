using System;
using static System.Console;
using static System.Math;




public class binsearch{
    public static int binsearch_(double[] x, double z)
        {/* locates the interval for z by bisection */ 
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
        }

}




public class spline{
    public static double linterp(double[] x, double[] y, double z){
            int i=binsearch.binsearch_(x,z);
            double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
            double dy=y[i+1]-y[i];
            return y[i]+dy/dx*(z-x[i]);
        }

}






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




            




            WriteLine("------------TASK B------------");
        


    }
}
