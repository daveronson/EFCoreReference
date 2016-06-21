Remove-Item .\DB\*.db
Remove-Item .\Migrations\*.*
dotnet ef migrations add Initial -o Migrations -c EFCoreRefContext
dotnet ef database update -c EFCoreRefContext