ALL : Out.txt 

# Out.txt : main.exe
# 	mono main.exe > Out.txt

Out.txt : main.exe
	mono $< > $@ -AB

main.exe : main.cs matrix.dll QRGS.dll
	mcs main.cs -reference:matrix.dll -reference:QRGS.dll -target:exe -out:main.exe


DIR = ../../matlib/matrix
matrix.dll : $(DIR)/vector.cs $(DIR)/matrix.cs
	mcs -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll
	mcs QRGS.cs -target:library -out:$@ -reference:matrix.dll
clean : 
	$(RM) *.dll *.exe [Oo]ut* 



Out.time.txt : main.exe
	mono $< > $@ -time

# Ns = $$(seq 400 50 1000)
# out.times.data : main.exe
# 	>$@
# 	for N in $(Ns); do \
# 	echo $$N; \
# 	$(TIME) -f "$$N %U" mono -time -dim:$$N >log ; \
# 	done

# out.times.data : main.exe
# 	>$@
# 	for N in $$(seq 100 100 800); do \
# 		time --format "$$N %e" --output $@ --append \
# 		mono $< -size:$$N 2>err ;\
# 	done