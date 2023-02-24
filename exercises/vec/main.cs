using System;
using static System.Console;
using static System.Math;

public static class main{
	//Task 4
	public static void print(this double x, string s){ /* x.print("x="); */
		Write(s);WriteLine(x);
	}
	public static void print(this double x){ /*x.print() */
		x.print("");
	}
	// Task 7
//	public override string ToString()
//	{
//		return $"{x} {y} {z}"; }


	//Task 4 end

	public static void Main(){
		//Define vector examples and scalar
		vec u = new vec(1,2,3);
		vec v = new vec(2,4,6);
		double c = 2;
		WriteLine("I define the vectors");
		u.print("u = ");
		v.print("v = ");

		///Task 3
		WriteLine("We define multiplication of a scalar");
		vec vec_mult = c * v;
		vec_mult.print("c * v =");
		// This gives a bug: vec vec_mult_diff = v * c;		

		WriteLine("We now define addition and subtraction");
		vec vec_addition = u + v;
		vec_addition.print("u + v = ");
		vec vec_minus = -u;
		vec_minus.print("-u = ");
		vec vec_subtract = u - v;
		vec_subtract.print("u - v = ");
		///Task 3 end


		///Task 5: Dot products
		double vec_dot = u.dot(v);
		vec_dot.print("scalar product u.dot(v) = ");
		double vec_dot_new = vec.dot(u,v);
		vec_dot_new.print("vec.dot(u,v) = ");
		
		// Syntactic sugar
		WriteLine("We use some syntax sugar");
		double vec_dot_syntax = u.dot_syntax(v);
		vec_dot_syntax.print("u.dot_syntax(v) = ");
		double vec_dot_new_syntax = vec.dot_syntax(u,v);
		vec_dot_new_syntax.print("vec.dot_syntax(u,v) = ");

		///Task 6: Approx methode
		WriteLine("We make approximation function");
		double approx_scalar = approx(2, 4);
		//approx_scalar.print("approx_scalar test = ");
				

		///Task 7: ToString
//		WriteLine(new v);
	}
}
