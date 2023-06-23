ALL : Out.rosenbrock.txt Out.himmelblau.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib





Out.rosenbrock.txt : main.exe
	mono $< $@ -rosenbrock 2> log.Out


Out.himmelblau.txt : main.exe
	mono $< $@ -himmelblau 2> log.Out

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : qnewton.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
