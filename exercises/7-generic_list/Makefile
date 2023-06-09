# Out.txt : main.exe
# 	mono $< 1> $@ 2> log
# main.exe : main.cs genlist.dll
# 	mcs -target:exe -out:$@ \
# 		$(addprefix -reference:,$(filter %.dll,$^)) \
# 		$(filter %.cs,$^)

# genlist.dll : genlist.cs
# 	mcs -target:library -out:$@ $<

# clean:
# 	$(RM) *.exe *.dll [Oo]ut* log*i



Out.txt: main.exe
	mono main.exe $$(cat input.txt) > Out.txt

main.exe: main.cs genlist.dll
	mcs -target:exe -out:$@ \
		$(addprefix -reference:,$(filter %.dll,$^)) \
		$(filter %.cs,$^)
		
genlist.dll : genlist.cs
	mcs -target:library -out:$@ $<


clean:
	rm -rf Out.txt main.exe *.dll