using System;
using static System.Math;
using static System.Console;



public class main{
	public static void Main(string[] args){
	
	var list = new genlist<double[]>(); // make a new list that will be read.
	
	foreach(var arg in args){          // look for arg for every argument in inputfile 
		var words = arg.Split(' ', '\t'); 
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0;i<n;i++){       
			numbers[i] = double.Parse(words[i]); //it has now made a list with all the numbers in the inputfile
			}
		list.add(numbers);
		}	

	for(int i=0; i<list.size;i++){
		var numbers = list[i];
		foreach(var number in numbers) WriteLine(String.Format("{0,-12} | {1,-9} | {2,5}",$"{i}  ", $"{number}",$"{number : 0.00e+00;-0.00e+00}" ));
		}


	}
}
 





// class main{
// 	public static void Main(){
// 	genlist<double> listd = new genlist<double>();
// 	listd.add(1.0);
// 	listd.add(2.0);
// 	listd.add(3.0);
// 	Func<double,double> f;
// 	f = Sin;
// 	f = delegate(double x){return x*x;}; // Old notation
// 	f = (double x) => x*x;
// 	double y = f(2.0);
// 	WriteLine($"f(2.0) = 2*2 = {y}");
// 	}
// }