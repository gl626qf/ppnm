using System;
using static System.Console;


public partial class main
{
	public static void Main(){
		string s; double x;
		s = System.Console.In.ReadLine(); /* or s = System.Console.ReadLine(); */
		x = double.Parse(s);
		/* or */
		//System.IO.TextReader /* or just var */ stdin = System.Console.In;
		//s = stdin.ReadLine();
		//x = double.Parse(s);
		WriteLine(x);


	} //Main


} //main


