FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Docker2019/Docker2019.csproj", "Docker2019/"]
RUN dotnet restore "Docker2019/Docker2019.csproj"
COPY . .
WORKDIR "/src/Docker2019"
RUN dotnet build "Docker2019.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Docker2019.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 8050
ENTRYPOINT ["dotnet", "Docker2019.dll"]