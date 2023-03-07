using System;
using static System.Math;
public partial class matrix{

	public readonly int size1, size2;
	public double[][] data;

	public matrix(int n, int m){
			size1=n; size2=m; data = new double[size2][];
				for(int j=0;j<size2;j++) data[j]=new double[size1];
					}

	public double this[int r,int c]{
			get{return data[c][r];}
				set{data[c][r]=value;}
					}

	public vector this[int c]{
			get{return (vector)data[c];}
				set{data[c]=(double[])value;}
					}

	public matrix(string s){
		        string[] rows = s.Split(';');
			        size1 = rows.Length;
					char[] delimiters = {',',' '};
					        var options = StringSplitOptions.RemoveEmptyEntries;
						        size2 = rows[0].Split(delimiters,options).Length;
							        data = new double[size2][];
									for(int j=0;j<size2;j++) data[j]=new double[size1];
									        for(int i=0;i<size1;i++){
											                string[] ws = rows[i].Split(delimiters,options);
													                for(int j=0; j<size2; j++){
																                        this[i,j]=double.Parse(ws[j]);
																			                        }
															                }
										        }

	public static matrix operator+ (matrix a, matrix b){
			matrix c = new matrix(a.size1,a.size2);
				for(int j=0;j<a.size2;j++)
							for(int i=0;i<a.size1;i++)
											c[i,j]=a[i,j]+b[i,j];
					return c;
						}

	public static matrix operator-(matrix a){
			matrix c = new matrix(a.size1,a.size2);
				for(int j=0;j<a.size2;j++)
							for(int i=0;i<a.size1;i++)
											c[i,j]=-a[i,j];
					return c;
						}

	public static matrix operator-(matrix a, matrix b){
			matrix c = new matrix(a.size1,a.size2);
				for(int j=0;j<a.size2;j++)
							for(int i=0;i<a.size1;i++)
											c[i,j]=a[i,j]-b[i,j];
					return c;
						}

	public static matrix operator/(matrix a, double x){
			matrix c=new matrix(a.size1,a.size2);
				for(int j=0;j<a.size2;j++)
							for(int i=0;i<a.size1;i++)
											c[i,j]=a[i,j]/x;
					return c;
	}

	
public static matrix operator*(double x, matrix a){ return a*x; }
public static matrix operator*(matrix a, double x){
		matrix c=new matrix(a.size1,a.size2);
			for(int j=0;j<a.size2;j++)
						for(int i=0;i<a.size1;i++)
										c[i,j]=a[i,j]*x;
				return c;
}
	


public static matrix operator* (matrix a, matrix b){
	        var c = new matrix(a.size1,b.size2);
		        for (int k=0;k<a.size2;k++)
				        for (int j=0;j<b.size2;j++)
								{
								double bkj=b[k,j];
								var cj=c.data[j];
								var ak=a.data[k];
								int n=a.size1;
								for (int i=0;i<n;i++){
									//c[i,j]+=a[i,k]*b[k,j];
									cj[i]+=ak[i]*bkj;
								}
							}
			return c;
}
																				            










