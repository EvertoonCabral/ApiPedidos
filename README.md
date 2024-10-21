# API de Gerenciamento de Pedidos

Este projeto é uma WebAPI desenvolvida em ASP.NET para o gerenciamento de pedidos de uma loja, como parte de um teste para vaga de desenvolvedor backend.

## Objetivo

Criar uma WebAPI que permita realizar o controle de pedidos e produtos, aplicando boas práticas de desenvolvimento, princípios de **Domain-Driven Design (DDD)** e seguindo os requisitos descritos no teste.

## Funcionalidades

A API permite:

- **Iniciar um novo pedido**: Cria um pedido com status de aberto.
- **Adicionar produtos ao pedido**: Adiciona produtos a um pedido específico.
- **Remover produtos do pedido**: Remove produtos de um pedido aberto.
- **Fechar um pedido**: Muda o status do pedido para fechado, impedindo novas alterações.
- **Cancelar um pedido**: Cancela um pedido, sem excluir seu histórico.
- **Listar pedidos**: Lista todos os pedidos, com suporte à paginação.
- **Filtrar pedidos por status**: Filtra pedidos pelo status (aberto, fechado ou cancelado).
- **Obter detalhes de um pedido**: Retorna os detalhes de um pedido e seus produtos associados.
- **Criar um novo produto**: Permite cadastrar um produto no sistema.
- **Listar produtos**: Lista os produtos cadastrados, com suporte à paginação.

## Regras de Negócio

- Produtos não podem ser adicionados ou removidos de pedidos com status **fechado** ou **cancelado**.
- Um pedido só pode ser **fechado** se tiver ao menos um produto.
- O status de um pedido pode ser alterado para **cancelado**, mas o cancelamento não remove os produtos associados.

## Estrutura do Projeto

A API foi construída seguindo o conceito de **DDD**. Abaixo está um resumo das camadas:

- **Domain**: Contém as entidades do sistema (`Pedido`, `Produto`), bem como as regras de negócio.
- **Application**: Camada de serviços que encapsula as regras de negócio e faz a mediação entre a camada de dados e os controladores.
- **Infrastructure**: Implementação dos repositórios que acessam o banco de dados.
- **API**: Controladores que expõem as rotas HTTP para interagir com o sistema.

## Rotas da API

### Pedido

- **POST** `/api/Pedido/AbrirPedido`  
  Inicia um novo pedido.

- **POST** `/api/Pedido/{pedidoId}/produtos/{produtoId}/AdicionarProduto`  
  Adiciona um produto a um pedido existente.

- **DELETE** `/api/Pedido/{pedidoId}/produtos/{produtoId}/RemoverProduto`  
  Remove um produto de um pedido.

- **PUT** `/api/Pedido/{pedidoId}/FecharPedido`  
  Fecha um pedido, bloqueando novas modificações.

- **PUT** `/api/Pedido/{pedidoId}/CancelarPedido`  
  Cancela um pedido.

- **GET** `/api/Pedido/ListarPedidos?numeroPagina={numero}&tamanhoPagina={tamanho}`  
  Lista os pedidos com suporte à paginação.

- **GET** `/api/Pedido/ListarPedidosPorStatus?status={status}`  
  Filtra os pedidos de acordo com o status (Aberto, Fechado, Cancelado).

- **GET** `/api/Pedido/{id}`  
  Obtém os detalhes de um pedido específico.

### Produto

- **POST** `/api/Produto/CriarProduto`  
  Cria um novo produto.

- **GET** `/api/Produto/ListarProdutos?numeroPagina={numero}&tamanhoPagina={tamanho}`  
  Lista todos os produtos com paginação.

### Iniciar um novo pedido

![Iniciar Pedido](![Anexo01](https://github.com/user-attachments/assets/e50a5872-c6c9-4f9a-97e2-b95aba79e133))

### Adicionar produtos ao pedido

![Adicionar Produto](![Anexo03](https://github.com/user-attachments/assets/f3219295-7094-47ae-81af-4222d2afffcf))

### Remover produtos do pedido

![Remover Produto](![Anexo08](https://github.com/user-attachments/assets/7ba9114e-a855-43c6-af07-bb68492cafc4))

### Fechar o pedido

![Fechar Pedido](![Anexo04](https://github.com/user-attachments/assets/c16238b8-780b-4483-9e67-899edd7dfaa0))

### Listar os pedidos

![Listar Pedidos](![Anexo07](https://github.com/user-attachments/assets/026aae65-44ae-4c6c-8218-615fcfc811c5))

### Obter pedido por ID

![Obter Pedido](![Anexo05](https://github.com/user-attachments/assets/24b38a5e-81a6-46f2-bd2e-331fc9b9bb35))



## Tecnologias Utilizadas

- **ASP.NET Core**
- **Entity Framework Core**
- **Injeção de Dependência**
- **DDD (Domain-Driven Design)**
- **Swagger para documentação**
- **xUnit** para testes unitários

## Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/EvertoonCabral/ApiPedidos.git
