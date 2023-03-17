DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
# MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
# MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
GAMMA_DATA = 

Gamma.svg : gamma.gpi gamma.data factorials.data
	gnuplot $<

gamma.data : main.exe
	mono $< > $@


#Here I create the gamma function
lngamma.svg : lngamma.gpi lngamma.data factorials.data
	gnuplot $<

lngamma.data : main.exe
	mono $< > $@

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:$@ $(CODE) $(DLLS)

sfuns.dll : gamma.cs lngamma.cs erf.cs
	mcs -target:library -out:$@ $(CODE)

factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@
	echo 9 1 >>$@

main: main.exe sfuns.dll
	mkbundle -o $@ --simple $^

clean:
	$(RM) *.exe *.dll *.svg *.data main