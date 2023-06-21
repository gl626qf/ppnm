# Out.txt : main.exe
# 	mono main.exe > Out.txt

# main.exe : main.cs matrix.dll QRGS.dll
# 	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe

# DIR = ../../matlib/matrix
# matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
# 	mcs -target:library -out:$@ $^

# QRGS.dll : QRGS.cs matrix.dll
# 	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
# clean : 
# 	$(RM) *.dll *.exe [Oo]ut*


Out.txt :main.exe
	mono $<>$@

lib.dll : LSF.cs  QRGS.cs matrix.cs vector.cs
	mcs -target:library -out:$@ $^

Info.txt : main.exe
	mono $< info | sed -e's/,/./g' > $@

fit.data : main.exe
	mono $< fit | sed -e's/,/./g' > $@

main.exe : main.cs lib.dll
	mcs -target:exe -out:$@ \
                $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

clean:
	rm -rf *.txt main.exe lib.dll *.svg *.data plots/*