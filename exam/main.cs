using System;
using static System.Console;
using static System.Math;


public class main{


    public static int CalculateFactorial(int n){
        if (n == 0){return 1;}
        return n * CalculateFactorial(n - 1);
    }

    public static double CalculateLogBinomialCoefficient(int n, int k)
    {
        double logNumerator = 0;
        double logDenominator = 0;

        for (int i = 1; i <= k; i++)
        {
            logNumerator += Math.Log(n - i + 1);
            logDenominator += Math.Log(i);
        }

        return logNumerator - logDenominator;
    }





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


    // public static double gauss(vector x, double mu, double sigma){
    //     // double K = 1 / (Sqrt(2*PI) * sigma) * Exp(-Pow(x-mu,2) / (2 * Pow(sigma,2)));
    //     double K = 1 / (Sqrt(2*PI) * sigma);
    //     double g_ = Exp(-Pow(x[0]-mu,2) / (2 * Pow(sigma,2)));
    //     // WriteLine("Gaussian PDF");
    //     // WriteLine($"Standard deviation, σ = {sigma}");
    //     // WriteLine($"Average value, µ = {mu}");
    //     return K * g_;

    // } // gauss

    public static double gauss(vector x){
		double sigma = 1;
		double mu = 0;
        // double K = 1 / (Sqrt(2*PI) * sigma) * Exp(-Pow(x-mu,2) / (2 * Pow(sigma,2)));
        double K = 1 / (Sqrt(2*PI) * sigma);
        double g_ = Exp(-Pow(x[0]-mu,2) / (2 * Pow(sigma,2))) + x[1];
        // WriteLine("Gaussian PDF");
        // WriteLine($"Standard deviation, σ = {sigma}");
        // WriteLine($"Average value, µ = {mu}");
        return K * g_;

    } // gauss

    // public static double poisson(vector n, double v){
    //     // double sigma = Sqrt(v);
    //     // WriteLine($"Standard deviation, σ = {sigma}");
    //     // WriteLine($"Average value, 𝛎 = {v}");
    //     return Pow(v,n) / CalculateFactorial(n) * Exp(-v);
    // }

    // public static double binomial(vector r, int N, double p){
    //     // double part1 = CalculateFactorial(N) / (CalculateFactorial(r) * CalculateFactorial(N - r));
    //     // double part2 = Pow(p,r) * Pow((1- p), N-r);
    //     // return part1 * part2;
    //     double logPart1 = CalculateLogBinomialCoefficient(N, r);
    //     double logPart2 = r * Math.Log(p) + (N - r) * Math.Log(1 - p);
    //     return Math.Exp(logPart1 + logPart2);
    // }   


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



			if(arg == "-gauss"){
				    
				// // Initial vectors
				vector a = new vector(1,2); 
				vector b = new vector(2,3); 

				// // Run algorithm 
				vector solution = svarm.run(gauss, a, b, seconds: 2);

				solution.print("Solution: ");
				// vector solution = vector(2);
				// Console.WriteLine("Function evaluated at vector: " + gauss(solution));
			
			}


		}








	} 

}
