all : Out.checkQR.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib/matrix


Out.checkQR.txt : main.exe
	mono $< > $@ -checkQR

matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs lsfit.cs; $(MKLIB)


main.exe : main.cs matrix.dll ; $(MKEXE)

# Plot.svg : plot.gpi DataPartABC.data DataPartABC_fit.data
# 	gnuplot $<


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg
