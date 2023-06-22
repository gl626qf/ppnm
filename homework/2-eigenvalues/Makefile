# Out.txt : main.exe
# 	mono main.exe > Out.txt

# main.exe : main.cs matrix.dll QRGS.dll jacobi.dll EVD.dll
# 	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -reference:jacobi.dll -reference:EVD.dll -target:exe -out:main.exe

# DIR = ../../matlib/matrix
# matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
# 	mcs -target:library -out:$@ $^

# jacobi.dll : jacobi.cs matrix.dll
# 	mcs jacobi.cs -target:library -out:$@ -reference:matrix.dll

# EVD.dll : EVD.cs matrix.dll
# 	mcs EVD.cs -target:library -out:$@ -reference:matrix.dll

# QRGS.dll : QRGS.cs matrix.dll
# 	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
# clean : 
# 	$(RM) *.dll *.exe [Oo]ut*



# Out.txt : main.exe
# 	mono main.exe > Out.txt

# main.exe : main.cs matrix.dll QRGS.dll jacobiRotate.dll
# 	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -reference:jacobiRotate.dll -target:exe -out:main.exe

# DIR = ../../matlib/matrix
# matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
# 	mcs -target:library -out:$@ $^

# jacobiRotate.dll : jacobiRotate.cs matrix.dll
# 	mcs jacobiRotate.cs -target:library -out:$@ -reference:matrix.dll

# QRGS.dll : QRGS.cs matrix.dll
# 	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll

# clean : 
# 	$(RM) *.dll *.exe [Oo]ut*


DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib

all : Out.testA.txt Dr.svg Rmax.svg Eigen.svg

Out.testA.txt: main.exe Makefile
	mono main.exe -test > $@

main.exe : main.cs matlib.dll
	$(MKEXE)

Dr.svg: dr.gpi out.dr.data
	gnuplot $<

Rmax.svg: rmax.gpi out.rmax.data
	gnuplot $<

Eigen.svg: eigen.gpi out.eigen.data
	gnuplot $<

out.dr.data : main.exe
	>$@
	for N in $$(seq 0.1 0.25 3); do \
		mono $< -plotdr -rmax:10 -dr:$$N 1>>$@ 2>err ;\
	done

out.rmax.data : main.exe
	>$@
	for N in $$(seq 1 0.5 10); do \
		mono $< -plotrmax -rmax:$$N -dr:0.1 1>>$@ 2>err ;\
	done

out.eigen.data : main.exe
	>$@
	mono main.exe -plotfuncs >>$@

matlib.dll : EVD.cs $(MATLIB)/matrix/vector.cs  $(MATLIB)/matrix/matrix.cs
	$(MKLIB)

.PHONEY : clean test

clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.data err *.svg
test: 
	echo $(RM)

