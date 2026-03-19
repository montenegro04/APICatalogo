# 📦 API Catálogo - Projeto de Estudo

> Uma Web API desenvolvida em ASP.NET Core com o objetivo de explorar, testar e consolidar diferentes abordagens e ferramentas no ecossistema .NET.

## 🎯 Sobre o Projeto
Este projeto foi construído do zero como um laboratório prático de estudos. A ideia principal não foi apenas fazer um CRUD funcional, mas sim testar diversas opções de configuração, arquitetura limpa, segurança, otimização de consultas e resolução de problemas comuns no desenvolvimento de APIs modernas.

O domínio simula um catálogo simples com uma relação de 1:N entre **Categorias** e **Produtos**.

## 🛠️ Tecnologias e Ferramentas Utilizadas
* **C# & ASP.NET Core:** Base do projeto e roteamento de endpoints.
* **Entity Framework Core:** Mapeamento Objeto-Relacional (ORM) para comunicação com o banco de dados.
* **MySQL:** Banco de dados relacional escolhido para persistência.
* **AutoMapper:** Biblioteca para mapeamento automático de objetos (Entidades <-> DTOs).
* **Swagger (Swashbuckle) & Scalar:** Exploração de interfaces para documentação e teste interativo da API no navegador.
* **Postman:** Ferramenta externa utilizada para simular requisições HTTP, testar diferentes cenários e analisar respostas e *status codes*.

## 🚀 Principais Aprendizados e Desafios Superados
Durante o desenvolvimento, implementei e resolvi diversas situações do mundo real, aprofundando o conhecimento em:

* **Transferência de Dados (DTOs) e AutoMapper:** Implementação do padrão **DTO (Data Transfer Object)** para separar os modelos de domínio dos contratos da API, garantindo controle preciso sobre o formato dos dados de entrada e saída. Uso do **AutoMapper** para automatizar e simplificar a conversão entre as entidades do banco e os DTOs.
* **Atualizações Parciais (HTTP PATCH):** Implementação do verbo `PATCH` no *controller* de Produtos, utilizando o padrão **JSON Patch** (com suporte do `Newtonsoft.Json`) para atualizar campos específicos de um registro de forma eficiente, sem a necessidade de enviar o objeto inteiro na requisição.
* **Arquitetura de Dados (Repository & Unit of Work):** * Implementação do **Padrão Repository**, criando um **Repositório Genérico** para abstrair operações comuns de CRUD e **Repositórios Específicos** (Categorias e Produtos) para consultas especializadas, desacoplando os *controllers* do banco de dados.
  * Uso do **Unit of Work (Unidade de Trabalho)** para centralizar a persistência de dados, garantindo que múltiplas operações compartilhem o mesmo contexto do EF Core como uma transação atômica.
* **Programação Assíncrona (`async/await`):** Transição para métodos assíncronos no acesso a dados, liberando *threads* durante operações de I/O para melhorar a escalabilidade da API.
* **Arquitetura e Pipeline HTTP:** Entendimento profundo do fluxo de requisições através da configuração e uso de **Middlewares** para interceptar, processar ou barrar chamadas.
* **Tratamento Global de Exceções e Logging:** Evolução na resiliência da aplicação substituindo blocos `try-catch` repetitivos por uma abordagem centralizada usando **Filtros de Exceção** e a interface **`IExceptionHandler`** global, integrados com **Logging** para registrar falhas silenciosamente.
* **Validação de Dados e Segurança:** Uso de **Data Annotations** para garantir a integridade das informações, gerando respostas 400 (Bad Request) automáticas. Configuração do **User Secrets** para proteger *connection strings* durante o desenvolvimento, evitando o vazamento de credenciais no repositório.
* **Manipulação de Dados e JSON:** Resolução de *loops* infinitos (*Object Cycles*) na leitura de dados relacionados utilizando `ReferenceHandler.IgnoreCycles`.
* **Otimização de Consultas:** Aplicação do `.AsNoTracking()` no EF Core para *endpoints* de leitura (GET), economizando memória, e uso do `.Take()` para restringir a quantidade de registros retornados.

## ⚙️ Como executar o projeto localmente

1. Clone este repositório:
   ```bash
   git clone [https://github.com/montenegro04/APICatalogo.git](https://github.com/montenegro04/APICatalogo.git)