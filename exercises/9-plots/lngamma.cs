using static System.Math;

public static partial class sfuns{

public static double lngamma(double x){
///single precision gamma function (Gergo Nemes, from Wikipedia)
System.Console.WriteLine("The lngamma function");
if(x<0)return double.NaN;
if(x<9)return lngamma(x+1) - Log(x);

double lngamma_=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
return (lngamma_);
}

}//class