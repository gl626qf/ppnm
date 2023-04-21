Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs matrix.dll QRGS.dll jacobiRotate.dll
	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -reference:jacobiRotate.dll -target:exe -out:main.exe

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ $^

jacobiRotate.dll : jacobiRotate.cs matrix.dll
	mcs jacobiRotate.cs -target:library -out:$@ -reference:matrix.dll

QRGS.dll : QRGS.cs matrix.dll
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
clean : 
	$(RM) *.dll *.exe [Oo]ut*



# Out.txt : main.exe
# 	mono main.exe > Out.txt

# main.exe : main.cs matrix.dll QRGS.dll jacobiRotate.dll
# 	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -reference:jacobiRotate.dll -target:exe -out:main.exe

# DIR = ../../matlib/matrix
# matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
# 	mcs -target:library -out:$@ $^

# jacobiRotate.dll : jacobiRotate.cs matrix.dll
# 	mcs jacobiRotate.cs -target:library -out:$@ -reference:matrix.dll

# QRGS.dll : QRGS.cs matrix.dll
# 	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll

# clean : 
# 	$(RM) *.dll *.exe [Oo]ut*
