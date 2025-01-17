# Usa a imagem oficial do .NET SDK 9.0 para compilar e publicar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia os arquivos do projeto e restaura as dependências
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Usa uma imagem mais leve para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expor a porta para o container
EXPOSE 80

# Define o comando para rodar a API
ENTRYPOINT ["dotnet", "AlmadenApi.dll"]
