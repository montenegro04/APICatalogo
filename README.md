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
* **CORS & Rate Limiting:** Implementação de políticas de segurança para controle de acessos e tráfego.
* **Swagger (Swashbuckle) & Scalar:** Exploração de interfaces para documentação e teste interativo da API no navegador.
* **Postman:** Ferramenta externa utilizada para simular requisições HTTP e analisar respostas.

## 🚀 Principais Aprendizados e Desafios Superados
Durante o desenvolvimento, implementei e resolvi diversas situações do mundo real, aprofundando o conhecimento em:

* **Segurança e Controle de Acessos (CORS):** Configuração de políticas de *Cross-Origin Resource Sharing* para permitir o consumo seguro da API por diferentes front-ends. Para validar a usabilidade, desenvolvi um **cliente experimental em HTML/JavaScript** que realiza chamadas via `fetch`, garantindo que os cabeçalhos de segurança estejam configurados corretamente.
* **Proteção contra Abusos (Rate Limiting):** Implementação de limites de requisições por janela de tempo (ex: 10 requisições por minuto) para proteger a API contra sobrecarga, ataques de força bruta e garantir a disponibilidade do serviço para todos os usuários.
* **Paginação de Dados e Filtros:** Implementação de paginação nos *endpoints* de listagem (utilizando `Skip` e `Take`) para otimizar o consumo de memória e rede.
* **Transferência de Dados (DTOs) e AutoMapper:** Separação dos modelos de domínio dos contratos da API usando o padrão DTO, automatizado pelo AutoMapper.
* **Atualizações Parciais (HTTP PATCH):** Uso do padrão JSON Patch para atualizar campos específicos de um registro de forma eficiente.
* **Arquitetura de Dados (Repository & Unit of Work):** * Implementação do **Padrão Repository** (Genérico e Específico) para desacoplar os controllers do banco de dados.
    * Uso do **Unit of Work** para centralizar a persistência de dados em transações atômicas.
* **Tratamento Global de Exceções e Logging:** Abordagem centralizada para falhas usando filtros de exceção e a interface `IExceptionHandler`, garantindo respostas padronizadas e registros de log.
* **Otimização de Consultas:** Aplicação de `.AsNoTracking()` em consultas de leitura para ganho de performance.

## 🧪 Testando a Usabilidade do CORS

Para validar a configuração de segurança **CORS**, o projeto conta com um pequeno utilitário de teste:

1. **Cliente de Teste:** Localizado no projeto MVC/Web, o arquivo `Index.cshtml` contém um script JavaScript para interagir com a API.
2. **Execução:** Ao rodar o projeto Web, é possível disparar requisições reais para a API e acompanhar o resultado através do **Console do Navegador (F12)**. 
3. **Validação:** Isso comprova que a API está aceitando requisições de origens específicas e bloqueando acessos não autorizados.

## ⚙️ Como executar o projeto localmente

1. **Clone este repositório:**
   ```bash
   git clone [https://github.com/montenegro04/APICatalogo.git](https://github.com/montenegro04/APICatalogo.git)