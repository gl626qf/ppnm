all : Out.txt Plot.svg
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib/matrix


Out.txt : main.exe
	mono $< > $@

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS_copy.cs ordinary_LeastSquare_fit.cs; $(MKLIB)


main.exe : main.cs matrix.dll ; $(MKEXE)

Plot.svg : plot.gpi DataPartABC.data DataPartABC_fit.data
	gnuplot $<
	


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg
