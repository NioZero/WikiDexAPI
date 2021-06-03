#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY ["WikiDex.Entities/*.csproj", "WikiDex.Entities/"]
COPY ["WikiDex.Business/*.csproj", "WikiDex.Business/"]
COPY ["WikiDex.UnitTests/*.csproj", "WikiDex.UnitTests/"]
COPY ["WikiDexAPI/*.csproj", "WikiDexAPI/"]
RUN dotnet restore
COPY . .
WORKDIR "/src/WikiDexAPI"
RUN dotnet build "WikiDexAPI.csproj" -c Release -o /app/build

# testing
FROM build AS testing
WORKDIR "/src/WikiDexAPI"
RUN dotnet build "WikiDexAPI.csproj" -c Release -o /app/build
WORKDIR "/src/WikiDex.UnitTests"
RUN dotnet test

# publish
FROM build AS publish
RUN dotnet publish "WikiDexAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WikiDexAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WikiDexAPI.dll
