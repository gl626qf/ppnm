iall : Out.txt TestFunctionPlotA.svg PlotB.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib

PlotB.svg : plotB.gpi TrainPointsB.txt
	gnuplot $<

TestFunctionPlotA.svg : plotA.gpi TrainPointsA.txt
	gnuplot $<

Out.txt TrainPointsA.txt TrainPointsB.txt : main.exe
	mono $< 1> $@ 


main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : ann.cs $(DIR)/mixed/qnewton.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
