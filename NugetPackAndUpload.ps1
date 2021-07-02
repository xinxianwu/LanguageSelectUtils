msbuild /p:Configuration=Release .\LanguageSelectUtils\LanguageSelectUtils.csproj
del *.nupkg
nuget pack .\LanguageSelectUtils.nuspec
pause