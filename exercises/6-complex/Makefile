# DIR = $(HOME)/repos/ppnm/matlib/complex          # or whatever your directory is
# cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
# 		mcs -target:library -out:./cmath.dll $^



# Out.txt : main.exe Makefile
# 	mono main.exe > Out.txt



# main.exe : main.cs cmath.dll
# 	mcs -reference:cmath.dll main.cs


# DIR = $(HOME)/ppnm/matlib/complex          # or whatever your directory is
# cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
# 	mcs -target:library -out:./cmath.dll $^

Out.txt : main.exe
	mono main.exe > Out.txt

DIR = ~/repos/ppnm/matlib/complex
cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

main.exe : main.cs cmath.dll
	mcs -target:exe -out:main.exe -reference:cmath.dll main.cs

clean :
	rm *.txt *.exe
