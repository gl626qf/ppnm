using System;
using static System.Console;
using static System.Math;

public static class main{
	
	public static void Main(){
		WriteLine(" #### Testing the method for Quasi newton and rand-1 update #### " );
		WriteLine("");
		WriteLine("For the alogorithm the number of steps are recored\n");
		var epsi = 1e-5;
		//
		//
		WriteLine("Minimum of Rosenbrock's vally function f(x,y)=(1-x)^2+100*(y-x^2)^2:");
		//Func<vector,double> F1 = (x) =>{return Pow(1-x[0],2)+100*Pow(x[1]-x[0]*x[0],2);};
		Func<vector,double> F1 = (x) =>{return Pow(1-x[0],2)+10*Pow(x[1]-x[0]*x[0],2);};
		vector vec1 = new vector(2,1.6);
		WriteLine($"Start guess is ({vec1[0]},{vec1[1]})");
		int nsteps1 = qnewton.minimum(F1,ref vec1,epsi);
		var GradF1 = qnewton.gradient(F1,vec1);
		WriteLine($"The minimum is found be be: ({vec1[0]},{vec1[1]})");
		WriteLine($"In the minimum the function Gradf(x,y) is: ({GradF1[0]},{GradF1[1]})");
		WriteLine($"|Gradf(x,y)| = {GradF1.norm()}");
		WriteLine("The theoretical is a minimum at (1,1) for grad(f(x,y))=0"); 
		WriteLine($"Number of steps in caculation: {nsteps1}");
		//
		//
		WriteLine("\n ------------------------------ \n ");
		//
		//
		WriteLine("Minimum of Himmelblau's function f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2:");
		Func<vector,double> F2 = (x) =>{return Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7,2);};
		vector vec2 = new vector(5,3);
		WriteLine($"Start guess is ({vec2[0]},{vec2[1]})");
		var nsteps2 = qnewton.minimum(F2,ref vec2,epsi);
		var GradF2 = qnewton.gradient(F2,vec2);
		WriteLine($"The minimum is found be be: ({vec2[0]},{vec2[1]})");
		WriteLine($"In the minimum the function Gradf(x,y) is: ({GradF2[0]},{GradF2[1]})");
		WriteLine("There is a theoretical minimum at (-2.805123,3.13131) for grad(f(x,y))=0"); 
		WriteLine($"Number of steps in caculation: {nsteps2}");
}//Main()

}//class main
