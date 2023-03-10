using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
		/*sqrt(2), 2**(1/5), e**pi, pi**e */
		double sqrt = System.Math.Sqrt(2);
		string sqrtMessage = $"square root of 2 is {sqrt}";
		WriteLine(sqrtMessage);
		double twoPower =  System.Math.Pow(2, 1.0/5.0);
		WriteLine($"2 to the power of 1/5 is {twoPower}");
		double ePower = Pow(E, PI);
		WriteLine($"E**PI is {ePower}");
		double piPower = Pow(PI, E);
		WriteLine($"Pow(PI, E) is {piPower}");
		/*Stirling's approximation for 1,2,3,10 */
		WriteLine("Here we print gamma function for 1, 2, 3 and 10");
		WriteLine(sfuns.gamma(1));
		WriteLine(sfuns.gamma(2));
		WriteLine(sfuns.gamma(3));
		WriteLine(sfuns.gamma(10));
		/*Now we print the ln to the gamma function */
		WriteLine("We print the lngamma function");
		
}
}
