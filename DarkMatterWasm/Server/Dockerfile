#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mvpstudio/dotnet:v01 as base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Server/DarkMatterWasm.Server.csproj", "Server/"]
COPY ["Client/DarkMatterWasm.Client.csproj", "Client/"]
COPY ["Shared/DarkMatterWasm.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/DarkMatterWasm.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "DarkMatterWasm.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DarkMatterWasm.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DarkMatterWasm.Server.dll"]