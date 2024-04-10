FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet build "KeyNerd.Api/KeyNerd.Api.csproj" -c Release -o /app/build


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "KeyNerd.Api.dll"]
EXPOSE 80