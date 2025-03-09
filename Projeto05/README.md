# MauiAppMinhasCompras

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-5C2D91?logo=.net&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?logo=sqlite&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)

Este aplicativo é uma solução de gerenciamento de compras, implementado utilizando **.NET MAUI** e **SQLite**. Ele permite adicionar, atualizar, excluir e consultar produtos de uma lista de compras, com todas as operações realizadas de forma assíncrona para melhorar a performance do aplicativo.

## Funcionalidades

### 1. **Inserir Produto**
   - Método: `Insert(Produto p)`
   - Descrição: Insere um novo produto na tabela `Produto` do banco de dados.
   - Retorno: Número de registros inseridos.

### 2. **Atualizar Produto**
   - Método: `Update(Produto p)`
   - Descrição: Atualiza um produto existente no banco de dados, alterando os campos `Descricao`, `Quantidade` e `Preco` com base no `Id` do produto.
   - Retorno: Lista de produtos atualizados.

### 3. **Excluir Produto**
   - Método: `Delete(int id)`
   - Descrição: Exclui um produto com o `Id` especificado da tabela `Produto`.
   - Retorno: Número de registros excluídos.

### 4. **Obter Todos os Produtos**
   - Método: `GetAll()`
   - Descrição: Retorna todos os produtos armazenados na tabela `Produto`.
   - Retorno: Lista de todos os produtos.

### 5. **Buscar Produto**
   - Método: `Search(string q)`
   - Descrição: Realiza uma busca por produtos que contenham a string `q` na descrição.
   - Retorno: Lista de produtos encontrados.

## SQLite Database Helper

A classe `SQLiteDatabaseHelper` gerencia todas as operações de banco de dados, utilizando a biblioteca **SQLite-net-pcl**. Ela oferece métodos para inserir, atualizar, excluir, consultar e buscar produtos de forma assíncrona.

### Atributos

- **_conn**: Instância de `SQLiteAsyncConnection` que gerencia a conexão com o banco de dados SQLite.

### Construtor

- **SQLiteDatabaseHelper(string path)**: Inicializa a conexão com o banco de dados no caminho especificado e cria a tabela `Produto` se não existir.

## Novas Funcionalidades - Agenda 03

### Acesso Centralizado ao Banco de Dados
- O banco de dados agora é acessado de qualquer parte do app através de App.Db.
- O arquivo do banco (banco_sqlite_compras.db3) é armazenado no diretório local do dispositivo.

### Interface Aprimorada
- A tela "Minhas Compras" (antes "ListaProduto") agora inclui botões na Toolbar:
- Somar (funcionalidade futura).
- Adicionar (leva à tela de cadastro de produtos).

### Cadastro de Produtos
- A tela NovoProduto agora possui um formulário com os seguintes campos:
   - Descrição do Produto (txt_descricao).
   - Quantidade (txt_quantidade, teclado numérico).
   - Preço Unitário (txt_preco, teclado numérico).

     
- Um botão na Toolbar permite salvar o produto no banco de dados.
- Após a inserção, um alerta de sucesso é exibido.

-------

