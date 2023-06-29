all : taskA.svg Out.txt

Out.txt : main.exe
	mono $< > $@ -qspline

main.exe : main.cs matrix.dll QRGS.dll
	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll


spline.dll : spline.cs
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll


datapoints.data : main.exe
	mono $< >$@ -data


linterpdata.data : main.exe
	mono $< >$@ -interpolate


Out.qspline.txt: main.exe Makefile
	mono main.exe > $@ -qspline

data_integrate.data : main.exe
	mono $< >$@ -integrate



taskA.svg : taskA.gpi datapoints.data linterpdata.data data_integrate.data
	gnuplot $<



clean : 
	$(RM) *.dll *.exe [Oo]ut* *.data *.txt *.svg

