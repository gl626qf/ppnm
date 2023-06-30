
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../../matlib




All : Out.txt




main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : qnewton.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 

Out.txt : main.exe
	mono $< > $@ -rosenbrock -himmelblau 2> log
	 
Out.rosenbrock.txt : main.exe
	mono $< $@ -rosenbrock 2> log


Out.himmelblau.txt : main.exe
	mono $< $@ -himmelblau 2> log






i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.svg log*
