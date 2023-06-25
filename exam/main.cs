using System;
using static System.Console;
using static System.Math;


public class main{


    // Function to minimize (example)
    public static double function1(vector x)
    {
		double result = Sin(x[0]) + Cos(x[1]);
        return result;
    }


    public static double function2(vector x)
    {
        double result = Pow(x[0] - 0, 2) + Pow(x[1] - 3, 2);
		// double result = - Exp(Pow(-x[0],2)) - Exp(Pow(-x[1],2));
        return result;
    }



	public static double divFunction1(vector x)
	{
		double result = Log(x[0]) + 2 * Log(x[1]) + 0.5 * Log(x[2]);
		return result;
	}


    public static void Main(string[] args){
		
		foreach(var arg in args){
			if(arg == "-testRandomVec"){
				// var rnd = new Random();

				// vector a_test = new vector(1, 0);
				// vector b_test = new vector(2,0);
				// vector vecSvarm = svarm.randomvec(a_test, b_test, rnd);
				// vecSvarm.print("Random vector");



			}



			if(arg == "-function1"){
				    
				// Initial vectors
				vector a = new vector(0, 0); 
				vector b = new vector(5, 5); 

				// Run algorithm 
				vector solution = svarm.run(function1, a, b, seconds: 2);

				// Print solution
				// Console.WriteLine("Optimal solution: " + solution);
				solution.print("Solution: ");
				Console.WriteLine("Function evaluated at vector: " + function1(solution));
			
			}


			if(arg == "-function2"){
				    
				// Initial vectors
				vector a = new vector(0, 0); 
				vector b = new vector(1, 1); 

				// Run algorithm 
				vector solution = svarm.run(function2, a, b, seconds: 2);

				solution.print("Solution: ");
				Console.WriteLine("Function evaluated at vector: " + function2(solution));
			
			}



			if(arg == "-divFunction1"){
				    
				// Initial vectors
				vector a = new vector(0, 0, 2); 
				vector b = new vector(5, 5, 2); 

				// Run algorithm 
				vector solution = svarm.run(function2, a, b, seconds: 2);

				solution.print("Solution: ");
				Console.WriteLine("Function evaluated at vector: " + divFunction1(solution));
			
			}


		}








	} 

}
