# 📚 Biblioteca de Livros – Turma Sênior Fuzzy

Bem-vindo à **Biblioteca Digital** da nossa turma!  
Aqui você vai aprender a criar uma aplicação web completa usando **.NET**, **HTML/JS**, e **MySQL** — tudo com estilo, organização e propósito.  
Prepare-se para codar, aprender e se divertir! 😎🚀

---

## 🧠 Objetivo do Projeto

Criar uma aplicação web onde usuários possam:

- 📖 Cadastrar livros
- 👤 Gerenciar leitores
- 🔄 Registrar empréstimos e devoluções
- 🔍 Buscar informações de forma rápida e intuitiva

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia | Função |
|------------|--------|
| 🧩 ASP.NET Core | Back-end da aplicação |
| 🗃️ Entity Framework Core | ORM para manipular o banco |
| 🐬 MySQL | Banco de dados relacional |
| 🎨 HTML + CSS | Interface visual |
| ⚡ JavaScript | Interatividade no front-end |
| 🧪 Swagger | Testes de API |

---

## 🎬 Preview do Projeto

> 💡 *Quer ver como vai ficar? Aqui vai uma ideia:*

![GIF de biblioteca animada](https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExY2MzM2J1ZmxsM2hmanhtZWJ5eTAxOGkzazBvZjIzazBwa3kxMnl4MCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/1lBGUG4e7FekWly6SF/giphy.gif)

---

## 🧑‍💻 Para rodar o projeto

1. Clone o repositório  
   `git clone https://github.com/seu-usuario/projeto-biblioteca.git`

2. Configure o banco com Docker  
   `docker-compose up -d`

3. Rode o back-end no Visual Studio  
   `F5` ou `dotnet run`

4. Abra os arquivos HTML no navegador  
   `frontend/index.html`
## 🧑‍💻 Para Criar o banco de dados utilize o script
```
-- Criação do schema (banco de dados)
CREATE SCHEMA IF NOT EXISTS biblioteca;
USE biblioteca;

-- Tabela de Livros
CREATE TABLE IF NOT EXISTS Livros (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(100) NOT NULL,
    Autor VARCHAR(100),
    Genero VARCHAR(50),
    AnoPublicacao INT,
    Disponivel BOOLEAN DEFAULT TRUE
);

-- Tabela de Pessoas
CREATE TABLE IF NOT EXISTS Pessoas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Telefone VARCHAR(20)
);

-- Tabela de Empréstimos
CREATE TABLE IF NOT EXISTS Emprestimos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    LivroId INT NOT NULL,
    PessoaId INT NOT NULL,
    DataEmprestimo DATE NOT NULL,
    DataDevolucao DATE,
    FOREIGN KEY (LivroId) REFERENCES Livros(Id) ON DELETE CASCADE,
    FOREIGN KEY (PessoaId) REFERENCES Pessoas(Id) ON DELETE CASCADE
);
```
---

## 💬 Contribuição

Este projeto é feito por e para alunos da **Turma Sênior Fuzzy**.  
Sinta-se livre para sugerir melhorias, adicionar funcionalidades ou deixar tudo mais bonito! 🎨✨

---

## 🧠 Aprendizados

- Como criar APIs RESTful com .NET
- Como conectar front-end e back-end
- Como modelar um banco de dados relacional
- Como trabalhar em equipe com organização e propósito

---



## 📣 Créditos

Feito com 💙 por alunos da **Fuzzy**  
Com apoio de professores, colegas e muita cafeína ☕😉

