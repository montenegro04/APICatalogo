# 📦 API Catálogo - Projeto de Estudo

> Uma Web API desenvolvida em ASP.NET Core com o objetivo de explorar, testar e consolidar diferentes abordagens e ferramentas no ecossistema .NET.

## 🎯 Sobre o Projeto
Este projeto foi construído do zero como um laboratório prático de estudos. A ideia principal não foi apenas fazer um CRUD funcional, mas sim testar diversas opções de configuração, arquitetura limpa, otimização de consultas e resolução de problemas comuns no desenvolvimento de APIs modernas.

O domínio simula um catálogo simples com uma relação de 1:N entre **Categorias** e **Produtos**.

## 🛠️ Tecnologias e Ferramentas Utilizadas
* **C# & ASP.NET Core:** Base do projeto e roteamento de endpoints.
* **Entity Framework Core:** Mapeamento Objeto-Relacional (ORM) para comunicação com o banco de dados.
* **MySQL:** Banco de dados relacional escolhido para persistência (integrado via provedor do EF Core).
* **Swagger (Swashbuckle) & Scalar:** Exploração de interfaces para documentação e teste interativo da API no navegador.
* **Postman:** Ferramenta externa utilizada para simular requisições HTTP, testar diferentes cenários e analisar respostas e *status codes*.

## 🚀 Principais Aprendizados e Desafios Superados
Durante o desenvolvimento, implementei e resolvi diversas situações do mundo real, aprofundando o conhecimento em:

* **Arquitetura de Dados (Repository & Unit of Work):** * Implementação do **Padrão Repository**, criando um **Repositório Genérico** para abstrair as operações comuns de CRUD e **Repositórios Específicos** (Categorias e Produtos) para consultas especializadas, desacoplando os *controllers* do acesso direto ao banco.
  * Uso do padrão **Unit of Work (Unidade de Trabalho)** para centralizar e coordenar a persistência de dados, garantindo que múltiplas operações compartilhem a mesma instância de contexto do EF Core e sejam tratadas como uma transação atômica.
* **Programação Assíncrona (`async/await`):** Transição para métodos assíncronos no acesso a dados, liberando *threads* durante operações de I/O para melhorar a escalabilidade e o tempo de resposta da API.
* **Arquitetura e Pipeline HTTP:** Entendimento profundo do fluxo de requisições no ASP.NET Core através da configuração e uso de **Middlewares** para interceptar, processar ou barrar chamadas antes que cheguem aos *controllers*.
* **Tratamento Global de Exceções e Logging:** Evolução na resiliência da aplicação. Substituição de blocos `try-catch` repetitivos por uma abordagem centralizada e elegante usando **Filtros de Exceção (Exception Filters)** e a interface **`IExceptionHandler`** global, integrados com **Logging** para registrar falhas silenciosamente e retornar respostas HTTP seguras e padronizadas ao cliente.
* **Validação de Dados:** Uso de **Data Annotations** diretamente nas entidades para garantir a integridade das informações (como campos obrigatórios e tamanhos máximos) antes de chegarem ao banco, gerando respostas 400 (Bad Request) automáticas.
* **Manipulação de Dados e JSON:** Entendimento sobre **serialização e desserialização**, além da resolução de *loops* infinitos (*Object Cycles*) na leitura de dados relacionados utilizando `ReferenceHandler.IgnoreCycles`.
* **Otimização de Consultas (Performance):** Aplicação do método `.AsNoTracking()` no Entity Framework para *endpoints* de leitura (GET), economizando memória ao evitar o rastreamento de estado, e uso do `.Take()` para restringir a quantidade de registros retornados.
* **Configuração de Documentação e Rotas:** Alternância entre Swagger e Scalar, resolução de conflitos em atributos de rota e restrições (como `[HttpPut("{id:int}")]`).

## ⚙️ Como executar o projeto localmente

1. Clone este repositório:
   ```bash
   git clone [https://github.com/montenegro04/APICatalogo.git](https://github.com/montenegro04/APICatalogo.git)