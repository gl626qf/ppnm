using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;




public class breitwigner{

    public static List<double> energy, signal, error;
    
    public static int nDataPoints;

    public static double breitWigner(double A, double E, double G, double m){
        return A / (Pow(E - m, 2) + Pow(G, 2) / 4);
    }


    public static double dervBreitWigner(vector x){
        double m = x[0];
        double G = x[1];
        double A = x[2];

        double sum_ = 0;
        for(int i = 0; i < nDataPoints; i++){
            double E = energy[i];
            double y = signal[i];
            double dy = error[i];
            sum_ += Pow((breitWigner(A, E, m, G) - y)/dy, 2);
        }
        return sum_;
    }




}
