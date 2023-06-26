
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib




# All : Out.rosenbrock.txt Out.himmelblau.txt
All : Out.higgs.txt



main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : qnewton.cs breitWigner.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


	 
Out.rosenbrock.txt : main.exe
	mono $< $@ -rosenbrock 2> log


Out.himmelblau.txt : main.exe
	mono $< $@ -himmelblau 2> log


Out.higgs.txt : main.exe
	mono $< $@ -higgs 




i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.svg log*
