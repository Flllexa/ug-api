#Payment cielo
Remove-Item ($PSScriptRoot + "\ug-api.*.nupkg");
C:\ProgramData\NuGet\nuget.exe pack ($PSScriptRoot + "\ugapi\ugapi.csproj") -OutputDirectory $PSScriptRoot;
C:\ProgramData\NuGet\nuget.exe push ($PSScriptRoot + "\ug-api.*.nupkg");