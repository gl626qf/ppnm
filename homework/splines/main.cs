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



public class main{

	static void Main(string[] args){
		double[] xs = {1,3,4,7,9,12};
        double[] ys = {1,3,6,10,10,9};
		foreach(var arg in args){
			if(arg == "-points"){
				int l = xs.Length;
				for(int i=0;i<l;i++){
					WriteLine($"{xs[i]} {ys[i]}");
				}
			}
			if(arg == "-interpolate"){
				int l = xs.Length;
    				for(double z=xs[0];z<=xs[xs.Length-1];z+=1.0/10.0){
					double interpValue = spline.linterp(xs, ys, z);
    					WriteLine($"{z} {interpValue}");
				}
			}	
		// 	if(arg == "integral"){
        //                         int l = xs.Length;
		// 		for(double z=xs[0];z<=xs[xs.Length-1];z+=1.0/10){
        //                  	       WriteLine($"{z} {spline.linterpInteg(xs, ys, z)}");
        //                 	}	
        //        		}
		// }
        }

	}//Main
}//main




// public static class main{

//     public static void Main(){

//             WriteLine("------------TASK A------------"); // Maybe make it not hardcoded


//             //Making make the Next to Nextdouble

//             //random tall
//             // var random = new Random(Guid.NewGuid().GetHashCode());
//             // var random = new Random();
//             // int random_n = random.Next(2,7);
//             // int random_m = random.Next(2,random_n);
//             // Here the matrix library is used 






            




//             WriteLine("------------TASK B------------");
        


//     }
// }
