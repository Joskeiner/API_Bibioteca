FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Reslese -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "APIBiblioteca.dll"]
