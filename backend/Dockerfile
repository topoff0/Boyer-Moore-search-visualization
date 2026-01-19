FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["Moore.API/Moore.API.csproj", "Moore.API/"]
COPY ["Moore.Core/Moore.Core.csproj", "Moore.Core/"]
COPY ["Moore.Services/Moore.Services.csproj", "Moore.Services/"]
COPY ["Moore.Unit.Tests/Moore.Unit.Tests.csproj", "Moore.Unit.Tests/"]
COPY ["Boyer-Moore-search-visualization.sln", "."]

RUN dotnet restore "Boyer-Moore-search-visualization.sln"

COPY . .
RUN dotnet build -c Release --no-restore

FROM build AS test
RUN dotnet test Moore.Unit.Tests/Moore.Unit.Tests.csproj -c Release --no-build

FROM build AS publish
RUN dotnet publish Moore.API/Moore.API.csproj -c Release --no-build -o /out /p:UseAppHost=false

FROM base AS final
COPY --from=publish /out .
ENTRYPOINT ["dotnet", "Moore.API.dll"]

