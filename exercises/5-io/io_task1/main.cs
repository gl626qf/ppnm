using System;
using static System.Console;
using static System.Math;

// public static class main {
// public static void Main(string[] args){
// 	foreach(var arg in args){
// 		var words = arg.Split(':');
// 			WriteLine("We get the following numbers");
// 			if(words[0]=="-numbers"){
// 			var numbers=words[1].Split(',');
// 			foreach(var number in numbers){
// 			double x = double.Parse(number);
// 			WriteLine($"x = {x}, Sin(x) = {Sin(x)}, Cos(x) = {Cos(x)}");
			
// 				}
// 			}
// 	}
// } //Main
// } //main


public static class main{
public static void Main(string[] args){
foreach(var arg in args){
	var words = arg.Split(':');
	if(words[0]=="-numbers"){
		var numbers=words[1].Split(',');
		foreach(var number in numbers){
			double x = double.Parse(number);
			WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
	}
}
}