using System;
using static System.Console;
using static System.Math;

class main{


	
    public static double erf_int(double z){
        Func<double,double> f;
        if(z<0){
            var result1 = -erf_int(-z);
            return (result1);
        }
        if((z >= 0) && (z <= 1.0)){
            f = delegate(double x){return Exp(-Pow(x,2));};
            var result2 = integration.integrate(f,0,z);
            return (2.0/Sqrt(PI)*result2);
        }
        if(z > 1.0){
            f = delegate(double t){return Exp(-Pow((z+(1-t)/t),2))/t/t;};
            var result3 = integration.integrate(f,0,1);
            return (1-2.0/Sqrt(PI)*result3);
        }
        return 0.0;
   }


public static void Main(string[] args){
	Func<double,double> f; 


	foreach(var arg in args){
		if(arg == "-integrals14"){
				WriteLine("-------Integrals from 1-4-------");

				f = delegate(double x){return Sqrt(x);};
				var result1 = integration.integrate(f,0,1);
				var exact1 = 2.0/3;	
				WriteLine($"int[0;1] dx sqrt(x) = {result1}");
				WriteLine($"Is integral within 1e-9 error (comparison = {exact1}): {complex.approx(exact1,result1,1e-3,1e-3)}");

				Write("\n");
				f = delegate(double x){return 1.0/Sqrt(x);};
				var result2 =  integration.integrate(f,0,1,1e-6,0);	
				var exact2 = 2.0;
				WriteLine($"int[0;1] dx 1/sqrt(x) = {result2}");
				WriteLine($"Is integral within 1e-9 error (comparison = {exact2}): {complex.approx(exact2,result2,1e-6,1e-6)}");

				
				Write("\n");
				f = delegate(double x){return 4.0*Sqrt(1-Pow(x,2));};
				var result3 =  integration.integrate(f,0,1,1e-6,0);	
				var exact3 = PI;
				WriteLine($"int[0;1] dx 4*sqrt(1 - x**2) = {result3}");
				WriteLine($"Is integral within 1e-9 error (comparison = {exact3}): {complex.approx(exact3,result3,1e-6,1e-6)}");

				Write("\n");
				f = delegate(double x){return Log(x)/Sqrt(x);};
				var result4 =  integration.integrate(f,0,1,1e-6,0);	
				var exact4 = -4.0;
				WriteLine($"int[0;1] dx ln(x)/sqrt(x) = {result4}");
				WriteLine($"Is integral within 1e-9 error (comparison = {exact4}): {complex.approx(exact4,result4,1e-6,1e-6)}");
				
	} // -integrals14
	if(arg == "-erfs"){
			for(double x=-4 + 1.0/128;x<=4;x+=1.0/64){
				WriteLine($"{x} {sfuns.erf(x)}");}
			
			Write("\n\n");
			for(double z =-4+1.0/68;z<4;z+=1.0/4){
				WriteLine($"{z} {erf_int(z)}");
			}

	}


	if(arg == "-ccTransform2"){

		Func<double, double> g;
		int ncalls = 0;
		WriteLine("-----Task B-----");
		WriteLine("Using Clenshaw–Curtis transformation number 2 from the homework");

		WriteLine("Integration from 0 to 1 with respect to x 1/sqrt(x)");
		g = delegate(double x){ncalls ++; return 1.0/Sqrt(x);};
		ncalls = 0;	var woTrans = integration.integrate(g,0,1); 
		WriteLine($"Result without transformation {woTrans}. Called {ncalls}");
		ncalls = 0;	var wTrans = integration.ccTransform2(g,0,1);
		WriteLine($"Result with transformation {wTrans}. Called {ncalls}");
		
		Write("\n\n");	

		WriteLine("Integration from 0 to 1 with respect to x ln(x)/sqrt(x)");
		g = delegate(double x){ncalls ++; return Log(x)/Sqrt(x);};
		ncalls = 0; var woTrans2 = integration.integrate(g,0,1); 
		WriteLine($"Result without transformation {woTrans2}. Called {ncalls}");
		ncalls = 0; var wTrans2 = integration.ccTransform2(g,0,1);
		WriteLine($"Result with transformation {wTrans2}. Called {ncalls}");

		WriteLine("Results achieved with scipy");
		WriteLine("Result for 1/Sqrt(x) = 2.0000000000000004. Called: 231");

		Write("\n\n");	
		WriteLine("Result for ln(x)/Sqrt(x) = -3.999999999999974. Called 315");
	}

	}
}


}

