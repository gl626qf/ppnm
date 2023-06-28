DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib

all : Out.taskA.txt Dr.svg Rmax.svg Eigen.svg

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : EVD.cs $(MATLIB)/matrix/vector.cs  $(MATLIB)/matrix/matrix.cs
	$(MKLIB)

Out.taskA.txt: main.exe Makefile
	mono main.exe > $@ -partA



out.dr.data : main.exe
	>$@
	for N in $$(seq 0.1 0.4 4); do \
		mono $< -plotdr -rmax:10 -dr:$$N 1>>$@ 2>err ;\
	done

out.rmax.data : main.exe
	>$@
	for N in $$(seq 1 0.2 10); do \
		mono $< -plotrmax -rmax:$$N -dr:0.1 1>>$@ 2>err ;\
	done



out.eigen.data : main.exe
	>$@
	mono main.exe > $@ -plot




Dr.svg: dr.gpi out.dr.data 
	gnuplot $<

Rmax.svg: rmax.gpi out.rmax.data
	gnuplot $<

Eigen.svg: eigen.gpi out.eigen.data
	gnuplot $<


.PHONEY : clean test

clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.data err *.svg
test: 
	echo $(RM)