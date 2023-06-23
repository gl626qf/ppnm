
using System;
using static System.Console;
using static System.Math;


public static class main{
	public static void Main(){
		WriteLine(" ----- Test of root finder methode by different one- and two-dimensional eq. ------ ");
		Func<vector,vector> f = x => new vector (x[0]*x[0]);
		vector x0 = new vector(1);
		x0[0] = 0.1;
		WriteLine(" # Function to find root f(x)=x^2 # ");
		WriteLine($"start vector : {x0[0]}\n");
		var result0 = root_finder.newton(f,x0);
		result0.print("result = ");
		f(result0).print("f(roots) = ");
		WriteLine(" The correct result for roots is x = 0");

		WriteLine("\n\n #### NEW CALCUALTION #### \n\n");
		Func<vector, vector> g = x => new vector(2*x[0]*Log(x[0])+x[0]);
		vector x1 = new vector(1);
		x1[0] = 1;
		WriteLine(" # Function to find root f(x) = 2*x*log(x)+x # ");
		WriteLine($"start vector : {x1[0]}\n");
		var result1 = root_finder.newton(g,x1);
		result1.print("result = ");
		g(result1).print("f(roots) = ");
		WriteLine(" The correct result for roots is x = 1/sqrt(2)=0.60653");


		WriteLine("\n\n #### NEW CALCUALTION #### \n\n");
		Func<vector,vector> l = x => new vector (x[0]-x[0]*x[1],x[0]*x[0]-2);
		vector x3 = new vector(2.0,2.0);
		WriteLine(" # Find roots for f(x,y) = (x-x*y,x^2-2) # ");
		WriteLine($"start vector : {x3[0]}, {x3[1]}\n");
		var result3 = root_finder.newton(l,x3);
		result3.print("result = ");
		l(result3).print("f(roots) = ");
		WriteLine(" Th correct result for roots is x = 1.41421, y =1");



		WriteLine("\n\n #### Extremum for Rosenbrock's vally #### \n\n");
		Func<vector,vector> h = x => new vector ((-2*(1 - x[0]) -2*x[0]*200*(x[1] - x[0]*x[0])), (200*(x[1] - x[0]*x[0])));
		vector x4 = new vector(2.0,3.0);
		WriteLine(" # Find extremum for Rosenbrock's vally function by roots of gradient # ");
		WriteLine("Rosenbrock's vallu function : f(x,y)=(1-x)^2+100(y-x^2)^2 \n Gradient analytical: (-2*(1-x)-400*x*(y-x^2),200*(y-x^2))"); 
		WriteLine($"start vector : {x4[0]}, {x4[1]}\n");
		var result4 = root_finder.newton(h,x4);
		result4.print("result = ");
		h(result4).print("f(roots) = ");
		WriteLine(" The correct result for roots is x = 1, y =1");
		WriteLine($" The found roots for gradient is the minimum extremum of Rosenbrock's vally funktion");


}//Main

}// class main
