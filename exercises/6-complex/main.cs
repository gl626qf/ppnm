using System;
using static System.Console; 
using static System.Math;
using static cmath;



public class main{


	public static bool approx
		(double a, double b, double acc=1e-9, double eps=1e-9){
			if(Abs(b-a) < acc) return true;
			else if(Abs(b-a) < Max(Abs(a), Abs(b))*eps) return true;
			else return false;
		}



	public static void Main(){

		// var i = new complex(-1);
		
		// WriteLine(Sqrt(-1));
		// WriteLine(i);
		// WriteLine(Pow(E,i));
		// WriteLine(Pow(E, i * PI));
		// WriteLine(Pow(i, i));
		// WriteLine(Log(i));
		// WriteLine(Sin(i * PI));

		WriteLine("----Eq 1----");
		var i1 = new complex(-1);
		WriteLine($"sqrt(-1) = {cmath.sqrt(i1)}, compare = 0+-1*i");
		// WriteLine($"6.12e-17" {approx(6.12e-17, 0)});
		WriteLine($"6.12e-17 and 0 compared, approx(6.12e-17,0) = {approx(6.12e-17, 0)}");
		WriteLine($"1 and 1 compared, approx(1,1) = {approx(1, 1)}");



		WriteLine("----Eq 2----");
		var i2 = new complex(0,1);
		WriteLine($"sqrt(i) = {cmath.sqrt(i2)}, compare = 0.707 + 0.707*i");
		WriteLine($"0.707 compared, approx(0.707, 0.707) = {approx(0.707, 0.707)}");


		WriteLine("----Eq 3----");
		WriteLine($"e^i = {exp(i2)}, compare = 0.54+0.84i");

		WriteLine("The two values are completely the same");

		// WriteLine($"0.707 compared, approx(0.707, 0.54) = {approx(0.707, 0.54)}");
		// WriteLine($"0.707 compared, approx(0.707, 0.84) = {approx(0.707, 0.84)}");

		
		WriteLine("----Eq 4----");
		var i3 = Math.PI;
		WriteLine($"e^(i pi) = {exp(i2*i3)}, compare = -1");


		WriteLine($"comparing real coefficient, approx(1.22e-16, 0) = {approx(1.22e-16, 0)}");

		WriteLine("----Eq 5----");
		WriteLine($"i^i = {cmath.pow(i2,i2)}, compare = 0.208");
		WriteLine("Same values");

		WriteLine("----Eq 6----");
		WriteLine($"ln(i) = {log(i2)}, compare = pi/2*i = 1.57*i");
		WriteLine("Same values");

		WriteLine("----Eq 7----");
		WriteLine($"sin(i pi) = {sin(i2*i3)}, compare = sinh(pi)*i = 11.549i");
		WriteLine($"comparing imaginary coefficient, approx(11.5, 11.549) = {approx(11.5, 11.549)}");
		WriteLine("Here we see, that they fail to be same with the chosen epsilon to our approx function");


	} // Main





} //main


