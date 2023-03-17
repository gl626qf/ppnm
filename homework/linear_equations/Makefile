DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
MATRIXLIB = ~(HOME)/repos/ppnm/matlib/matrix/

###TRY IMPLEMENT THIS
#  instead of our usual
# mono main.exe >Out.txt
# you should say
# MONO_PATH=/path/to/my/dll/folder mono main.exe >Out.txt

all : main.exe Out.txt


Out.txt : main.exe
	mono main.exe > Out.txt


main.exe : main.cs ; $(MKEXE)



#Havde ikke navngivet stien rigtigt. MÅSKE ER DET STADIGVÆK EN FEJL
matrix.dll : $(MATRIXLIB)/matrix.cs $(MATRIXLIB)/vector.cs ; $(MKLIB)

