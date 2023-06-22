Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs matrix.dll QRGS.dll
	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
clean : 
	$(RM) *.dll *.exe [Oo]ut*


# DLLS = $(addprefix -reference:,$(filter %.dll,$^))
# CODE = $(filter %.cs,$^)
# MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
# MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
# MATLIB = ../../matlib
# LINALG := $(shell find $(MATLIB)/linalg -name '*.cs')
# GENLIST := $(shell find $(MATLIB)/genlist -name '*.cs')

# all: ode_test.svg ode_damp.svg ode_planets.svg

# ode_test.svg : ode.gpi Out.ode1.data Out.ode2.data
# 	gnuplot ode.gpi

# ode_damp.svg : damp.gpi Out.ode3.data
# 	gnuplot damp.gpi

# ode_planets.svg : planets.gpi BData
# 	gnuplot planets.gpi

# Out.ode1.data: main.exe
# 	mono main.exe -A1 > $@

# Out.ode2.data: main.exe
# 	mono main.exe -A2 > $@

# Out.ode3.data: main.exe
# 	mono main.exe -A3 > $@

# BData: main.exe
# 	mono main.exe -B

# main.exe : main.cs matlib.dll
# 	mcs -target:exe -out:$@ $(CODE) $(DLLS)

# matlib.dll : $(LINALG) $(GENLIST)
# 	$(MKLIB)

# .PHONEY : clean test all BData

# clean:
# 	$(RM) *.exe *.dll [Oo]ut* log*
# test: 
# 	echo $(RM)
