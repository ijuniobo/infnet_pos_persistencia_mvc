#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SpotifyLite.Api.csproj", "SpotifyLite.Api/"]
COPY ["/identity/infnet_pos_persistencia_mvc/spotifylite/SpofityLite.Application/SpofityLite.Application.csproj", "SpofityLite.Application/"]
COPY ["/identity/infnet_pos_persistencia_mvc/spotifylite/SpotifyLite.Domain/SpotifyLite.Domain.csproj", "SpotifyLite.Domain/"]
COPY ["/identity/infnet_pos_persistencia_mvc/spotifylite/SpotifyLite.CrossCutting/SpotifyLite.CrossCutting.csproj", "SpotifyLite.CrossCutting/"]
COPY ["/identity/infnet_pos_persistencia_mvc/spotifylite/spotifylite/SpotifyLite.Repository/SpotifyLite.Repository.csproj", "SpotifyLite.Repository/"]
RUN dotnet restore "SpotifyLite.Api/SpotifyLite.Api.csproj"
COPY . .
WORKDIR "/src/SpotifyLite.Api"
RUN dotnet build "SpotifyLite.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpotifyLite.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotifyLite.Api.dll"]