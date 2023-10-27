FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/MyLibrary.Api/MyLibrary.Api.csproj", "src/MyLibrary.Api/"]
COPY ["src/MyLibrary.Infrastructure/MyLibrary.Infrastructure.csproj", "src/MyLibrary.Infrastructure/"]
COPY ["src/MyLibrary.Application/MyLibrary.Application.csproj", "src/MyLibrary.Application/"]
COPY ["src/MyLibrary.Domain/MyLibrary.Domain.csproj", "src/MyLibrary.Domain/"]
RUN dotnet restore "src/MyLibrary.Api/MyLibrary.Api.csproj"
COPY . .
WORKDIR "/src/src/MyLibrary.Api"
RUN dotnet build "MyLibrary.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyLibrary.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyLibrary.Api.dll"]
