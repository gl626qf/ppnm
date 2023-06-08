Out.txt : main.exe Makefile
	mono main.exe -numbers:1,2,3,4,5 > Out.txt

main.exe : main.cs
	mcs main.cs -target:exe -out:$@

clean:
	$(RM) *.exe *.dll [Oo]ut* log*




