all : Out.txt Erf.svg 
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib/



main.exe : main.cs matlib.dll 
	$(MKEXE)


matlib.dll : integration.cs $(DIR)/erf/erf.cs $(DIR)/complex/complex.cs
	mcs -target:library -out:$@ $^


Out.integrals14.txt : main.exe
	mono $< >$@ -integrals14


Out.erf.txt : main.exe
	mono $< >$@ -erfs


Out.ccTransform.txt : main.exe
	mono $< >$@ -ccTransform2


Out.txt : main.exe
	mono $< >$@ -integrals14 -ccTransform2





Erf.svg : erf.gpi Out.erf.txt
	gnuplot $<


clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/* 
