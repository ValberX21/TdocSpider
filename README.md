# 🕷️ TdocSpider

**TdocSpider** é uma aplicação web em ASP.NET Core MVC 3.1 que permite o gerenciamento e organização de documentos, como contratos, laudos técnicos e recibos. O projeto segue uma arquitetura em camadas com foco em boas práticas de desenvolvimento.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 3.1 (MVC)
- C# (.NET Core)
- Entity Framework Core (Code First)
- SQL Server
- NUnit (Testes Unitários)
- Moq (Mocking em testes)
- Bootstrap (UI)
- Visual Studio

---

## 📁 Estrutura do Projeto
```bash
TdocSpider/
│
├── TdocSpider.Application/
│ ├── Controllers/ → Controladores MVC
│ ├── Data/ → DbContext e acesso ao banco
│ ├── Helper/ → Classes auxiliares
│ ├── Migrations/ → Migrations EF Core
│ ├── Models/ → Entidades e ViewModels
│ ├── Repository/ → Interfaces e implementações de repositórios
│ ├── Services/ → Lógica de negócio
│ ├── Validations/ → Regras de validação customizadas
│ ├── Views/ → Razor Views
│ ├── Startup.cs → Configuração da aplicação
│ └── appsettings.json → Configurações da aplicação
│
└── TdocSpider.Tests/ → Projeto de Testes Unitários com NUnit
├── Services/ → Testes da camada de serviços
├── TestHelpers/ → Mocks auxiliares (ex: FormFileMock)
└── ModelosDocumentos/ → Exemplos de documentos
```
---

## ✅ Funcionalidades

- Upload e listagem de documentos
- Validação por titulo
- Validação de arquivos pelo formato
- Armazenamento no banco de dados SQL Server
- Testes unitários com NUnit e Moq
- Interface simples e responsiva

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET Core SDK 3.1](https://dotnet.microsoft.com/download)
- SQL Server local ou Azure SQL
- Visual Studio 2019/2022 ou VS Code

### Passos

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/TdocSpider.git
cd TdocSpider
```

2. Abra o Visual Studio -> Clique em 'Tools' -> Nuget Packger Manager -> Packger Manager Console

3. Execute os seguintes comando para criar o banco e as tabelas:

```bash
dotnet ef migrations add InitialCreate --project TdocSpider --startup-project TdocSpider

dotnet ef database update --project TdocSpider --startup-project TdocSpider
```

4. ⚠️⚠️ATENÇÃO⚠️⚠️ O sistema ainda não suporta PDFs complexos como imagens escaneadas ou modelos de documento do Google

Na pasta (ModelosDocumentos) tem alguns arquivos de exemplo.



