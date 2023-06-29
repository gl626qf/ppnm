DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib


ALL : Out.txt plotA.svg plotB.svg


Out.txt data.data data2.data : main.exe
	mono $< 1> $@ -A -B 2> log.txt


main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : ann.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs $(DIR)/num_tools/qnewton.cs 
	 $(MKLIB) 



# PlotB.svg : plotB.gpi TrainPointsB.txt
# 	gnuplot $<

plotA.svg : plotA.gpi data.data
	gnuplot $<


plotB.svg : plotB.gpi data2.data Network2.data derv.data
	gnuplot $<



i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
