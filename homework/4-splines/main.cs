using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;




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






	public static double linterpInteg(double[] x, double[] y, double z){
		int i = binsearch.binsearch_(x,z);
		double sum = 0;
		for(int k = 0; k<i; k++){
			double dy = y[k+1]-y[k];
			double dx = x[k+1]-x[k];
			sum += y[k]*dx + 1.0/2*dy*dx;
		}
		double dxi = x[i+1]-x[i];
		double dyi = y[i+1]-y[i];
		sum += y[i]*(z-x[i])+1.0/2*(dyi/dxi)*(z-x[i])*(z-x[i]);

		return sum;
		}

}



public class main{

	static void Main(string[] args){
		// Set data points
		double[] xs = {-2, -1.55555556, -1.11111111, -0.66666667, -0.22222222,
        0.22222222,  0.66666667,  1.11111111,  1.55555556,  2};
        double[] ys = {0.01831564, 0.08894358, 0.29096046, 0.64118039, 0.95181678,
       0.95181678, 0.64118039, 0.29096046, 0.08894358, 0.01831564};
		foreach(var arg in args){
			if(arg == "-data"){
				int l = xs.Length;
				for(int i=0;i<l;i++){
					WriteLine($"{xs[i]} {ys[i]}");
				}
			}
			if(arg == "-interpolate"){
    				for(double z=xs[0];z<=xs[xs.Length-1];z+=1.0/10.0){
					double interpValue = spline.linterp(xs, ys, z);
    				WriteLine($"{z} {interpValue}");
				}
			}	
			if(arg == "-integrate"){
				for(double z=xs[0];z<=xs[xs.Length-1];z+=1.0/10){
                         	    //    WriteLine($"z = {z}, value = {spline.linterInteg(xs, ys, z)}");
								double intergralValue = spline.linterpInteg(xs,ys,z);
								// WriteLine(intergralValue);
							    WriteLine($"{z} {intergralValue}");
                        	}	
               		}


		}
		

	}
}



// public class main
// {
//     public static int Main(string[] args)
//     {
//         string infile = null, outfile = null;
//         List<double> xs = new List<double>();
//         List<double> ys = new List<double>();


//         foreach (var arg in args)
//         {
//             var words = arg.Split(':');
//             if (words[0] == "-input")
//                 infile = words[1];
//             if (words[0] == "-output")
//                 outfile = words[1];
//         }

//         if (infile == null || outfile == null)
//         {
//             Console.Error.WriteLine("wrong filename argument");
//             return 1;
//         }

//         var instream = new StreamReader(infile);
//         var outstream = new StreamWriter(outfile, append: false);

//         foreach (var arg in args)
//         {
//             if (arg == "-data")
//             {
//                 outstream.WriteLine("The data points:");

//                 string line;
//                 while ((line = instream.ReadLine()) != null)
//                 {
//                     var XY = line.Split(" ");
//                     if (XY.Length == 2 && double.TryParse(XY[0], out double x) && double.TryParse(XY[1], out double y))
//                     {
//                         xs.Add(x);
//                         ys.Add(y);
//                         outstream.WriteLine($"x = {x}, y = {y}");
//                     }
//                 }
//             }

//             if (arg == "-interpolate")
//             {
//                 outstream.WriteLine("The interpolated data");
//                 for (int i = 0; i < xs.Count; i++)
//                 {
//                     double x = xs[i];
//                     double y = ys[i];

//                     // Perform interpolation and write the results
//                     for (double z = xs[0]; z <= xs[xs.Count - 1]; z += 1.0 / 10.0)
//                     {
//                         double interpValue = spline.linterp(xs.ToArray(), ys.ToArray(), z);
//                         outstream.WriteLine($"{z} {interpValue}");
//                     }
//                 }
//         }

//         instream.Close();
//         outstream.Close();
//         return 0;
//     }
// }

// }




// I NEED TO IMPLEMENT THE WRITING TO FILE!!!
// public class main{
// public static int Main(string[] args){



// 	string infile=null,outfile=null;
// 	foreach(var arg in args){
// 			var words=arg.Split(':');
// 				if(words[0]=="-input")infile=words[1];
// 				if(words[0]=="-output")outfile=words[1];
// 						}
// 	if( infile==null || outfile==null) {
// 			Error.WriteLine("wrong filename argument");
// 				return 1;
// 					}
// 	var instream =new System.IO.StreamReader(infile);
// 	var outstream=new System.IO.StreamWriter(outfile,append:false);
    

//     foreach(var arg in args){

//         if(arg == "-data"){
//             outstream.WriteLine("The data points:");
//             for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
//                     // WriteLine(line);
//                     var XY = line.Split(" ");
//                     // WriteLine(XY);
//                     double x = double.Parse(XY[0]);
//                     double y = double.Parse(XY[1]);
//                     outstream.WriteLine($"x = {x}, y = {y}");

//                     }
//         }

        
//         if(arg == "-interpolate"){
//         outstream.WriteLine("The interpolated data");
//         for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){    
//                     var XY = line.Split(" ");
//                     // WriteLine(XY);
//                     double x = double.Parse(XY[0]);
//                     double y = double.Parse(XY[1]);

//                 // for(double z=x[0];z<=x[x.Length-1];z+=1.0/10.0){
// 				// 	double interpValue = spline.linterp(x, y, z);
//     			// 	// outstream.WriteLine($"{z} {interpValue}");
//                 // }



//                 for(int i = 0;i<N;i++){/*genereates N z values and makes lineterp for them with x and y*/
//                     double z = x + i*(x-x)/(N-1);
//         }


            

//                 }
//         }
//     instream.Close();
// 	outstream.Close();
// 	return 0;
//     } //foreach

// }
// }

