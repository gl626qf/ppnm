using System;
using static System.Console;
using static System.Math;
public class vec{
	//Task 1
	public double x,y,z;
	public vec (){x=y=z=0; }
	public vec (double a, double b, double c){this.x=a; this.y=b; this.z=c;}
	
	//Task 4
	public void print(string s){Write(s); WriteLine($"{x} {y} {z}");}


	public static vec operator*(vec v, double c){return new vec(c*v.x, c*v.y, c*v.z);}
	
	public static vec operator*(double c, vec v){return new vec(v.x*c, v.y*c, v.z*c);}	

	
	public static vec operator+(vec u, vec v){return new vec(u.x+v.x,u.y+v.y, u.z+v.z);}
	
	public static vec operator-(vec u){return new vec(-u.x, -u.y, -u.z);}

	public static vec operator-(vec u, vec v){return new vec(u.x-v.x, u.y-v.y, u.z-v.z);}
	

	/// Task 5
	public double dot(vec other) /* to be called as u.dot(v) */
		{return this.x * other.x + this.y * other.y + this.z * other.z;}
	
	public static double dot(vec v, vec w) /* to be called as vec.dot(u,v) */
		{return v.x*w.x + v.y*w.y + v.z*w.z;}
	
	public double dot_syntax(vec other) => this.x*other.x + this.y*other.y + this.z*other.z;

	public static double dot_syntax(vec v, vec w) => v.x*w.x + v.y*w.y + v.z*w.z;


	///Task 6
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(a-b)<acc) return true;
		if(Abs(a-b)<(Abs(a) + Abs(b)) * eps) return true;
		return false;
	}

	public bool approx(vec other){
		if(!approx(this.x,other.x))return false;
		if(!approx(this.y,other.y))return false;
		if(!approx(this.z,other.z))return false;
		return true;
	}

	public static bool approx(vec u, vec v) => u.approx(v);

	public override string ToString() => $"{x} {y} {z}";
}	


