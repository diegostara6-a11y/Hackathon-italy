# Usa l'immagine ufficiale .NET 7 SDK per build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia tutto il progetto
COPY . .

# Pubblica in modalità Release
RUN dotnet publish Hackathon-Bologna.csproj -c Release -o out

# Usa l'immagine runtime più leggera per eseguire
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copia i file pubblicati dalla build
COPY --from=build /app/out .

# Esponi la porta 80
EXPOSE 80

# Comando per avviare l'app
ENTRYPOINT ["dotnet", "Hackathon-Bologna.dll"]
