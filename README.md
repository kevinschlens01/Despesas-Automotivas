# Despesas Automotivas

Este é um projeto simples no padrão **MVC** desenvolvido com **C#**, utilizando o **Entity Framework** como ORM e banco de dados **SQL Server**. O sistema tem como objetivo principal **registrar e gerenciar manutenções realizadas em veículos**, permitindo o controle de quais carros passaram por quais oficinas e quais tipos de manutenção foram realizados.

## 🔧 Funcionalidades

O sistema implementa operações básicas de **CRUD (Create, Read, Update, Delete)** para as seguintes entidades:

- **Carros**
- **Oficinas**
- **Manutenções**

### Funcionalidades disponíveis:

- `GET /[entidade]` - Listar todos os registros
- `GET /[entidade]/{id}` - Obter um registro por ID
- `POST /[entidade]` - Adicionar novo registro
- `PUT /[entidade]/{id}` - Atualizar um registro existente
- `DELETE /[entidade]/{id}` - Remover um registro

## 🗃️ Modelagem de Dados

O sistema contém **3 tabelas** com relacionamento **muitos para muitos**:

- Um **carro** pode realizar várias **manutenções** em diferentes **oficinas**.
- Uma **oficina** pode realizar manutenções em vários **carros**.
- As **manutenções** estão associadas tanto a **carros** quanto a **oficinas**.

## 💻 Tecnologias Utilizadas

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [ASP.NET MVC](https://learn.microsoft.com/aspnet/mvc/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [SQL Server](https://www.microsoft.com/sql-server)

## 📁 Estrutura do Projeto

- `Controllers/` – Contém os controladores MVC responsáveis por lidar com as requisições HTTP. 
- `Infra/` – Configuração do DbContext e do acesso ao banco.
- `Interfaces` -  Define contratos (interfaces) que descrevem os métodos que as classes de repositório devem implementar. Promove a separação de responsabilidades e facilita a inversão de dependência e testes unitários. 
- `Models/` – Contém as classes de entidade do domínio.
- `Repositories` - Contém as implementações concretas das interfaces definidas em Interfaces/. São responsáveis pela comunicação com o banco de dados e execução das operações de persistência (CRUD).
- `Views/` – Contém as páginas Razor (HTML com C#).


## 📌 Objetivo do Projeto

O principal objetivo deste sistema é **registrar e consultar manutenções de veículos**, permitindo que o usuário acompanhe o histórico de serviços prestados em oficinas específicas.

## 🧪 Como executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/kevinschlens01/Despesas-Automotivas.git
