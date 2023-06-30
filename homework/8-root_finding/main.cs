
using System;
using static System.Console;
using static System.Math;
using System.IO;




public class func{

public static double hydrogen(double E, double r, double rmin=1e-5, double acc = 0.1, double eps = 0.1){
	if(r<rmin) return r-r*r;
	Func<double,vector,vector> hydrogen0 = (x,y) => new vector (y[1],2*(-1/x-E)*y[0]);
	
	vector ymin = new vector(rmin-rmin*rmin,1-2*rmin);


 	var xs = new genlist<double>();
        var ys = new genlist<vector>();
        var ymax = runge_kutta.driverImproved(hydrogen0, rmin, ymin, r, xs, ys,0.01,acc,eps);

	return ymax[0];	
}

}



public static class main{



	public static void Main(string[] args){
		
		foreach(var arg in args){
			if(arg == "-A"){
					WriteLine("------------TASK A-----------------");
					WriteLine(" ----First test equation: x**3 equation----- ");
					Func<vector,vector> f = x => new vector (x[0]*x[0]*x[0]);
					vector x0 = new vector(1);
					x0[0] = 0.1;
					WriteLine("Given funciton: f(x)=x**3 # ");
					WriteLine($"Initial vector : {x0[0]}\n");
					var result1 = root_finder.newtonMethod(f,x0);
					result1.print("x_root = ");
					f(result1).print("f(roots) = ");
					WriteLine(" The correct result for roots is x = 0");
			}
			if(arg == "-B"){
					WriteLine("----Second test equation: ----");
					Func<vector, vector> g = x => new vector(1 / (1 + Exp(-x[0] + 2))- 0.5);
					vector x2 = new vector(1);
					x2[0] = -0.2;
					WriteLine(" # Function to find root f(x) = 1 / (1 + Exp(-x[0] + 2))- 0.5 # ");
					WriteLine($"Initial vector : {x2[0]}\n");
					var result2 = root_finder.newtonMethod(g,x2);
					result2.print("x_root = ");
					g(result2).print("f(roots) = ");
					WriteLine(" The correct result for roots is x_root = 2");
			}
			if(arg == "-rosenbrock"){
				
				WriteLine("----Extremum for Rosenbrock's vally function----");
				Func<vector,vector> h = x => new vector ((-2*(1 - x[0]) -2*x[0]*200*(x[1] - x[0]*x[0])), (200*(x[1] - x[0]*x[0])));
				vector x3 = new vector(2.5,4.0);
				WriteLine("Compare the numerical and analytical roots of Rosenbrock's valley function.");
				WriteLine("Rosenbrock's vally function : f(x,y)=(1-x)^2+100(y-x^2)^2");
				WriteLine("Gradient analytical: (-2*(1-x)-400*x*(y-x^2),200*(y-x^2))"); 
				WriteLine($"Initial vector : {x3[0]}, {x3[1]}");
				var result3 = root_finder.newtonMethod(h,x3);
				result3.print("x_roots = ");
				h(result3).print("f(roots) = ");
				WriteLine("The correct result for roots is x = 1, y = 1");
				WriteLine("The solutions are the same.");
				WriteLine("------------------------------------------");
				WriteLine("\n");
			}


			if(arg == "-hydrogen"){

				double rmax = 15; 
				double rmin = 1e-3;
				double acc = 1e-3; 
				double eps = 1e-3;


				StreamWriter energy0Data= new StreamWriter("energy0.data", false);

				Func<vector,vector> ME = (vector v) => {
					double E=v[0];
					double fMax = func.hydrogen(E, rmax, rmin, acc, eps);
					return new vector (fMax);};

				vector vstart = new vector(-1.0);
				vector E0 = root_finder.newtonMethod(ME,vstart);
				double energy0 = E0[0];
				for (double r=0; r<rmax; r+=rmax/128){
						double fR = func.hydrogen(energy0,r);
						double exactFr = r*Exp(-r);
						energy0Data.WriteLine($"{r} {fR} {exactFr}");
					}
				WriteLine("---------------TASK B-----------------");
				WriteLine("Finding the ground state for hydrogen with rmax = 15");
				WriteLine($"The ground state energy is found with Newton's method to be: E0 = {energy0}");
				WriteLine("The plots Hydorgen.svg and taskB.svg shows the results of TASK B");
				energy0Data.Close();
			}

			if(arg == "-hydrogenRmax"){

				// double rmax = 8; 
				double rmin = 1e-3;
				double acc = 1e-1; 
				double eps = 1e-1;


				StreamWriter rmaxData= new StreamWriter("rmax.data", false);


				for (double rmax=1; rmax<8; rmax+=1){
					Func<vector,vector> ME = (vector v) => {
						
						double E=v[0];
						double fMax = func.hydrogen(E, rmax, rmin, acc, eps);
						return new vector (fMax);};


					vector vstart = new vector(-1.0);
					vector E0 = root_finder.newtonMethod(ME,vstart);
					double energy0 = E0[0];
					// for (double r=0; r<rmax; r+=rmax/128){
					// 		double fR = func.hydrogen(energy0,r);
					// 		double exactFr = r*Exp(-r);
					// 		energy0Data.WriteLine($"{r} {fR} {exactFr}");
					// 	}

					rmaxData.WriteLine($"{rmax} {energy0}");

				}
				rmaxData.Close();
				
			}
			if(arg == "-hydrogenRmin"){

				double rmax = 8; 
				// double rmin = 1e-3;
				double acc = 1e-1; 
				double eps = 1e-1;


				StreamWriter rminData= new StreamWriter("rmin.data", false);


				for (double rmin=1e-2; rmin<0.5; rmin+=0.05){
					Func<vector,vector> ME = (vector v) => {
						
						double E=v[0];
						double fMax = func.hydrogen(E, rmax, rmin, acc, eps);
						return new vector (fMax);};


					vector vstart = new vector(-1.0);
					vector E0 = root_finder.newtonMethod(ME,vstart);
					double energy0 = E0[0];


					rminData.WriteLine($"{rmin} {energy0}");

				}
				rminData.Close();
				
			}
			if(arg == "-hydrogenAcc"){

				double rmax = 8; 
				double rmin = 1e-3;
				// double acc = 1e-1; 
				double eps = 1e-1;


				StreamWriter accData= new StreamWriter("acc.data", false);


				for (double acc=0.001; acc<0.1; acc+=0.01){
					Func<vector,vector> ME = (vector v) => {
						
						double E=v[0];
						double fMax = func.hydrogen(E, rmax, rmin, acc, eps);
						return new vector (fMax);};


					vector vstart = new vector(-1.0);
					vector E0 = root_finder.newtonMethod(ME,vstart);
					double energy0 = E0[0];

					accData.WriteLine($"{acc} {energy0}");

				}
				accData.Close();
				
			}

			if(arg == "-hydrogenEps"){

				double rmax = 8; 
				double rmin = 1e-3;
				double acc = 1e-1; 
				// double eps = 1e-1;


				StreamWriter epsData= new StreamWriter("eps.data", false);


				for (double eps=1e-8; eps<0.1; eps+=1e-2){
					Func<vector,vector> ME = (vector v) => {
						
						double E=v[0];
						double fMax = func.hydrogen(E, rmax, rmin, acc, eps);
						return new vector (fMax);};


					vector vstart = new vector(-1.0);
					vector E0 = root_finder.newtonMethod(ME,vstart);
					double energy0 = E0[0];
					epsData.WriteLine($"{eps} {energy0}");

				}
				epsData.Close();
				
			}



		}


}

}
