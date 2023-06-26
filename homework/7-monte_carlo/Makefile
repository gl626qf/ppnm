DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib
MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')


all: Out.3Dshapes.txt Error.svg 
# all: Out.3Dshapes.txt Out.mcUnitCircle.txt Out.divVolume.txt Out.invSqrt.txt Out.divError.txt



main.exe : main.cs matlib.dll monteCarlo.cs shapes.cs
	$(MKEXE)


matlib.dll : $(MATRIX)
	$(MKLIB)




Out.2Dshapes.txt: main.exe Makefile
	mono main.exe > $@ -2Dshapes

Out.3Dshapes.txt: main.exe Makefile
	mono main.exe > $@ -3Dshapes

Out.mcUnitCircle.txt: main.exe Makefile
	mono main.exe > $@ -mcUnitCircle


Out.divVolume.txt: main.exe Makefile
	mono main.exe > $@ -divVolume


Out.invSqrt.txt: main.exe Makefile
	mono main.exe > $@ -invSqrt


Out.divError.txt: main.exe Makefile
	mono main.exe > $@ -divError




Error.svg: error.gpi Out.divVolume.txt Out.mcUnitCircle.txt
	gnuplot $<

# Error.svg: error.gpi Out.divError.txt 
# 	gnuplot $<

# Quasi.svg: quasi.gpi out.b.data
# 	gnuplot $<




clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg



