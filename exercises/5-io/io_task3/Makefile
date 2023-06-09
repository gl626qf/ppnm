# Out.txt : main.exe Makefile
# 	mono main.exe -numbers:1,2,3,4,5 > Out.txt

# main.exe : main.cs
# 	mcs main.cs -target:exe -out:$@

# clean:
# 	$(RM) *.exe *.dll [Oo]ut* log*




all: out.txt
	cat $<

out.txt: main.exe
	mono main.exe -input:input.txt -output:out.txt

main.exe: main.cs
	mcs $< -target:exe -out:$@

clean: 
	rm -rf Out.txt main.exe

