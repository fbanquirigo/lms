cls
SET MSBuildPath=C:\Windows\Microsoft.NET\Framework\v4.0.30319\
%MSBuildPath%msbuild package.build /t:BuildAndPackage /flp:logfile=build-log.txt;verbosity=diagnostic
notepad.exe build-log.txt
pause