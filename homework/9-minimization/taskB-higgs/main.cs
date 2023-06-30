using System;
using static System.Console;
using static System.Math;
using System.IO;


static class main{

    static System.Collections.Generic.List<double> energy, signal, error;

    public static int datapoints;

    public static double dBreitWigner(vector x){
        double A = x[0];
        double m = x[1];
        double G = x[2];
        double Sum = 0;

        for(int i = 0; i < datapoints; i++){
            double E = energy[i];
            double y = signal[i];
            double dy = error[i];
            Sum += Pow((breitWigner(A, E, m, G) - y)/dy, 2);
        }

        return Sum;
    }

    public static double breitWigner(double A, double E, double m, double G){
        return A / (Pow(E - m, 2) + Pow(G, 2) / 4);
    }

    static void Main(){
        energy = new System.Collections.Generic.List<double>();
        signal = new System.Collections.Generic.List<double>();
        error  = new System.Collections.Generic.List<double>();


		StreamReader data = new StreamReader("higgs.data",true);
		StreamWriter fitParams = new StreamWriter("Out.txt", false);
		StreamWriter fitData = new StreamWriter("fitData.data", false);
	

        var separators = new char[] {' ', '\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;

        do {
            string line = data.ReadLine();
            if (line == null) break;
            string[] words = line.Split(separators, options);
            energy.Add(double.Parse(words[0]));
            signal.Add(double.Parse(words[1]));
            error.Add(double.Parse(words[2]));
        } while (true);

        datapoints = energy.Count;

        vector start = new vector(6, 120, 3);
        double A, m, G;
        vector vec = start.copy();
        int nsteps = qnewton.minimum(dBreitWigner, ref vec, 1e-2);
        A = vec[0]; m = vec[1]; G = vec[2];

        fitParams.WriteLine("-------------TASK B--------------");
        fitParams.WriteLine("Here the Higgs data is fitted and the parameters of the Breit Wigner formula is given as:");
        fitParams.WriteLine($"A = {Math.Round(A,2)}, m = {Math.Round(m,2)}, G = {Math.Round(G,2)}");
        fitParams.WriteLine($"The steps of the qnewton method: {nsteps}");
	    for(double E = energy[0];E<energy[datapoints-1];E+=1.0/64){
		    fitData.WriteLine($"{E} {breitWigner(A,E,m,G)}");}

    data.Close();
    fitParams.Close();
    fitData.Close();

    }
}

