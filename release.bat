@echo off
dotnet build src/Umbraco9KeyValueList --configuration Release /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=../../releases/nuget