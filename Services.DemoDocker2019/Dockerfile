FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Services.DemoDocker2019/Services.DemoDocker2019.csproj Services.DemoDocker2019/
RUN dotnet restore Services.DemoDocker2019/Services.DemoDocker2019.csproj
COPY . .
WORKDIR /src/Services.DemoDocker2019
RUN dotnet build Services.DemoDocker2019.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Services.DemoDocker2019.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 8060
ENTRYPOINT ["dotnet", "Services.DemoDocker2019.dll"]
