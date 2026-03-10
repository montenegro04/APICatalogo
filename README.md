# 📦 API Catálogo - Projeto de Estudo

> Uma Web API desenvolvida em ASP.NET Core com o objetivo de explorar, testar e consolidar diferentes abordagens e ferramentas no ecossistema .NET.

## 🎯 Sobre o Projeto
Este projeto foi construído do zero como um laboratório prático de estudos. A ideia principal não foi apenas fazer um CRUD funcional, mas sim testar diversas opções de configuração, arquitetura, otimização de consultas e resolução de problemas comuns no desenvolvimento de APIs modernas.

O domínio simula um catálogo simples com uma relação de 1:N entre **Categorias** e **Produtos**.

## 🛠️ Tecnologias e Ferramentas Utilizadas
* **C# & ASP.NET Core:** Base do projeto e roteamento de endpoints.
* **Entity Framework Core:** Mapeamento Objeto-Relacional (ORM) para comunicação com o banco de dados.
* **MySQL:** Banco de dados relacional escolhido para persistência (integrado via provedor do EF Core).
* **Swagger (Swashbuckle) & Scalar:** Exploração de interfaces para documentação e teste interativo da API no navegador.
* **Postman:** Ferramenta externa utilizada para simular requisições HTTP, testar diferentes cenários e analisar respostas e *status codes*.

## 🚀 Principais Aprendizados e Desafios Superados
Durante o desenvolvimento, implementei e resolvi diversas situações do mundo real, aprofundando o conhecimento em:

* **Manipulação de Dados:** Entendimento aprofundado sobre **serialização e desserialização de JSON**, ajustando o comportamento do serializador nativo para comunicação entre cliente e servidor.
* **Otimização de Consultas (Performance):** Aplicação do método `.AsNoTracking()` no Entity Framework para *endpoints* de leitura (GET), melhorando a performance e economizando memória ao evitar o rastreamento desnecessário de estado das entidades.
* **Filtros e Limitação de Dados:** Uso do método `.Take()` em consultas LINQ para restringir a quantidade de registros retornados, preparando o terreno para paginação de dados.
* **Resiliência e Segurança:** Implementação de tratamento de erros com blocos `try-catch`, garantindo que exceções sejam capturadas de forma elegante e retornem respostas HTTP consistentes (como Status 500) sem derrubar a aplicação.
* **Tratamento de Referências Circulares:** Resolução de *loops* infinitos (*Object Cycles*) na leitura de dados relacionados (Categoria <-> Produto) utilizando `ReferenceHandler.IgnoreCycles`.
* **Configuração de Documentação e Rotas:** Alternância entre Swagger e Scalar, resolução de conflitos em atributos de rota (como espaços indevidos em `[HttpPut("{id:int}")]`) e interpretação de erros de validação (Status 400).

## ⚙️ Como executar o projeto localmente

1. Clone este repositório:
   ```bash
   git clone [https://github.com/montenegro04/APICatalogo.git](https://github.com/montenegro04/APICatalogo.git)