# Etapa 1: Construir a aplicação Angular
FROM node:18 AS build

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o package.json e o package-lock.json 
COPY package*.json ./

# Instalar as dependências
RUN npm install

# Copiar o restante dos arquivos da aplicação
COPY . .

# Construir a aplicação para produção
RUN npm run build --prod

# Etapa 2: Servir a aplicação com o Nginx
FROM nginx:alpine

# Copiar os arquivos de build do Angular para o diretório padrão do Nginx
COPY --from=build /app/dist/almaden-front /usr/share/nginx/html

# Expor a porta 80
EXPOSE 80

# Iniciar o Nginx para servir a aplicação
CMD ["nginx", "-g", "daemon off;"]
