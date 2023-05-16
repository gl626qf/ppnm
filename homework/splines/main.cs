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

    // public static double linterpInteg(double[] x, double[] y, double z){

        
    // }


	// public static double linterpInteg(double[] x, double[] y, double z){
	// 	double sum = 0;
	// 	int index = binsearch(x, z);
	// 	for(int i=0;i<index;i++){
	// 		//calculate integral of interval
	// 		double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("seems wrong again...");
	// 		double dy=y[i+1]-y[i];
	// 		double a = dy/dx;
	// 		double b = y[i]-a*x[i];
	// 		double integral = (a/2)*(x[i+1]*x[i+1]-x[i]*x[i]) + b*dx;
	// 		sum += integral;
	// 		}
	// 	double last_y = linterp(x, y, z);
	// 	double last_x = z;
	// 	double last_dx = last_x-x[index];
	// 	double last_dy = last_y-y[index];
	// 	double last_a = last_dy/last_dx;
	// 	double last_b = y[index]-last_a*x[index];
	// 	double last_integral = (last_a/2)*(last_x*last_x-x[index]*x[index]) + last_b*last_dx;
	// 	sum += last_integral;
	// 	return sum;
	// 	}

}




// I NEED TO IMPLEMENT THE WRITING TO FILE!!!
public class main{
public static int Main(string[] args){



	string infile=null,outfile=null;
	foreach(var arg in args){
			var words=arg.Split(':');
				if(words[0]=="-input")infile=words[1];
				if(words[0]=="-output")outfile=words[1];
						}
	if( infile==null || outfile==null) {
			Error.WriteLine("wrong filename argument");
				return 1;
					}
	var instream =new System.IO.StreamReader(infile);
	var outstream=new System.IO.StreamWriter(outfile,append:false);
    
    outstream.WriteLine("The data points:");
	for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
            // WriteLine(line);
            var XY = line.Split(" ");
            // WriteLine(XY);
			double x = double.Parse(XY[0]);
            double y = double.Parse(XY[1]);
			outstream.WriteLine($"x = {x}, y = {y}");

			}

    outstream.WriteLine("The interpolated data");
    for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){    


            // double interpvalue = spline.linterp(x,y,z);
            // outstream.WriteLine($"");
        

    }
	instream.Close();
	outstream.Close();
	return 0;
}

}

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
