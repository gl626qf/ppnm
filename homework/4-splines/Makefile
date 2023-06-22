all : taskA.svg 

Out.txt : main.exe
	mono main.exe > Out.txt 

main.exe : main.cs matrix.dll QRGS.dll
	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll


spline.dll : spline.cs
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll





datapoints.txt : main.exe
	mono $< >$@ -data


linterpdata.txt : main.exe
	mono $< >$@ -interpolate


data_integrate.txt : main.exe
	mono $< >$@ -integrate


taskA.svg : taskA.gpi datapoints.txt linterpdata.txt data_integrate.txt
	gnuplot $<




clean : 
	$(RM) *.dll *.exe [Oo]ut* *.data *.txt *.svg

# all : PlotA.svg PlotB.svg
# DLLS = $(addprefix -reference:,$(filter %.dll,$^))
# CODE = $(filter %.cs,$^)
# MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
# MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
# DIR = ../../matlib/matrix


# main.exe : main.cs matlib.dll ; $(MKEXE)

# PlotA.svg : PlotA.gpi datapoints.txt linterpdata.txt
# 	gnuplot $<
# PlotB.svg : PlotB.gpi data1_qspline.txt data2_qspline.txt data3_qspline.txt
# 	gnuplot $<

# datapoints.txt linterpdata.txt linintgdata.txt : mainA.exe
# 	mono $< >$@
	
# data1_qspline.txt : mainB.exe
# 	mono $< >$@


# matlib.dll : linespline.cs qspline.cs $(DIR)/vector.cs
# 	 $(MKLIB)



# i.PHONY: clean
# clean:
# 	-$(RM) out* *.txt *.exe *.dll *.data 
