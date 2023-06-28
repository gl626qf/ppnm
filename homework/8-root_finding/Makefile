
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib

All : Out.equation1.txt Out.equation2.txt Out.rosenbrock.txt \
 Out.hydrogen.txt hydrogen.svg Out.hydrogenRmin.txt \
 Out.hydrogenRmax.txt Out.hydrogenAcc.txt Out.hydrogenEps.txt taskB.svg 


Out.equation1.txt : main.exe
	mono $< > $@ -A

Out.equation2.txt : main.exe
	mono $< > $@ -B

Out.rosenbrock.txt : main.exe
	mono $< > $@ -rosenbrock


Out.hydrogen.txt : main.exe
	mono $< > $@ -hydrogen



Out.hydrogenInvestigate.txt : main.exe
	mono $< > $@ -hydrogenInvestigate


hydrogen.svg : hydrogen.gpi energy0.data
	gnuplot $<



# Now the task B 

Out.hydrogenRmax.txt : main.exe
	mono $< > $@ -hydrogenRmax


Out.hydrogenRmin.txt : main.exe
	mono $< > $@ -hydrogenRmin

Out.hydrogenAcc.txt : main.exe
	mono $< > $@ -hydrogenAcc


Out.hydrogenEps.txt : main.exe
	mono $< > $@ -hydrogenEps



taskB.svg : taskB.gpi rmax.data rmin.data acc.data eps.data
	gnuplot $<


main.exe : main.cs matlib.dll ODE.cs
	$(MKEXE)

matlib.dll: root_finder.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
