using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void print(this double x, string s){ /* x.print("x="); */
		Write(s);WriteLine(x);
	}
	public static void print(this double x){ /*x.print() */
		x.print("");
	}
	

	public static void Main(){

		/*int n=2;
		WriteLine(System.Math.Sqrt(2));
		WriteLine(System.Math.Pow(2, 1.0/5.0));
		WriteLine(Pow(E, PI));
		WriteLine(Pow(PI, E));
		WriteLine(sfuns.gamma(1));
		WriteLine(sfuns.gamma(2));
		WriteLine(sfuns.gamma(3));
		
		WriteLine(sfuns.gamma(4));
		WriteLine(sfuns.gamma(10));
		*/	
		vec u = new vec(1,2,3);
		vec v = new vec(2,4,6);
		u.print("u = ");
		v.print("v = ");
		vec vec_sum = u * v;
		vec_sum.print("u * v =");
	}
}
