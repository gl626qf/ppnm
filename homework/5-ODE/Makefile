DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib
MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')
# GENLIST := $(shell find $(MATLIB)/genlist -name '*.cs')

# all: ode.svg ode_damp.svg ode_planets.svg
all : harmonicData.svg pendulumFriction.svg




main.exe : main.cs matlib.dll
	mcs -target:exe -out:$@ $(CODE) $(DLLS)




Out.harmonicData.data: main.exe
	mono main.exe > $@ -harmonic


Out.pendulumFriction.data: main.exe
	mono main.exe > $@ -pendulumFriction



harmonicData.svg : harmonicData.gpi Out.harmonicData.data 
	gnuplot $<


pendulumFriction.svg : pendulumFriction.gpi Out.pendulumFriction.data
	gnuplot $<

# ode_planets.svg : planets.gpi BData
# 	gnuplot planets.gpi




matlib.dll : $(MATRIX)
	$(MKLIB)

.PHONEY : clean test all BData

clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt *.data
test: 
	echo $(RM)
