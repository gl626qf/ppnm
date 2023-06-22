# Out.txt : main.exe
# 	mono main.exe > Out.txt

# main.exe : main.cs matrix.dll QRGS.dll
# 	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe

# DIR = ../../matlib/matrix
# matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
# 	mcs -target:library -out:$@ $^

# QRGS.dll : QRGS.cs matrix.dll
# 	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
# clean : 
# 	$(RM) *.dll *.exe [Oo]ut*


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