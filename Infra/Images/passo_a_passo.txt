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