cls
SET MSBuildPath="C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe"
%MSBuildPath% package.build /t:BuildAndRunTests
pause