using System;
using static System.Console;
using static System.Math;
using static System.Random;
using System.Linq;
using System.IO;
using static System.IO.TextWriter;

public class main{



	public static void Main(string[] args){
	foreach(var arg in args){
		// Initializing vectors
		vector a = new vector("-1, -1");
        vector b = new vector("1, 1");
        int N = 10000;
        double actVol = (4.0/3.0)*PI*0.5; /*Actual half volume of sphere*/

		if(arg == "-2Dshapes"){
			WriteLine("----Half unit circle----");
			WriteLine("Half unit circle");
			WriteLine($"Actual value:	{PI * Pow(1,2) * 0.5}");
			int number = N;
			var result = monteCarlo.plainmc(shapes.unitCircle, a, b, number);
			WriteLine($"Calculated value with {number} points:	{result.Item1} ± {result.Item2}");
		
			WriteLine("----Difficult shape----");
			WriteLine("Difficult integral from task description");
			WriteLine("Actual value:	1.3932039296856768591842462603255");
	
			vector a_hard = new vector("0, 0, 0");
			vector b_hard = new vector(PI, PI, PI);
			int N_hard = N;
			var answer_hard = monteCarlo.plainmc(shapes.difficultSingular, a_hard, b_hard, N_hard);
			WriteLine($"Calculated value with {N_hard} points:	{answer_hard.Item1} ± {answer_hard.Item2}");
		}


		if(arg == "-3Dshapes"){
			WriteLine("----Half unit sphere----");
			WriteLine("Half unit sphere");
			WriteLine($"Actual value:	{(4.0/3.0)*PI*0.5}");
			int N_unitCircle = N;
			var result = monteCarlo.plainmc(shapes.unitCircle, a, b, N_unitCircle);
			WriteLine($"Calculated value with {N_unitCircle} points:	{result.Item1} ± {result.Item2}");
		
			WriteLine("----Difficult shape----");
			WriteLine("Difficult integral from task description");
			WriteLine("Actual value: 1.3932039296856768591842462603255");
	
			vector a_hard = new vector("0, 0, 0");
			vector b_hard = new vector(PI, PI, PI);
			int N_hard = N;
			var answer_hard = monteCarlo.plainmc(shapes.difficultSingular, a_hard, b_hard, N_hard);
			WriteLine($"Calculated value with {N_hard} points:	{answer_hard.Item1} ± {answer_hard.Item2}");
			
		}
		if(arg == "-mcUnitCircle"){
			for(int i=1;i<=N;i++){
				var result = monteCarlo.plainmc(shapes.unitCircle, a, b, i);
				WriteLine($"{i} {result.Item2}");	
			}
		}
		if(arg == "-divVolume"){
			for(int i=1;i<=N;i++){
				var result = monteCarlo.plainmc(shapes.unitCircle, a, b, i);
				WriteLine($"{i} {Abs(result.Item1-actVol)}");
		}
		}		
		if(arg == "-invSqrt"){
			for(int i =1;i<=N;i++){
				WriteLine($"{i} {1/Math.Sqrt(i)}");
		}
		}
		if(arg == "-divError"){
			for(int i=1;i<=N;i++){
        		var result = monteCarlo.plainmc(shapes.unitCircle, a, b, i);	
				WriteLine($"{i} {result.Item2 - (Abs(result.Item1-actVol))}");
		}
		}
	}
	}
}








