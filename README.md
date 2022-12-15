## Trytter
Projeto final Aceleração em C#

Projeto desenvolvido no final da Aceleração em C# da Trybe.

## Rodar Localmente

Para rodar o projeto localmente, entre na raiz do projeto e rode ```docker-compose up```

Posteriormente, entre na pasta src e rode dotnet ef database update -s WebApi

Dessa forma, estará disponível uma instância do MSSQL Server para rodar o projeto, com o banco de dados estabelecido.

Rode a aplicação, criando usuários por meio da rota de "Post /user", e efetuando login posteriormente para obter o token, por meio da rota "Post /user/login".

Depois de obtido o token, será possível criar posts, editar, deletar, listar posts pelo ID do usuário, bem como listar posts pelo username de outros usuários.
