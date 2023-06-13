using System;
using static System.Console;
using static System.Math;



public class main{



    
    public static bool checkUpperTriangular(matrix A){
        

        int N = A.size1;
        for (int i = 1; i < N; i++){
            for (int j = 0; j < i; j++){
                if (A[i, j] != 0){
                    return false;
                }
            }
        }
        return true;
    }

    public static bool checkQTQ(matrix A, matrix B){
        return B.approx(A);

    }





    

    public static void Main(){

            WriteLine("------------TASK A------------"); // Maybe make it not hardcoded


            //Making make the Next to Nextdouble

            //random tall
            // var random = new Random(Guid.NewGuid().GetHashCode());
            var random = new Random();
            int random_n = random.Next(2,7);
            int random_m = random.Next(2,random_n);
            // Here the matrix library is used 
            matrix random_a = new matrix(random_n, random_m);
            for(int i=0;i<random_n;i++){
                for(int j=0;j<random_m;j++){
                    random_a[i,j] = random.NextDouble();
                }
            }
            



            WriteLine("\n \n");
            WriteLine("----Decomp Testing----");


            matrix A = random_a.copy();
            matrix Q = random_a.copy();
            matrix R = new matrix(random_m, random_m);

            Q.print("This is Q before decomposition");
            R.print("This is R before decomposition");


            //We use decomposition
            QRGS.decomp(Q, R);
            
            //We check the different matrices after decomp
            Q.print("This is Q after decomposition");
            R.print("This is R after decomposition");


            //We need to check that R is upper triangular
            // WriteLine($"checkUpperTriangular(R)) is {checkUpperTriangular(R)}";


            WriteLine($"checkUpperTriangular(R) is {checkUpperTriangular(R)}");
        

        	R.print("Check that R is upper triangular, R = \n");
            WriteLine($"Testing if Q.T * A is equal to the identity matrix: {((Q.T)*Q).approx(matrix.id(random_m))}");


            WriteLine($"QR = A: {A.approx(Q*R)}");



            

            WriteLine("\n \n");
            WriteLine("----Solve Testing----");
            // Making square matrix
            matrix random_square = new matrix(random_n, random_n);
            for(int i=0;i<random_n;i++){
                for(int j=0;j<random_n;j++){
                    random_square[i,j] = random.NextDouble();
                }
            }



            random_square.print("Random square matrix");


            vector random_b = new vector(random_n);

            for (int i=0; i<random_n;i++){
                random_b[i] = random.NextDouble();
            }
            random_b.print("Random vector of size b");


            // Making square matrix
            matrix A_square = random_square.copy();
            // Making for later
            matrix A2_square = random_square.copy();

            matrix R_square = new matrix(random_n, random_n);
            vector b_square = random_b.copy();

            A_square.print("A before QR");
            R_square.print("R before QR");
            
            QRGS.decomp(A_square,R_square);
            
            A_square.print("A after QR");
            R_square.print("R after QR");


            // WriteLine($"Testing if A.T * A is equal to the identity matrix: {(A_square.T * A_square).approx(matrix.id(random_n))}");


            //Now we need to solve 

            vector x = QRGS.solve(A_square, R_square, b_square);
            x.print("Solution vector x");

            //Checking Ax = b. Need to Convert the A matrix back by multiplying with R
            vector Ax = (A_square * R_square) * x;


            WriteLine("We see if Ax = b");
            // Ax.print("Ax");
            // b_square.print("b");
            WriteLine($"Checking if they are equal : {Ax.approx(b_square)}");




            WriteLine("------------TASK B------------");


            // int random_n = random.Next(2,7);
            // matrix A_b = new matrix(rand_s, rand_s);
            // for(int i=0;i<rand_s;i++){
            //         for(int j=0;j<rand_s;j++){
            //                 A_b[i,j] = random.NextDouble();
            //         }
            // }
            // A_b.print("A:");

            // check inverse function
            // matrix Q_b = A_b.copy();
            // matrix R_b = new matrix(Q_b.size2, Q_b.size2);
            // QRGS.decomp(Q_b, R_b);
            // matrix B = QRGS.inverse(Q_b, R_b);
            // B.print("B:");

            A2_square.print("Random square matrix: A");

            // To test with later in the AB = I case
            matrix A2_test = A2_square.copy();

            matrix R2_square = new matrix(A2_square.size2, A2_square.size2);

            R2_square.print("Random square matrix: R");

            QRGS.decomp(A2_square, R2_square);

            matrix B = QRGS.inverse(A2_square, R2_square);

            B.print("The inverse matrix: B");

            WriteLine("Now we test if AB = I");
            // (A2_square * B).approx(matrix.id(random_m));
            // WriteLine((A2_square * B).approx(matrix.id(random_n)));

            // WriteLine(matrix.id(random_m));
            WriteLine($"Testing if Q.T * A is equal to the identity matrix: {((A2_test) * B).approx(matrix.id(A2_square.size1))}");
            // WriteLine(matrix.id(random_n));




            // matrix check4 = A_b*B;
            // R_b.set_unity();
            // if(R_b.approx(check4)){
            //     WriteLine("B is the inverse of A.");
            // }
            // else{
            //     WriteLine("B is not the inverse of A.");
            // }


            // matrix C_square = random_square.copy();
            


            // matrix C = QRGS.inverse(C_square);

            

            // C_square.print("Random C_square matrix");

            












        


    }
}
