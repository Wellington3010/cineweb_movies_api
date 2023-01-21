#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["cineweb_movies_api.csproj", "."]
#RUN dotnet restore "./cineweb_movies_api.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "cineweb_movies_api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "cineweb_movies_api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#
#RUN useradd -u 2737 well
#USER well
#
#CMD ASPNETCORE_URLS="http://*:$PORT" dotnet cineweb_movies_api.dll

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "cineweb_movies_api.dll"]