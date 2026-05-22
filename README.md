# AlunosCrudApiCSharp

API RESTful desenvolvida em ASP.NET Core para gerenciamento de alunos e cursos, utilizando Entity Framework Core e banco de dados MySQL.

---

# 📚 Sobre o Projeto

O projeto **AlunosCrudApiCSharp** é uma API CRUD desenvolvida com foco educacional e prática de desenvolvimento backend utilizando C# e ASP.NET Core.

A aplicação permite:

- Cadastro de alunos
- Consulta de alunos
- Atualização de dados dos alunos
- Remoção de alunos
- Cadastro e gerenciamento de cursos
- Relacionamento entre alunos e cursos

---

# 🚀 Tecnologias Utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- MySQL
- Pomelo.EntityFrameworkCore.MySql
- REST API
- .NET 8

---

# 📁 Estrutura do Projeto

```bash
AlunosCrudApiCSharp/
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── src/
│   ├── Controllers/
│   │   ├── AlunoController.cs
│   │   └── CursoController.cs
│   │
│   └── Models/
│       ├── Aluno.cs
│       └── Curso.cs
│
├── Program.cs
├── appsettings.json
└── AlunosCrudApiCSharp.csproj
```

---

# ⚙️ Configuração do Banco de Dados

A string de conexão está localizada no arquivo:

```json
appsettings.json
```

Configuração atual:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=alunos_db_2;user=root;password="
}
```

## ✅ Pré-requisitos

Antes de executar o projeto, certifique-se de possuir:

- .NET SDK 8 instalado
- MySQL Server instalado e em execução
- Entity Framework CLI

Instalação da CLI do EF:

```bash
dotnet tool install --global dotnet-ef
```

---

# ▶️ Como Executar o Projeto

## 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/AlunosCrudApiCSharp.git
```

## 2. Acesse a pasta do projeto

```bash
cd AlunosCrudApiCSharp
```

## 3. Restaure as dependências

```bash
dotnet restore
```

## 4. Execute as migrations

```bash
dotnet ef database update
```

## 5. Inicie a aplicação

```bash
dotnet run
```

---

# 🌐 Endpoints da API

Base URL:

```bash
http://localhost:5000
```

ou

```bash
https://localhost:5001
```

---

# 📘 Endpoints de Alunos

## 🔹 Buscar todos os alunos

```http
GET /api/Aluno
```

---

## 🔹 Buscar aluno por ID

```http
GET /api/Aluno/{id}
```

---

## 🔹 Criar aluno

```http
POST /api/Aluno
```

### Exemplo de Body

```json
{
  "nome": "Felipe",
  "email": "felipe@email.com",
  "endereco": "Rua Exemplo",
  "telefone": "11999999999",
  "documento": "12345678900",
  "rm": "RM001",
  "cursoId": 1
}
```

---

## 🔹 Atualizar aluno

```http
PUT /api/Aluno/{id}
```

---

## 🔹 Deletar aluno

```http
DELETE /api/Aluno/{id}
```

---

# 📗 Endpoints de Cursos

## 🔹 Buscar todos os cursos

```http
GET /api/Curso
```

---

## 🔹 Buscar curso por ID

```http
GET /api/Curso/{id}
```

---

## 🔹 Criar curso

```http
POST /api/Curso
```

### Exemplo de Body

```json
{
  "nome": "Desenvolvimento de Sistemas",
  "descricao": "Curso técnico voltado ao desenvolvimento de software"
}
```

---

## 🔹 Atualizar curso

```http
PUT /api/Curso/{id}
```

---

## 🔹 Deletar curso

```http
DELETE /api/Curso/{id}
```

---

# ❤️ Health Check

Endpoint utilizado para verificar se a API está funcionando corretamente.

```http
GET /api/health
```

### Resposta

```text
API is healthy
```

---

# 🧠 Relacionamentos

O projeto possui relacionamento entre:

- Um aluno pertence a um curso
- Um curso pode possuir vários alunos

Configuração realizada no `AppDbContext` utilizando Fluent API.

---

# 🔒 CORS

A aplicação está configurada para permitir qualquer origem:

```csharp
policy.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
```

---

# 📌 Melhorias Futuras

- Implementação de autenticação JWT
- Adição de Swagger/OpenAPI
- Validações mais robustas
- Paginação
- Filtros de busca
- Dockerização
- Testes automatizados
- Repository Pattern
- DTOs
- AutoMapper

---

# 👨‍💻 Autor

Projeto desenvolvido por Felipe Garcia Fogal para fins de estudo e prática com ASP.NET Core e APIs REST.

---

# 📄 Licença

Este projeto está sob a licença MIT.