Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs matrix.dll QRGS.dll
	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
clean : 
	$(RM) *.dll *.exe [Oo]ut*