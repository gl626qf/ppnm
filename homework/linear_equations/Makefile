DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)
# MATRIXLIB = ~(HOME)/repos/ppnm/matlib/matrix/
# MATRIXLIB = ../../matlib
MATRIXLIB = /home/thomas_hmm/repos/ppnm/matlib/matrix

Out.txt : main.exe
	mono $< > $@


matrix.dll : $(MATRIXLIB)/matrix.cs $(MATRIXLIB)/vector.cs 
	mcs -target:library -out:./matrix.dll $^




main.exe : main.cs matrix.dll
	mcs -reference:matrix.dll main.cs



clean:
	$(RM) *.dll *.exe [Oo]ut*



# main.exe : main.cs ; $(MKEXE) main.cs(25,23): error CS0103: The name `matrix' does not exist in the current context


# matrix.dll : $(MATRIXLIB)/matrix.cs $(MATRIXLIB)/vector.cs 
# 	mcs -target:library -out:./$@ $^
# matrix.dll : $(MATRIXLIB)/matrix.cs $(MATRIXLIB)/vector.cs ; $(MKLIB)


# mcs -target:library -out:./matrix.dll $^

#Havde ikke navngivet stien rigtigt. MÅSKE ER DET STADIGVÆK EN FEJL
# matrix.dll : $(MATRIXLIB)/matrix.cs $(MATRIXLIB)/vector.cs 
# 	mcs -target:library -out:$(MATRIXLIB)/matrix.dll $^

# SDKDIR=$(HOME)/.dotnet/sdk/6.0.102# or whatever your sdk is
# CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
# NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
# CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
# DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
# CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
# RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
# CSC = mcs
# RUN = mono

# all: out.txt; cat $<

# out.txt: main.exe
# 	$(RUN) $< > $@

# main.exe: main.cs matrix.dll
# 	$(CSC) -reference:$(word 2,$^) $<

# matrix.dll : vector.cs matrix.cs
# 	$(CSC) -target:library -out:$@ $^




###TRY IMPLEMENT THIS
#  instead of our usual
# mono main.exe >Out.txt
# you should say
# MONO_PATH=/path/to/my/dll/folder mono main.exe >Out.txt

# all : main.exe Out.txt
