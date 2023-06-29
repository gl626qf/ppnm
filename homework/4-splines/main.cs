using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;




public class binsearch{
    public static int binsearch_(double[] x, double z)
        {/* locates the interval for z by bisection */ 
        if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
        int i=0, j=x.Length-1;
        while(j-i>1){
            int mid=(i+j)/2;
            if(z>x[mid]) i=mid; else j=mid;
            }
        return i;
        }

}


public class spline{
    public static double linterp(double[] x, double[] y, double z){
            int i=binsearch.binsearch_(x,z);
            double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
            double dy=y[i+1]-y[i];
            return y[i]+dy/dx*(z-x[i]);
        }






	public static double linterpInteg(double[] x, double[] y, double z){
		int i = binsearch.binsearch_(x,z);
		double sum = 0;
		for(int k = 0; k<i; k++){
			double dy = y[k+1]-y[k];
			double dx = x[k+1]-x[k];
			sum += y[k]*dx + 1.0/2*dy*dx;
		}
		double dxi = x[i+1]-x[i];
		double dyi = y[i+1]-y[i];
		sum += y[i]*(z-x[i])+1.0/2*(dyi/dxi)*(z-x[i])*(z-x[i]);

		return sum;
		}

}






class qspline {
	// Initialize the variables
	vector x,y,b,c;
	public qspline(vector xs,vector ys){
		x=xs.copy(); y=ys.copy(); 
		int n = x.size;
		c = new vector(n-1);
		b = new vector(n-1);
		double[] p = new double[n-1], h = new double[n-1]; 
		for(int i=0 ; i<n-1 ; i++){
			h[i] = x[i+1] - x[i];
			p[i] = (y[i+1] - y[i])/h[i];
		}
		c[0] = 0;
		for(int i=0 ; i<n-2 ; i++){
			c[i+1] = (p[i+1]-p[i]-c[i]*h[i])/h[i+1];
		}
		c[n-2] /= 2;
		for(int i=n-3 ; i>=0 ; i--){
			c[i] = (p[i+1]-p[i]-c[i+1]*h[i+1])/h[i];
		}
		for(int i=0 ; i<n-1 ; i++){
			b[i] = p[i] - (c[i]*h[i]);
		}
	}
	public double evaluate(double z){/* evaluate the spline */
		int i = binsearch.binsearch_(x,z);
		double s = y[i] + b[i]*(z-x[i]) + c[i]*Pow(z-x[i],2);
		return s;
	}
	public double derivative(double z){/* evaluate the derivative */	
		int i = binsearch.binsearch_(x,z);
		double deriv = b[i] + 2*c[i]*(z-x[i]);
		return deriv;
	}
	public double integral(double z){/* evaluate the integral */	
		int i = binsearch.binsearch_(x,z);
		double sum = 0;
		for(int j=0 ; j<i ; j++){
			double dx = x[i+1]-x[i];
			sum += y[j]*dx + b[i]*Pow(dx,2)/2 + c[i]*Pow(dx,3)/6;
		}	
		return sum;
	}
	// Print the variables
	public vector show_b(){return b;}
	public vector show_c(){return c;}
}


public class main{

	static void Main(string[] args){
		// Set data points
		double[] xs = {-2, -1.55555556, -1.11111111, -0.66666667, -0.22222222,
        0.22222222,  0.66666667,  1.11111111,  1.55555556,  2};
        double[] ys = {0.01831564, 0.08894358, 0.29096046, 0.64118039, 0.95181678,
       0.95181678, 0.64118039, 0.29096046, 0.08894358, 0.01831564};


	   
		foreach(var arg in args){
			if(arg == "-data"){
				int l = xs.Length;
				for(int i=0;i<l;i++){
					WriteLine($"{xs[i]} {ys[i]}");
				}
			}
			if(arg == "-interpolate"){
    				for(double z=xs[0];z<=xs[xs.Length-1];z+=1.0/10.0){
					double interpValue = spline.linterp(xs, ys, z);
    				WriteLine($"{z} {interpValue}");
				}
			}	
			if(arg == "-integrate"){
				for(double z=xs[0];z<=xs[xs.Length-1];z+=1.0/10){
                         	    //    WriteLine($"z = {z}, value = {spline.linterInteg(xs, ys, z)}");
								double intergralValue = spline.linterpInteg(xs,ys,z);
								// WriteLine(intergralValue);
							    WriteLine($"{z} {intergralValue}");
                        	}	
               		}

			if(arg == "-qspline"){
				WriteLine("-----------Results of TASK B-----------------");
				vector xsvec = new vector("1,2,3,4,5"), ysvec = new vector(5);
				for(int i=0; i<5; i++) ysvec[i] = 1;
				qspline qspline_ = new qspline(xsvec,ysvec);
				vector b = qspline_.show_b();
				vector c = qspline_.show_b();


				WriteLine("For x = {1,2,3,4,5}, y = {1,1,1,1,1}");
				b.print("b = ");
				c.print("c = ");
				for(int i=0; i<5; i++) ysvec[i] = i+1;
				qspline_ = new qspline(xsvec, ysvec);
				b = qspline_.show_b();
				c = qspline_.show_b();
				WriteLine("For x = {1,2,3,4,5}, y = {1,2,3,4,5}");
				b.print("b = ");
				c.print("c = ");
				for(int i=0; i<5; i++) ysvec[i] = Pow(i+1,2);
				qspline_ = new qspline(xsvec, ysvec);
				b = qspline_.show_b();
				c = qspline_.show_b();
				WriteLine("For x = {1,2,3,4,5}, y = {1,4,9,16,25}");
				b.print("b = ");
				c.print("c = ");
				WriteLine("The same is achieved when calculated.");

			}


		}
		

	}
}
