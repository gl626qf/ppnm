using System;
using static System.Console;
using static System.Math;
using System.IO;
public class main{
	
	public static void Main(){
		
		WriteLine("------- Part A --------");
		WriteLine("Test of ann.cs are performed with training points for g(x)=Cos(5*x-1)*exp(-x^2)");
		WriteLine("The minimization of the cost function is performed with quasi-newton minimization");
		Func<double,double> g = x => Cos(5*x-1)*Exp(-x*x);// test function g(x)
		//constructing x- and y-points
		WriteLine("Construting x and y trainingpoitns on the interval of -1 to 1 wiht 20 points. The Network is set up with 6 neurons");
		var outpoints = new StreamWriter("TrainPointsA.txt");
		int m = 20; //number of points
		double a = -1, b = 1; //interval
		vector xs = new vector(m), ys = new vector(m);
		for(int i = 0; i< m;i++){ //equal distributed uniform points
			xs[i] = a+(b-a)*i/(m-1);
			ys[i] = g(xs[i]);
			outpoints.WriteLine($"{xs[i]} {ys[i]}");
		 }//for loop
		outpoints.Close();
		//setting op network
		var Networkpoints = new StreamWriter("NetworkPointsA.txt");
		int n = 6;
		ann network = new ann(n,g);
		//Error.WriteLine($" newtork n = {network.n}");
		network.train(xs,ys); //training
		for(double j=a; j<b;j+=1.0/64){
		//	Error.WriteLine($" {j} {network.response(j)}");
			Networkpoints.WriteLine($"{j} {network.response(j)}");		
		}//forloop
		Networkpoints.Close();
		WriteLine("\n The results are plotted on TestFunctionPlotA.svg");
		
		WriteLine("\n---------- Part B ----------");
		WriteLine("Performing ANN on a Gaussian Wavlet f(x)=x*exp(-x^2)");
		WriteLine("Return also first and second derivatives and the anti-dericative of the approximant to the Gaussain Wavlet");
		
		Func<double,double> Gw = x => x*Exp(-x*x); //Gaussian Wavelet
		WriteLine("Construting x and y trainingpoitns on the interval of -1 to 1 wiht 20 points. The Network is set up with 5 neurons");
		var outpointsB = new StreamWriter("TrainPointsB.txt");
		vector x_s = new vector(m), y_s = new vector(m);
		for(int i = 0; i< m;i++){ //equal distributed uniform points
			x_s[i] = a+(b-a)*i/(m-1);
			y_s[i] = Gw(x_s[i]);
			outpointsB.WriteLine($"{x_s[i]} {y_s[i]}");}
		outpointsB.Close();
		var NetworkpointsB = new StreamWriter("NetworkPointsB.txt");
		var derivatives = new StreamWriter("DerivativesB.txt");
		int N = 10;
		ann network2 = new ann(N,Gw);
		network2.train(x_s,y_s);
		for(double j = a; j<b; j+=1.0/64) {
			NetworkpointsB.WriteLine($"{j} {network2.response(j)}");
			derivatives.WriteLine($" {j} {network2.df_gaussianwavlet(j)} {network2.ddf_gaussianwavlet(j)} {network2.F_gaussianwavlet(j,-1)}");}
		NetworkpointsB.Close();
		derivatives.Close();
		WriteLine("\n The results are plotted in a muliplot on PlotB.svg");
		
	}//Main

}//main class
