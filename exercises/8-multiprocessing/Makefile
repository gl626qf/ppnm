TIME = time --portability --append --output $@
N = 2e5

Out.txt : main.exe
	>$@
	$(TIME) mono main.exe -terms:$N -threads:1 >> $@
	$(TIME) mono main.exe -terms:$N -threads:2 >> $@
	$(TIME) mono main.exe -terms:$N -threads:3 >> $@
	$(TIME) mono main.exe -terms:$N -threads:4 >> $@

main.exe : main.cs
	mcs $<

test: out1 out2 out3 out4

out1: main.exe ; mono main.exe -terms:$N -threads:1 >> $@
out2: main.exe ; mono main.exe -terms:$N -threads:1 >> $@
out3: main.exe ; mono main.exe -terms:$N -threads:1 >> $@
out4: main.exe ; mono main.exe -terms:$N -threads:1 >> $@



clean :
	rm -f Out.txt main.exe 