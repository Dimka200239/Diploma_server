# ���������� ����������� ����� .NET ��� �������
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update && apt-get install -y --fix-missing curl libgomp1

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN apt-get update && apt-get install -y --fix-missing curl libgomp1

# ��������� LightGBM ������ 3.0.1
RUN apt-get update && \
    apt-get install -y wget && \
    wget -qO- https://github.com/microsoft/LightGBM/releases/download/v3.0.1/lib_lightgbm.so | tee /usr/local/lib/lib_lightgbm.so

WORKDIR /src
COPY ["server/server.csproj", "server/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["App/App.csproj", "App/"]
COPY ["Domain/Domain.csproj", "Domain/"]

RUN dotnet restore "server/server.csproj"
COPY . .
WORKDIR "/src/server"
RUN dotnet build "server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ������������� ���������� ��������� ��� ��������� Legacy Timestamp Behavior � Npgsql
ENV Npgsql_EnableLegacyTimestampBehavior=true
# ������������� ���� � �����������
ENV LD_LIBRARY_PATH=/usr/local/lib:$LD_LIBRARY_PATH
ENTRYPOINT ["dotnet", "server.dll"]
