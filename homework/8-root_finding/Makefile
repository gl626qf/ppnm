
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../../matlib


All : Out.txt hydrogen.svg dontLook.txt taskB.svg 




Out.txt : main.exe
	mono $< > $@ -A -B -rosenbrock -hydrogen



hydrogen.svg : hydrogen.gpi energy0.data
	gnuplot $<



# Now the task B 

dontLook.txt : main.exe
	mono $< > $@ -hydrogenRmax -hydrogenRmin -hydrogenAcc -hydrogenEps


taskB.svg : taskB.gpi rmax.data rmin.data acc.data eps.data
	gnuplot $<


main.exe : main.cs matlib.dll ODE.cs
	$(MKEXE)

matlib.dll: root_finder.cs $(DIR)/matrix/vector.cs  $(DIR)/matrix/matrix.cs $(DIR)/matrix/QRGS.cs
	 $(MKLIB) 


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg log*
