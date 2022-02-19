#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8083
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApiTechnicalChallenge/WebApiTechnicalChallenge.csproj", "WebApiTechnicalChallenge/"]
RUN dotnet restore "WebApiTechnicalChallenge/WebApiTechnicalChallenge.csproj"
COPY . .
WORKDIR "/src/WebApiTechnicalChallenge"
RUN dotnet build "WebApiTechnicalChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiTechnicalChallenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiTechnicalChallenge.dll"]