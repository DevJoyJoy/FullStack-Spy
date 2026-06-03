1 - Criar as quatro camadas
    - Api (webapi)
    - Application (classlib)
    - Domain (classlib)
    - Infrastructure (classlib)

2 - Criar as referências de cada camada (conforme as imagens)

3 - Baixar as depêndencias de cada camada (conforme as imagens)

4 - Criar o .sln geral que conecta as 4 camadas. Dentro do diretório que contém as camadas:
    - dotnet new sln
    - dotnet sln add .\Api\
    - dotnet sln add .\Application\
    - dotnet sln add .\Domain\
    - dotnet sln add .\Infrastructure\
    
5 - Organizar os arquivos fornecidos (.\Data\)




Linguagens = C#, React, SSMS
Arquitetura = 
Design e prototipo mini =
Requisitos = 

# Grupo
## POST
Criar grupos
entrar em grupos

## GET
compartilhar um grupo

## DELETE
Sair do grupo 

## PUT
Mudar nome 




# User
## POST
Criar conta 
Reagir a localização

## GET
Ver grupos 
Abrir grupo 

## DELETE
Apagar conta

## PUT
Alterar dados 


# Lugar
## POST
Criar circulo

## GET
Ver Circulos

## DELETE
Apagar circulo

## PATCH
Trocar nome
Aumentar raio
Mudar localização

# Localização

## GET
Pegar latidude e longitude do usuario
Pegar Data 

# Alterações Futuras

## Notificação
### POST
Mandar notificação

# Graficos
## GET
Mostrar dados de um periodo de tempo de um usuario


