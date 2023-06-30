DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib
MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')
# GENLIST := $(shell find $(MATLIB)/genlist -name '*.cs')

# all: ode.svg ode_damp.svg ode_planets.svg
all : harmonicData.svg pendulumFriction.svg testFunc.svg lotkaVolterra.svg




main.exe : main.cs matlib.dll
	mcs -target:exe -out:$@ $(CODE) $(DLLS)


Out.harmonicData.data: main.exe
	mono main.exe > $@ -harmonic


Out.testFunc.data: main.exe
	mono main.exe > $@ -testingODE


Out.pendulumFriction.data: main.exe
	mono main.exe > $@ -pendulumFriction


Out.lotkaVolterra.data: main.exe
	mono main.exe > $@ -lotkaVolterra



harmonicData.svg : harmonicData.gpi Out.harmonicData.data 
	gnuplot $<


testFunc.svg : testFunc.gpi Out.testFunc.data 
	gnuplot $<

hydrogen.svg : hydrogen.gpi Out.hydrogen.data 
	gnuplot $<


pendulumFriction.svg : pendulumFriction.gpi Out.pendulumFriction.data
	gnuplot $<



lotkaVolterra.svg : lotkaVolterra.gpi Out.lotkaVolterra.data
	gnuplot $<



matlib.dll : $(MATRIX)
	$(MKLIB)

.PHONEY : clean test all BData

clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt *.data
test: 
	echo $(RM)
