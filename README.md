# API Reprograma

> `Gabriela Souza Santos`
> `E-mail: "gaaabriela@hotmail.com`
> `Trilha: BackEnd`

API desenvolvida para cadastro de usuárias interessadas em receber informações acerca do processo seletivo denominado "Reprograma". 

## _Funções da API_
- Consultar todas as interessadas cadastradas: 
 [GET] /api/Usuario

- Consultar interessadas utilizando nome e email:
[GET] /api/Usuario/consultar/{nome}/{email}
- Criação de usuária:
[POST] /api/Usuario/incluir
- Atualização das informações no cadastro das interessadas:
[PUT] /api/Usuario/atualizar
- Deletar usuária interessada cadastrada:
[DELETE] /api/Usuario/excluir/{email}

## _Tecnologias utilizadas_

- .NET 6
- Entity Framework Core 
- Migrations 
- Microsoft SQL Server 
- Swagger 

## _Instalações_

- GIT Bash
- Microsoft Visual Studio 2022
- Postman
- Microsoft SQL Server Express 
- Migrations: 

## _Desenvolvimento_

Instalar pacotes: 
- Microsoft.EntityFrameworkCore.SqlServer (para utilizar SQL Server)
- Microsoft.EntityFrameworkCore.Design (para migrations)

Criar pasta "Models" -> Armazenar entidades 
`Na entidade informe todos os atributos necessários para representar a interessada como nome e e-mail`

Criar pasta "Data" -> Armazenar entidade de contexto de banco de dados
`A entidade acima representa o banco de dados, assim foi necessário a criação da classe "AppDbContext" herdando de "DbContext"`

Posteriormente será necessário criar a entidade no banco de dados utilizando o Migrations com os seguintes comandos:
```sh
dotnet tool install --global dotnet-efMicrosoft.EntityFrameworkCore.SqlServer
dotnet ef migrations add NOME_DA_MIGRACAO
dotnet ef database update
```
Após será necessário realizar a injeção de dependência da classe AppDbContext no controller

Por fim, implementar a lógica necessária para cada uma das actions criadas. 


