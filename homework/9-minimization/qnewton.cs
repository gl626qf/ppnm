using System;
using static System.Console;
using static System.Math;

public static partial class qnewton{

public static double delta = Pow(2,-26);

public static vector gradient(Func<vector,double>f, vector x){
	var n = x.size;
	vector dfdx = new vector(n);
	double fx = f(x);
	for (int i = 0; i<n;i++){
		double dx = Abs(x[i])*delta;
		x[i] += dx;
		dfdx[i] = (f(x)-fx)/dx;
		x[i] -= dx;
	}//forloop
	return dfdx;

}//gradient


public static int minimum(
	Func<vector,double>f, /* objective function */
	ref vector x, /* starting point */
	double acc /* accuracy goal, on exit |gradient| should be < acc */
	){
	vector gx=gradient(f,x);
	double fx = f(x);
	double epsilon = Pow(2,-20);
	int step = 0;
/*	
	matrix H = hessian(f,x);
	var (Q,R) = QRGS.dec(H);
	matrix B = QRGS.inverse(H);
*/
	var n = x.size;
	matrix B = matrix.id(n);

	while(gx.norm() > acc){
		step++;
		vector Dx = -B*gx;
	if(Dx.norm() < epsilon*x.norm() || Dx.norm() < acc){
		Error.WriteLine("dx < deltax");
		}
		vector z; 
		vector gz = new vector(n);
		double fz;
		double lambda = 1.0;
		do{ // backtracking linesearch
			z = x+lambda*Dx;
			fz = f(z);
			gz = gradient(f,z);
			if(fz < fx){/*accept step and update SR1*/
				vector s = z-x;
				vector y = gz-gx;
				vector u = s-B*y;
				double uTy = u%y;
				if(Abs(uTy)> 1e-6){
					B.update(u,u,1/uTy);
					}
				break;
				}
			if(lambda < epsilon){
				B.setid();
				break;
				}
			lambda /= 2;			
		}while(true);
	x = z;
	gx = gz;
	fx = fz;
//WriteLine($"gx.norm = {gx.norm()} acc = {acc}");
	}//while
	return step;
 
}//qnewton minimum
}//class
