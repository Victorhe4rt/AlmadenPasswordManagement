# Almaden Password Management

## Descrição

Este repositório contém o projeto **AlmadenPasswordManagement**, que pode ser executado utilizando Docker Compose ou manualmente rodando cada projeto que foi separado em back end / Front ent

Tecnologias utilizadas 

Padrão de projeto : Repository pattern com Generics

Back - end : C#,netcore,entity framework ,Swagger

Front end : Angular , material ui ,nginx 

Banco de dados : Sql server 

## Screenshots do projeto

Tela de login

![{A199FE60-3AAF-4030-AA64-14A119AE8288}](https://github.com/user-attachments/assets/fd68ed68-2165-44ba-8194-9f95fc819374)

Tela home 

Todos os metodos contidos nos cards estão funcionais comunicando com a API

Swagger
![{90B50AFC-3F12-47E3-9959-318B200D02F4}](https://github.com/user-attachments/assets/e1596f7e-2670-4954-84e4-e21ece42bdfd)

Cards
![{00AA68B7-2A87-454C-AE71-8E68D81C8C92}](https://github.com/user-attachments/assets/b2b9575d-2ab3-4eb8-8254-c348c4d34474)


Card visualização de senha 

![{FB7E6097-4026-4DFA-9089-3E81072C9C60}](https://github.com/user-attachments/assets/1b04a97d-166b-483f-acbb-840017c15db3)




## Ponto de Atenção

Caso haja algum problema ao rodar o projeto utilizando o Docker Compose, siga os passos abaixo para rodar manualmente os serviços:

**Dependências **

NODE.js 

Netcore 

Instalar angular CLI npm install @angular/cli`

1)Acessar o program.cs do projeto do back-end e comentar a as variavies do dockerfile para pegar direto em memória


![{BACF5065-701A-4F6F-915E-603EDB8FDC2A}](https://github.com/user-attachments/assets/ec8f9f4b-3920-453c-a5d1-2208a0fe362d)

2)Acessar o arquivo ENV do projeto front-end que se encontra dentro do diretório de componentes e trocar para  a porta que está rodando o seu back end


![{5AFDC5B9-B71E-4D38-AE4E-56AD8E8A6356}](https://github.com/user-attachments/assets/d9d16b4b-2ff6-4c2b-93bb-ec3ce20b1a05)

3)No diretório onde está o projeto back-end -> program.cs deve ser rodado o comando 
```bash
dotnet run
```

3)No diretório onde está o projeto front-end -> angular.json deve ser rodado o comando 
```bash
ng serve
```




## Pré-requisitos (Docker)

- **Docker** instalado na sua máquina. Para instalar o Docker, siga as instruções no [site oficial](https://www.docker.com/get-started).
- **Docker Compose** instalado. Caso não tenha, consulte [Docker Compose documentation](https://docs.docker.com/compose/install/) para instalar.

## Como rodar o projeto (Docker)

### 1. Clone o repositório

Primeiro, clone o repositório do projeto em sua máquina local:

```bash
git clone https://github.com/seu-usuario/AlmadenPasswordManagement.git
cd AlmadenPasswordManagement''
```

### 2. Rode os seguintes comando assim que acessar o diretório

```bash
Docker-compose up -build
```
#### Verificar serviços rodando usando seguinte comando 

```bash
docker-ps
```
![{84A7CD1C-FF87-462B-8760-DFB375111DE3}](https://github.com/user-attachments/assets/d6a10253-63be-4f61-aec3-779da2072fc6)


