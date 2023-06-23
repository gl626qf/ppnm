using System;
using static System.Console;
using static System.Math;



public class shapes{
    
	public static double unitCircle(vector coordinate){
    	double x = coordinate[0];
    	double y = coordinate[1];
    	double unitlength = Sqrt(x*x + y*y);
    	if(unitlength > 1) {return 0.0;} 
		else{return Sqrt(1 - x*x - y*y);}
	}
	


	public static double difficultSingular(vector coordinate_){
		double x = coordinate_[0];
		double y = coordinate_[1];
		double z = coordinate_[2];
		return 1/(1-Cos(x)*Cos(y)*Cos(z))/(PI*PI*PI);
	}
}