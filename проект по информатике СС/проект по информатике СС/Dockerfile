FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["проект по информатике СС/проект по информатике СС.csproj", "проект по информатике СС/"]
RUN dotnet restore "проект по информатике СС/проект по информатике СС.csproj"
COPY . .
WORKDIR "/src/проект по информатике СС"
RUN dotnet build "проект по информатике СС.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "проект по информатике СС.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "проект по информатике СС.dll"]
