using System;
using static System.Console;
using static System.Math;
public class vec{
	public double x,y,z;
	public vec (double a, double b, double c){this.x=a; this.y=b; this.z=c;}
	public vec (){x=y=z=0; }
	
	public static vec operator*(vec v, double c){return new vec(c*v.x, c*v.y, c*v.z);}
	
	
	public void print(string s){Write(s); WriteLine($"{x} {y} {z}");}
	/*
	public static vec operator+(vec u, vec v){ /* u+v */
	/*	return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
	/*
	public static vec operator-(vec u, vec v){/* u-v */
	/*	return new vec(u.x-v.x, u.y-v.y, u.z-v.z)
	*/
	//operators:
}	

