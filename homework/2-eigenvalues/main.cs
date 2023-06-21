using System;
using static System.Console;
using static System.Math;
// using static jacobi;


public class func{
        public static matrix hamiltonian(double rmax, double dr){
            /* your main should get rmax and dr from the command line, like this */
            /* mono main.exe -rmax:10 -dr:0.3 */
            int npoints = (int)(rmax/dr)-1;
            vector r = new vector(npoints);
            for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
            matrix H = new matrix(npoints,npoints);
            for(int i=0;i<npoints-1;i++){
                H[i,i]  =-2;
                H[i,i+1]= 1;
                H[i+1,i]= 1;
            }
            H[npoints-1,npoints-1]=-2;
            matrix.scale(H,(-0.5/dr/dr));
            for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

            return H;

        }
}


public class partA{

    public void Run()
    {

            WriteLine("------------TASK A------------"); // Maybe make it not hardcoded

            var random = new Random();
            int random_n = random.Next(2,10);
            // WriteLine(random_n);
            // int random_n = 8;
            matrix A_square = new matrix(random_n, random_n);
            for(int i=0;i<random_n;i++){
                for(int j=i;j<random_n;j++){
                    A_square[i,j] = random.Next(1,100);
                    A_square[j,i] = A_square[i,j];
                }
            }
            A_square.print("random square matrix A:");

            // Creating the matrix
            matrix A = A_square.copy();


            (matrix D, vector w, matrix V) = jacobi.cyclic(A);

            V.print("matrix V:");
            // A.print("matrix A:");
            w.print("vector w");




            WriteLine("-------------------------");
            matrix check1 = V * D * V.T;
            // WriteLine($"Eigen value decomp if (V.T * A * V) = D:");
            check1.print($"Eigen value decomp: (V.T * A * V) = D. Matrix D");      
            // D.print("Matrix D:");        


            matrix check2 = V.T * A * V;
            WriteLine($"Testing if (V.T * A * V) = D: {check2.approx(D)}");           


            matrix check3 = V * D * V.T;
            WriteLine($"Testing if (V * D * V.T) = A: {check3.approx(A)}");            



            

            matrix check4 = V.T * V;
            WriteLine($"Testing if (V.T * V) = I: {check4.approx(matrix.id(A.size1))}");
            // Now the testing comes:
            matrix check5 = V * V.T;
            WriteLine($"Testing if (V * V.T) = I: {check5.approx(matrix.id(A.size1))}");
        
    }

}


public class Hydrogen{
	public static void eigen(double rmax, double dr){
		matrix H = func.hamiltonian(rmax, dr);
		(matrix D, vector e, matrix V) = jacobi.cyclic(H);
		e.print("Eigenvalues:");
		V.print("Eigenvectors:");
	}
	public static void plot(double rmax, double dr){
		matrix H = func.hamiltonian(rmax, dr);
		(matrix D, vector e, matrix V) = jacobi.cyclic(H);
		for(int i=0 ; i<V.size2 ; i++){
			Write($"{i*dr} ");
			for(int j=0 ; j<V.size1 ; j++){
				Write($"{V[j][i]/Sqrt(dr)} ");
			}
			Write("\n");
		}
	}
	public static void rmax(double rmax, double dr){
		matrix H = func.hamiltonian(rmax, dr);
		(matrix D, vector e, matrix V) = jacobi.cyclic(H);
		WriteLine($"{rmax} {e[0]}");
	}
	public static void dr(double rmax, double dr){
		matrix H = func.hamiltonian(rmax, dr);
		(matrix D, vector e, matrix V) = jacobi.cyclic(H);
		WriteLine($"{dr} {e[0]}");
	}
}



public static class main{

    public static void Main(string[] args){
            // partA PartA_ = new partA(); 
            // PartA_.Run();


            double rmax = 10;
            double dr = 0.5;
            int size = 5;
            double scale = 10;
            bool trace = false;

            foreach(string param in args){ // set all params
                string[] words = param.Split(":");
                if(words[0] == "-rmax"){rmax = double.Parse(words[1]);}
                if(words[0] == "-dr"){dr = double.Parse(words[1]);}
                if(words[0] == "-size"){size = int.Parse(words[1]);}
                if(words[0] == "-scale"){scale = double.Parse(words[1]);}
                if(words[0] == "-trace"){trace = true;}
            }
            foreach(string run in args){

                if(run == "-partA"){partA PartA_ = new partA(); PartA_.Run();}
                if(run == "-eigen"){Hydrogen.eigen(rmax, dr);}
                if(run == "-plot"){Hydrogen.plot(rmax=20, dr=0.1);}
                if(run == "-plotrmax"){Hydrogen.rmax(rmax, dr);}
                if(run == "-plotdr"){Hydrogen.dr(rmax, dr);}

            }


            // WriteLine("------------TASK B------------"); 

            // matrix H = hamiltonian(rmax, dr);
            // WriteLine(H);






    }

}