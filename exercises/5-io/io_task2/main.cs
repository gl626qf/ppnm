using System;
using static System.Console;
using static System.Math;

public static class main{
public static void Main(string[] args){ // We take the string from input
char[] split_delimiters = {' ','\t','\n'}; // We give split symbols
var split_options = StringSplitOptions.RemoveEmptyEntries; // We remove the different symbols and make list
for( string line = ReadLine(); line != null; line = ReadLine() ){
		var numbers = line.Split(split_delimiters,split_options);
			foreach(var number in numbers){
						double x = double.Parse(number);
								WriteLine($"{x} {Sin(x)} {Cos(x)}");
								                }
			        }
} // Main
} // main
