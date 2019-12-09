#FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
#WORKDIR /src
#COPY ["CoreMvc/CoreMvc.csproj", "CoreMvc/"]
#RUN dotnet restore "CoreMvc/CoreMvc.csproj"
#COPY . .
#WORKDIR "/src/CoreMvc"
#RUN dotnet build "CoreMvc.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "CoreMvc.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CoreMvc.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base　　 
MAINTAINER cc   

#LABEL description="this is a test website"　　 
#LABEL version="1.0"  

WORKDIR /root/CoreMvc/ 　　 
COPY . . 　　　　 
EXPOSE 5000
ENTRYPOINT ["dotnet", "CoreMvc.dll"]　　　