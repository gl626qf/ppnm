default: test-shell Out.txt

Out.txt : main.exe
	mono main.exe > Out.txt
sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:main.exe -reference:sfuns.dll main.cs


clean : 
	rm -f Out.txt main.exe

test-shell:
	echo $$0
