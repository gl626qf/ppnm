DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib
MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')


all: Out.txt Error.svg 



main.exe : main.cs matlib.dll monteCarlo.cs shapes.cs
	$(MKEXE)


matlib.dll : $(MATRIX)
	$(MKLIB)




Out.2Dshapes.txt: main.exe Makefile
	mono main.exe > $@ -2Dshapes

Out.txt: main.exe Makefile
	mono main.exe > $@ -3Dshapes



# Data is given here
Out.mcUnitCircle.txt: main.exe Makefile
	mono main.exe > $@ -mcUnitCircle


Out.divVolume.txt: main.exe Makefile
	mono main.exe > $@ -divVolume


Out.invSqrt.txt: main.exe Makefile
	mono main.exe > $@ -invSqrt


Out.divError.txt: main.exe Makefile
	mono main.exe > $@ -divError

# Part B

# Data is given for Part B

Out.qMcUnitCircle.txt: main.exe Makefile
	mono main.exe > $@ -qMcUnitCircle


Out.qDivVolume.txt: main.exe Makefile
	mono main.exe > $@ -qDivVolume



Out.qDivError.txt: main.exe Makefile
	mono main.exe > $@ -qDivError


Error.svg: error.gpi Out.divError.txt Out.mcUnitCircle.txt Out.qDivError.txt Out.qMcUnitCircle.txt
	gnuplot $<



clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg
