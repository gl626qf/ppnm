main.exe : main.cs
	mcs -target:exe \
	       	-out:$@ $(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
