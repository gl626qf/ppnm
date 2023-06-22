DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib
MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')

all : Out.A.txt Out.B.txt decay.svg

Out.A.txt: main.exe
	mono main.exe -test >$@

Out.B.txt: main.exe
	mono main.exe -testB -input:decay.txt >$@

out.lndecay.data : main.exe
	mono main.exe -input:decay.txt -writeData > $@

out.decayfit.par: main.exe
	mono main.exe -input:decay.txt -writeFit > $@

decay.svg : decay.gpi out.lndecay.data out.decayfit.par
	gnuplot $<

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : ls.cs $(MATRIX) 
	$(MKLIB)

.PHONEY : clean test

clean:
	$(RM) *.exe *.dll [Oo]ut* log* err start.par *.data
test: 
	echo $(RM)