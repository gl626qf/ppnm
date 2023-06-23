# DLLS = $(addprefix -reference:,$(filter %.dll,$^))
# CODE = $(filter %.cs,$^)
# MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
# MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
# MATLIB = ../../matlib
# MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')

# all : Out.txt Decay.svg

# Out.txt: main.exe
# 	mono main.exe -testB -input:decay.txt >$@

# matlib.dll : lsfit.cs $(MATRIX)
# 	$(MKLIB)



# out.decayfit.par: main.exe
# 	mono main.exe -input:decay.txt -writeFit > $@

# Decay.svg : decay.gpi out.decayfit.par
# 	gnuplot $<

# main.exe : main.cs matlib.dll
# 	$(MKEXE)



# .PHONEY : clean test

# clean:
# 	$(RM) *.exe *.dll [Oo]ut* log* err start.par *.data *.svg
# test: 
# 	echo $(RM)


all : Out.txt Plot.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib/matrix


Out.txt : main.exe
	mono $< > $@

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs lsfit.cs; $(MKLIB)


main.exe : main.cs matrix.dll ; $(MKEXE)

Plot.svg : plot.gpi DataPartABC.data DataPartABC_fit.data
	gnuplot $<


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg
