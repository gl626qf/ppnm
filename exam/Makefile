DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
DIR = ../matlib/matrix


all : Out.gauss.txt

main.exe : main.cs matrix.dll ; 
	$(MKEXE)


# Out.function1.txt : main.exe
# 	mono $< > $@ -function1

# Out.function2.txt : main.exe
# 	mono $< > $@ -function2

# Out.divFunction1.txt : main.exe
# 	mono $< > $@ -divFunction1


Out.gauss.txt : main.exe
	mono $< > $@ -gauss

matrix.dll : svarm.cs $(DIR)/matrix.cs $(DIR)/vector.cs $(DIR)/QRGS.cs ; 
	$(MKLIB)

# Out.checkQR.txt : main.exe
# 	mono $< > $@ -checkQR



# Out.THX.txt : main.exe
# 	mono $< > $@ -THX



# thx.svg : thx.gpi Out.thx.data Out.thxFit.data
# 	gnuplot $<


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data *.svg
