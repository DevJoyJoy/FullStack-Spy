# Projeto - Arquitetura e Planejamento

## Estrutura da Solução

### 1. Criar as Camadas

Criar os seguintes projetos:

| Camada | Tipo |
|----------|----------|
| API | Web API |
| Application | Class Library |
| Domain | Class Library |
| Infrastructure | Class Library |

---

### 2. Configurar Referências

Adicionar as referências entre projetos conforme o diagrama de arquitetura fornecido.

> Seguir exatamente as dependências definidas nas imagens do projeto.

---

### 3. Instalar Dependências

Instalar os pacotes NuGet necessários para cada camada.

> Utilizar as dependências indicadas na documentação/imagens fornecidas.

---

### 4. Criar a Solution

Dentro do diretório raiz do projeto:

```bash
dotnet new sln

dotnet sln add .\Api\
dotnet sln add .\Application\
dotnet sln add .\Domain\
dotnet sln add .\Infrastructure\
```

Estrutura esperada:

```text
Solution
│
├── Api
├── Application
├── Domain
└── Infrastructure
```

---

### 5. Organizar Arquivos

Mover e organizar os arquivos fornecidos em:

```text
.\Data\
```

---

# Stack Tecnológica

| Categoria | Tecnologia |
|------------|------------|
| Backend | C# (.NET) |
| Frontend | React |
| Banco de Dados | SQL Server (SSMS) |

---

# Arquitetura

> 

---

# Design e Protótipo

> Definir posteriormente.

---

# Requisitos Funcionais

---

# 👥 Grupo

## POST

- Criar grupo
- Entrar em grupo

## GET

- Compartilhar grupo

## PUT

- Alterar nome do grupo

## DELETE

- Sair do grupo

---

# 👤 Usuário

## POST

- Criar conta
- Reagir a uma localização

## GET

- Visualizar grupos
- Abrir grupo

## PUT

- Alterar dados da conta

## DELETE

- Apagar conta

---

# 📍 Lugar

## POST

- Criar círculo

## GET

- Visualizar círculos

## PATCH

- Alterar nome
- Alterar raio
- Alterar localização

## DELETE

- Apagar círculo

---

# 🌎 Localização

## GET

- Obter latitude do usuário
- Obter longitude do usuário
- Obter data da localização

---

# 🔔 Funcionalidades Futuras

## Notificações

### POST

- Enviar notificação

---

# 📊 Gráficos

## GET

- Exibir dados de um período específico de um usuário

---

# 📌 Resumo da API

| Entidade | GET | POST | PUT/PATCH | DELETE |
|-----------|-------|--------|------------|---------|
| Grupo | ✅ | ✅ | ✅ | ✅ |
| Usuário | ✅ | ✅ | ✅ | ✅ |
| Lugar | ✅ | ✅ | ✅ | ✅ |
| Localização | ✅ | ❌ | ❌ | ❌ |
| Notificação | ❌ | ✅ | ❌ | ❌ |
| Gráficos | ✅ | ❌ | ❌ | ❌ |

---

<div align="center">

### 🚧 Projeto em Desenvolvimento 🚧

Arquitetura baseada em Clean Architecture + API REST

</div>