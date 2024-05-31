#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["wcc.widget.api/wcc.widget.api.csproj", "wcc.widget.api/"]
COPY ["wcc.widget.kernel/wcc.widget.kernel.csproj", "wcc.widget.kernel/"]
COPY ["wcc.widget.data/wcc.widget.data.csproj", "wcc.widget.data/"]
# COPY ["wcc.widget.integrations/wcc.widget.integrations.csproj", "wcc.widget.integrations/"]
COPY ["wcc.widget/wcc.widget.csproj", "wcc.widget/"]
RUN dotnet restore "wcc.widget.api/wcc.widget.api.csproj"
COPY . .
WORKDIR "/src/wcc.widget.api"
RUN dotnet build "wcc.widget.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "wcc.widget.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
# COPY cert /usr/local/cert
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wcc.widget.api.dll"]