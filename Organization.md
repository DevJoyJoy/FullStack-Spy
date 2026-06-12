# Projeto - Arquitetura e Planejamento

## To Do

### Backend
**API**
- [] Configuração dos Use Cases
- [] Configuração dos Services
**Application**
- [] Implementação dos Uses Cases
- [] Implementação dos Services
**Domain**
- 
**Infrastructure**
- [] 

### Frontend


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

- Criar grupo - **Heloise**
- Entrar em grupo - **Heloise**

## GET

- Compartilhar grupo **Anna**

## PUT

- Alterar nome do grupo **Heloise**

## DELETE

- Sair do grupo **Anna**

---

# 👤 Usuário

## POST

- Criar conta **Anna**
- Reagir a uma localização 

## GET

- Visualizar grupos **Anna**
- Selecionar grupo **Heloise**

## PUT

- Alterar dados da conta **Anna**

## DELETE

- Apagar conta **Heloise**

---

# 📍 Lugar

## POST

- Criar círculo **Anna**

## GET

- Visualizar círculos **Heloise**

## PATCH

- Alterar nome **anna**
- Alterar raio **Heloise**
- Alterar localização **Anna**

## DELETE

- Apagar círculo **Heoise**

---

# 🌎 Localização

## GET

- Obter latitude do usuário **Anna**
- Obter longitude do usuário **Heloise**
- Obter data da localização **Anna**

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

