#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mvpstudio/dotnet:v01 as base

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DarkMatterWeb.csproj", ""]
RUN dotnet restore "./DarkMatterWeb.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DarkMatterWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DarkMatterWeb.csproj" -c Release -o /app/publish

FROM base AS final
USER mvp
WORKDIR /home/mvp/app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DarkMatterWeb.dll"]