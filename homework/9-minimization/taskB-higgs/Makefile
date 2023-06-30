iall : Higgs.svg 
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib

fitData.data : main.exe
	mono $< higgs.data 1> fitData.data 2> log.Out

Higgs.svg : higgs.gpi higgs.data fitData.data
	gnuplot $<

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : qnewton.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.svg log* Out.fitData.data fitData.data



