All : Out.equation1.txt Out.equation2.txt Out.rosenbrock.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib


Out.equation1.txt : main.exe
	mono $< > $@ -A

Out.equation2.txt : main.exe
	mono $< > $@ -B

Out.rosenbrock.txt : main.exe
	mono $< > $@ -rosenbrock


main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll :root_finder.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
