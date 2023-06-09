using System;
using static System.Console;
using static System.Math;



public class main{

	public static bool approx
		(double a, double b, double acc=1e-9, double eps=1e-9){
			if(Abs(b-a) < acc) return true;
			else if(Abs(b-a) < Max(Abs(a), Abs(b))*eps) return true;
			else return false;
		}



	public static void Main(){
		WriteLine("-----Part 1-----");
		//We make first part
		int i=1; while(i+1>i) {i++;}
		Write("my max int = {0}\n", i);
	
		while(i-1<i) {i++;}
		Write("my min int = {0}\n", i);
				
		WriteLine("-----Part 2-----");
		//We make second part 	
		double x=1; while(1+x!=1){x/=2;} x*=2;
		Write("my machine epsilon for doubles = {0}\n", x);
		Write("We check the value with System.Math.Pow(2,-52) = {0}\n"
				, System.Math.Pow(2,-52));
		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Write("my machine epsilon for floats = {0}\n", y);
		Write("We check the value with System.Math.Pow(2,-23) = {0}\n"
				, System.Math.Pow(2,-23));

		Write("Both values are as we expected\n");
		WriteLine("-----Part 3-----");
		//We make third part
		Write("Third part\n");
		int n=(int)1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;
		
		sumA+=1; for(int j=0;j<n;j++){sumA+=tiny;}
		for(int j=0;j<n;j++){sumB+=tiny;} sumB+=1;
		
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
		Write("Why does this differ?\n");
		WriteLine("The reason is that, epsilon is divisable with 2");
		WriteLine(", and all added together, gives a float!! LLOOOOK UP !!!!");




	WriteLine("-----Part 4-----");



	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;



	WriteLine($"d1={d1:e15}");
	WriteLine($"d2={d2:e15}");
	WriteLine($"d1==d2 ? => {d1==d2}");



	WriteLine("Here we test the approx function");
	bool approx_value = approx(d1,d2);
	WriteLine("approx(d1,d2) = " +  approx_value);


	} //Main




} //main


