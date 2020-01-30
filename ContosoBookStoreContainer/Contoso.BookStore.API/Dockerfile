FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Contoso.BookStore.API.csproj", ""]
RUN dotnet restore "Contoso.BookStore.API.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Contoso.BookStore.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Contoso.BookStore.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://+:8080
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contoso.BookStore.API.dll"]