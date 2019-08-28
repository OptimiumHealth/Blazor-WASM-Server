@echo on
c:
cd \Solutions
cd ohi
cd "optimiser"
for /d /r . %%d in (bin,obj,ClientBin,Generated_Code) do @if exist "%%d" rd /s /q "%%d"
pause
