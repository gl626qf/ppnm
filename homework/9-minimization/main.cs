using System;
using static System.Console;
using static System.Math;
using System.IO;
using System.Collections.Generic;
public static class main{

    public static int nDataPoints;
	
	public static void Main(string[] args){
		

		var epsilon_ = 1e-5;
		// energy = new System.Collections.Generic.List<double>();
		// signal = new System.Collections.Generic.List<double>();
		// error  = new System.Collections.Generic.List<double>();
	
		foreach(var arg in args){
			if(arg == "-rosenbrock"){

				WriteLine("Minimum of Rosenbrock's vally function f(x,y)=(1-x)^2+100*(y-x^2)^2:");

				Func<vector,double> fRosen = (x) =>{return Pow(1-x[0],2)+100*Pow(x[1]-x[0]*x[0],2);};
				vector vec1 = new vector(2,1.6);
				WriteLine($"Initial vectors ({vec1[0]},{vec1[1]})");
				int nsteps1 = qnewton.minimum(fRosen,ref vec1,epsilon_);
				vector gradF1 = qnewton.gradient(fRosen,vec1);
				WriteLine($"The minimum is found be: ({vec1[0]},{vec1[1]})");
				WriteLine($"In the minimum the function Gradf(x,y) is: ({gradF1[0]},{gradF1[1]})");
				WriteLine($"||Gradf(x,y)|| = {gradF1.norm()}");
				WriteLine("The theoretical is a minimum at (1,1) for grad(f(x,y))=0"); 
				WriteLine($"Number of steps in caculation: {nsteps1}");
				WriteLine("\n\n");
				WriteLine("----------------");


			}
			if(arg == "-himmelblau"){
				
				WriteLine("Minimum of Himmelblau's function f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2:");
				Func<vector,double> F2 = (x) =>{return Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7,2);};
				vector vec2 = new vector(5,3);
				WriteLine($"Start guess is ({vec2[0]},{vec2[1]})");
				int nsteps2 = qnewton.minimum(F2,ref vec2,epsilon_);
				vector gradF2 = qnewton.gradient(F2,vec2);
				WriteLine($"The minimum coordinates: ({vec2[0]},{vec2[1]})");
				WriteLine($"The gradient at the minimum is: ({gradF2[0]},{gradF2[1]})");
				WriteLine("The theoretical minimum at (-2.805123,3.13131) for grad(f(x,y))=0"); 
				WriteLine($"Number of steps: {nsteps2}");

			}
			if(arg == "-higgs"){

				List<double> energy = new List<double>();
				List<double> signal = new List<double>();
				List<double> error  = new List<double>();

				StreamReader data = new StreamReader("higgs.data",true);
				StreamWriter fitData = new StreamWriter("fit.data", false);
				var separators = new char[] {' ', '\t'};
				var options = StringSplitOptions.RemoveEmptyEntries;

				do {
					string line = data.ReadLine();
					if (line == null) break;
					string[] words = line.Split(separators, options);
					energy.Add(double.Parse(words[0]));
					signal.Add(double.Parse(words[1]));
					error.Add(double.Parse(words[2]));
				} while (true);

				data.Close();

				int nDataPoints = energy.Count;
				WriteLine(nDataPoints);

				vector start = new vector(6, 120, 3);
				double A, m, G;
				vector vec = start.copy();
				int nsteps = qnewton.minimum(breitwigner.dervBreitWigner, ref vec, 1e-2);
				A = vec[0]; m = vec[1]; G = vec[2];
				fitData.WriteLine($" A = {Round(A,2)}, m = {Round(m,2)}, G = {Round(G,2)}");
				fitData.WriteLine($" steps = {nsteps}");
			
				WriteLine($"A = {Round(A,2)}, m = {Round(m,2)}, G = {Round(G,2)}");
				for(double E = energy[0];E<energy[nDataPoints-1];E+=1.0/64){
					WriteLine($"{E} {breitwigner.breitWigner(A,E,m,G)}");}
				
				fitData.Close();


			}


		}

}

}
