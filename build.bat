"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" C:\Users\yasushi\code\CitiesSkylinesTestMod 
taskkill /f /t /im "Cities.exe"

timeout /t 5 /nobreak

psexec \\localhost -i "C:\Program Files (x86)\Steam\steamapps\common\Cities_Skylines\Cities.exe"