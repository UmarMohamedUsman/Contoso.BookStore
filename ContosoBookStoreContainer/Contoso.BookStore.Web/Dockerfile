FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 8090

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Contoso.BookStore.Web.csproj", ""]
RUN dotnet restore "Contoso.BookStore.Web.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Contoso.BookStore.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Contoso.BookStore.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://+:8090
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contoso.BookStore.Web.dll"]