
using System;
using static System.Console;
using static System.Math;


public static class main{
	public static void Main(string[] args){
		
		foreach(var arg in args){
			if(arg == "-A"){
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
			}


		}


}

}
