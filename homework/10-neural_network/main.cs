using System;
using static System.Console;
using static System.Math;
using System.IO;
public class main{
	
	public static void Main(string[] args){
		
		


		foreach(var arg in args){
			if(arg == "-A"){
				Func<double,double> g = x => Cos(5*x-1)*Exp(-x*x);// function
				var data = new StreamWriter("data.data");
				
				// Making the data points
				int nPoints = 20; 
				double a = -1, b = 1; //interval
				vector xs = new vector(nPoints), ys = new vector(nPoints);
				for(int i = 0; i< nPoints;i++){
					xs[i] = a+(b-a)*i/(nPoints-1);
					ys[i] = g(xs[i]);
					data.WriteLine($"{xs[i]} {ys[i]}");
				}


				// Making Network
				var Network = new StreamWriter("Network.data");
				int nNeurons = 6;
				ann network = new ann(nNeurons, g);


				network.train(xs,ys);
				for(double j=a; j<b;j+=1.0/64){
					Network.WriteLine($"{j} {network.response(j)}");		
				}

				WriteLine("Plot is viewed in plotA.svg");

				data.Close();
				Network.Close();


			}

			if(arg == "-B"){
				double a = -1, b = 1; //interval
				
				int nPoints = 20; 
				Func<double,double> gaussianWavelet = x => x*Exp(-x*x);
				var data2 = new StreamWriter("data2.data");
				vector x_s = new vector(nPoints), y_s = new vector(nPoints);
				for(int i = 0; i< nPoints;i++){ //equal distributed uniform points
					x_s[i] = a+(b-a)*i/(nPoints-1);
					y_s[i] = gaussianWavelet(x_s[i]);
					data2.WriteLine($"{x_s[i]} {y_s[i]}");}
				data2.Close();
				var Network2 = new StreamWriter("Network2.data");
				var derv = new StreamWriter("derv.data");
				int N = 10;
				ann network2 = new ann(N,gaussianWavelet);
				network2.train(x_s,y_s);
				for(double j = a; j<b; j+=1.0/64) {
					Network2.WriteLine($"{j} {network2.response(j)}");
					derv.WriteLine($" {j} {network2.dGaussWavelet(j)} {network2.ddfGaussianWavelet(j)} {network2.intGaussianWavelet(j,-1)}");}
				Network2.Close();
				derv.Close();


			}
			
			if(arg == "-C"){
				
			}


		}


		
	}//Main

}//main class
