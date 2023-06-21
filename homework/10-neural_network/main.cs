using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;



// public class genlist<T>{
// 	public T[] data;
// 	public int size => data.Length;
// 	public T this[int i] => data[i]; 
// 	public genlist(){ data = new T[0]; }
// 	public void add(T item){
// 		T[] newdata = new T[size+1];
// 		System.Array.Copy(data,newdata,size);
// 		newdata[size]=item;
// 		data=newdata;
// 	}
// }

// MADE ann TO Ann


public class ann{
   int n; /* number of hidden neurons */
   Func<double,double> f = x => x*Exp(-x*x); /* activation function */
   vector p; /* network parameters */
   Ann(int n){/* constructor */}
   double response(double x){
      /* return the response of the network to the input signal x */
     }
   void train(vector x,vector y){
      /* train the network to interpolate the given table {x,y} */
   }
}


public class main{
public static void Main(string[] args){


	foreach(var arg in args){
		if(arg == "-test"){
			WriteLine("Hej");
			Func<double,double> f = (double x) => Pow(x,0.5);

			integrate.Integrate(f, 2, 4);
		}


	}//foreach	


	}//Main
}//main










