DIR = $(HOME)/repos/ppnm/matlib/complex          # or whatever your directory is
cmath.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
		mcs -target:library -out:./cmath.dll $^

main.exe : main.cs cmath.dll
		mcs -reference:cmath.dll main.cs

