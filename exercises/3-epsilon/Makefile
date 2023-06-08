# Out.txt : main.exe
# 	mono main.exe > Out.txt

# main.exe : main.cs
# 		mcs main.cs -target:exe -out:main.exe
# clean : 
# 	rm -fr Out.txt main.exe



DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)


all : main.exe
	mono main.exe > Out.txt


# If I insert $(DLLS) it does not give a fault, but if I dont have any libraries it does

main.exe : main.cs; $(MKEXE)


clean : 
	rm -fr Out.txt main.exe