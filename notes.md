# Create Application

* dotnet new sln -o solid
* dotnet new console -o App
* dotnet new xunit -o App.Tests
* dotnet sln add App/App.csproj
* dotnet sln add App.Tests/App.Tests.csproj
* dotnet add App.Tests/App.Tests.csproj reference App/App.csproj
* dotnet add App.Tests/App.Tests.csproj package FluentAssertions

# Run and Test

* dotnet run
* dotnet test
