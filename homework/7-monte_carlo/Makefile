

# All: plot.svg Out.txt


# plot.svg: plot.gpi mcint.data actual_volume.data error_scale.data error_div.data hard_conv.data
# 	gnuplot $<

# Out.txt: main.exe
# 	mono $< Out| sed -e's/,/./g' >$@

# mcint.data: main.exe
# 	mono $< mcint.data | sed -e's/,/./g' >$@

# actual_volume.data: main.exe
# 	mono $< actual_volume | sed -e's/,/./g' >$@

# error_scale.data: main.exe
# 	mono $< inv_sqrt_nth | sed -e's/,/./g' >$@
# error_div.data:main.exe
# 	mono $< error_div | sed -e's/,/./g' >$@



# # matlib.dll : vector.cs
# # 	mcs -target:library -out:$@ $^

# main.exe : main.cs matlib.dll
# 	mcs -target:exe -out:$@ \
#                 $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
# clean:
# 	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*


#RM = rm ---force
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATLIB = ../../matlib
MATRIX := $(shell find $(MATLIB)/matrix -name '*.cs')

all: Out.A.txt Out.B.txt Error.svg Quasi.svg


Out.A.txt: main.exe Makefile
	mono main.exe -A > $@

Out.B.txt: main.exe Makefile
	mono main.exe -B > $@

Error.svg: error.gpi out.a.data
	gnuplot $<

Quasi.svg: quasi.gpi out.b.data
	gnuplot $<

main.exe : main.cs matlib.dll # + any library.dll files
	$(MKEXE)

matlib.dll : $(MATRIX)
	$(MKLIB)

.PHONEY : clean test all

clean:
	$(RM) *.exe *.dll [Oo]ut* log*
test: 
	echo $(RM)


