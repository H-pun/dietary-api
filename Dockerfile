#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# FROM ubuntu:latest

# Install font package (contoh: fontconfig)
# RUN apt-get update && apt-get install -y fontconfig

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Salin font ke dalam direktori /usr/share/fonts
COPY ./fonts /usr/share/fonts

# Jalankan fc-cache untuk memperbarui cache font
RUN fc-cache -f -v

WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Dietary.csproj", "./"]
RUN dotnet restore "Dietary.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Dietary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dietary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dietary.dll"]
