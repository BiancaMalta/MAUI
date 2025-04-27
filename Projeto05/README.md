# MauiAppMinhasCompras

![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-5C2D91?logo=.net&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?logo=sqlite&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)

Este aplicativo é uma solução de gerenciamento de compras, implementado utilizando **.NET MAUI** e **SQLite**. Ele permite adicionar, atualizar, excluir e consultar produtos de uma lista de compras, com todas as operações realizadas de forma assíncrona para melhorar a performance do aplicativo.

<details>
  <summary>Agenda 02</summary>

### Funcionalidades Implementadas

1. **Inserir Produto**
   - Método: `Insert(Produto p)`
   - Descrição: Insere um novo produto na tabela `Produto` do banco de dados.
   - Retorno: Número de registros inseridos.

2. **Atualizar Produto**
   - Método: `Update(Produto p)`
   - Descrição: Atualiza um produto existente no banco de dados, alterando os campos `Descricao`, `Quantidade` e `Preco` com base no `Id` do produto.
   - Retorno: Lista de produtos atualizados.

3. **Excluir Produto**
   - Método: `Delete(int id)`
   - Descrição: Exclui um produto com o `Id` especificado da tabela `Produto`.
   - Retorno: Número de registros excluídos.

4. **Obter Todos os Produtos**
   - Método: `GetAll()`
   - Descrição: Retorna todos os produtos armazenados na tabela `Produto`.
   - Retorno: Lista de todos os produtos.

5. **Buscar Produto**
   - Método: `Search(string q)`
   - Descrição: Realiza uma busca por produtos que contenham a string `q` na descrição.
   - Retorno: Lista de produtos encontrados.

### SQLite Database Helper

A classe `SQLiteDatabaseHelper` gerencia todas as operações de banco de dados, utilizando a biblioteca **SQLite-net-pcl**. Ela oferece métodos para inserir, atualizar, excluir, consultar e buscar produtos de forma assíncrona.

#### Atributos

- **_conn**: Instância de `SQLiteAsyncConnection` que gerencia a conexão com o banco de dados SQLite.

#### Construtor

- **SQLiteDatabaseHelper(string path)**: Inicializa a conexão com o banco de dados no caminho especificado e cria a tabela `Produto` se não existir.

</details>
<details>
  <summary>Agenda 03</summary>

### Funcionalidades Implementadas

1. **Acesso Centralizado ao Banco de Dados**
- O banco de dados agora é acessado de qualquer parte do app através de App.Db.
- O arquivo do banco (banco_sqlite_compras.db3) é armazenado no diretório local do dispositivo.

2. **Interface Aprimorada**
- A tela "Minhas Compras" (antes "ListaProduto") agora inclui botões na Toolbar:
- Somar (funcionalidade futura).
- Adicionar (leva à tela de cadastro de produtos).

3. **Cadastro de Produtos**
- A tela NovoProduto agora possui um formulário com os seguintes campos:
   - Descrição do Produto (txt_descricao).
   - Quantidade (txt_quantidade, teclado numérico).
   - Preço Unitário (txt_preco, teclado numérico).

     
- Um botão na Toolbar permite salvar o produto no banco de dados.
- Após a inserção, um alerta de sucesso é exibido.
</details>
<details>
  <summary>Agenda 04</summary>
 
Este projeto demonstra como implementar uma funcionalidade de busca dinâmica de produtos em uma interface de usuário utilizando o .NET MAUI. A busca é realizada com a ajuda do componente `SearchBar`, e os resultados são gerenciados e exibidos por meio de uma `ObservableCollection`. A integração entre essas duas ferramentas garante uma atualização automática da interface conforme o usuário digita seu termo de busca.

### Funcionalidades Implementadas

1. **Busca Dinâmica com SearchBar**: 
   - O `SearchBar` é utilizado para capturar o termo de busca inserido pelo usuário. 
   - Cada vez que o usuário digita algo, a lista de produtos é filtrada em tempo real.

2. **Filtragem de Produtos**: 
   - A lógica de busca é implementada no ViewModel, onde a lista original de produtos é comparada com o termo de busca.
   - Os produtos que correspondem ao termo de busca são selecionados e exibidos ao usuário.

3. **Atualização Automática da Interface**:
   - A lista de produtos é armazenada em uma `ObservableCollection`, que permite que a interface seja automaticamente atualizada sempre que a lista for alterada.
   - Qualquer modificação no filtro de produtos é refletida na interface imediatamente, sem necessidade de interações manuais.

4. **Interface com CollectionView**:
   - O `CollectionView` é utilizado para exibir a lista de produtos filtrados.
   - O `CollectionView` se atualiza automaticamente à medida que os dados na `ObservableCollection` mudam, garantindo uma experiência de usuário fluida e interativa.

</details>
<details>
  <summary>Agenda 05</summary>

### Funcionalidades Implementadas
1. **Tratamento de Exceções**
    - O bloco try-catch é usado para garantir que a aplicação continue funcionando em caso de erro, exibindo mensagens amigáveis ao usuário.

2. **Menu de Contexto**
    - Foi adicionado um Menu de Contexto à ListView, permitindo ações como Excluir, com a opção destacada como destrutiva.

3. **Exibição de Alertas**
    - A funcionalidade DisplayAlert exibe mensagens de confirmação ou erro, retornando um valor booleano para definir a ação do usuário.

4. **Navegação e Edição de Produtos**
    - O evento ItemSelected permite a navegação para uma tela de detalhes, e o método EditarProduto atualiza os dados no banco com a ajuda de try-catch para capturar possíveis erros.

</details>
<details>
  <summary>Agenda 06</summary>

### Funcionalidades Implementadas

1. **Campo "Categoria" adicionado**:
    - No modelo `Produto`, agora é possível definir a categoria de cada produto.
    - As telas de **novo produto** e **editar produto** foram atualizadas para incluir um campo de entrada de categoria.

  2. **Novas funcionalidades no banco de dados**:
     - `SearchByCategory(categoria)`: busca produtos filtrados pela categoria informada.
     - `GetTotalByCategory()`: retorna o total gasto por categoria em formato de dicionário.

### Arquivos modificados

- `Models/Produto.cs` → Adição do atributo `Categoria`.
- `Views/EditarProduto.xaml` → Campo de entrada para a categoria.
- `Views/EditarProduto.xaml.cs` → Atualização do salvamento para incluir a categoria.
- `Helpers/SQLiteDatabaseHelper.cs` → Novos métodos de busca e totalização por categoria.

### Impacto

Essas atualizações permitem:
- Melhor organização dos produtos por categoria.
- Relatórios financeiros básicos baseados em categorias.
- Experiência de edição e adição de produtos mais completa.

-------

