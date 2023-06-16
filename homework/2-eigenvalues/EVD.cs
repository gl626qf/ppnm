using System;
using static System.Console;
using static System.Math;


public static class EVD{

        public static vector w;
        public static matrix V;

        public static void timesJ(matrix A, int p, int q, double theta){

        double c=Cos(theta),s=Sin(theta);
        for(int i=0;i<A.size1;i++){
            double aip=A[i,p],aiq=A[i,q];
            A[i,p]=c*aip-s*aiq;
            A[i,q]=s*aip+c*aiq;
            }
        }

        public static void Jtimes(matrix A, int p, int q, double theta){
            double c=Cos(theta),s=Sin(theta);
            for(int j=0;j<A.size1;j++){
                double apj=A[p,j],aqj=A[q,j];
                A[p,j]= c*apj+s*aqj;
                A[q,j]=-s*apj+c*aqj;
                }
        }





        public static void evd(matrix M){

        	matrix A = M.copy();
        	V = matrix.id(M.size1);
        	w = new vector(M.size1);

            A.print();
        	/* run Jacobi rotations on A and update V */
            int n = A.size1; // Getting the number of rows
            bool changed;
            do{
            changed=false;
            for(int p=0;p<n-1;p++)
            for(int q=p+1;q<n;q++){
                double apq=A[p,q], app=A[p,p], aqq=A[q,q];
                double theta=0.5*Atan2(2*apq,aqq-app);
                double c=Cos(theta),s=Sin(theta);
                double new_app=c*c*app-2*s*c*apq+s*s*aqq;
                double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
                if(new_app!=app || new_aqq!=aqq) // do rotation
                    {
                    changed=true;
                    timesJ(A,p,q, theta); // A←A*J 
                    Jtimes(A,p,q,-theta); // A←JT*A 
                    timesJ(V,p,q, theta); // V←V*J
                        }
                }
            }while(changed);


        	/* copy diagonal elements into w */
        	}

        public static (vector,matrix) cyclic(matrix M){
            matrix A=M.copy();
            matrix V=matrix.id(M.size1);
            vector w=new vector(M.size1);
            /* run Jacobi rotations on A and update V */
            int n = A.size1; // Getting the number of rows
            bool changed;
            do{
            changed=false;
            for(int p=0;p<n-1;p++)
            for(int q=p+1;q<n;q++){
                double apq=A[p,q], app=A[p,p], aqq=A[q,q];
                double theta=0.5*Atan2(2*apq,aqq-app);
                double c=Cos(theta),s=Sin(theta);
                double new_app=c*c*app-2*s*c*apq+s*s*aqq;
                double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
                if(new_app!=app || new_aqq!=aqq) // do rotation
                    {
                    changed=true;
                    timesJ(A,p,q, theta); // A←A*J 
                    Jtimes(A,p,q,-theta); // A←JT*A 
                    timesJ(V,p,q, theta); // V←V*J
                        }
                }
            }while(changed);
            // V.print("V");
            // A.print("A");
            /* copy diagonal elements into w */

            // We make check that V * V^T = 1, NEED TO APPROX THOUGH
            // matrix check1 = V * V.T;
            // check1.print("V * V.T = 1");

            matrix D = A.copy();
            D.print("The diagonal matrix");
            // A.print("looking if this is the right");

            // Trying to see if V * D * V.T = A

            matrix check2 = V * D * V.T;

            // check2.print("This needs to equal A");
            // M.print("This is A");
            // WriteLine("A and V * D * V.T is similar!"); // DO THIS WITH APPROX!!!
            // WriteLine(check2);
            // WriteLine($"Testing A = V * D * V.T: {(check2).approx(matrix.id(check2.size1))}");


            //Now we make w, by taking the diagonal of D
            // D_rowLength = D.size1
            // vector w = new vector(D_rowLength);
            for (int i = 0; i < M.size1; i++)
            {
                w[i] = D[i,i];
            }
            // w.print("This is w");

            return (w,V);
            }



} //EVD class