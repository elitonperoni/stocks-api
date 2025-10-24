# Stock API

Stock API é uma aplicação .NET 8 desenvolvida para fornecer dados e notícias relacionadas a ações, utilizando APIs externas para informações completas. O projeto é escrito em C# 12 e segue padrões modernos de arquitetura para escalabilidade e manutenção.

## Funcionalidades

- **Consulta de Notícias de Ações:**  
  Busca as últimas notícias de uma ação específica usando o mecanismo Google News da SerpApi.  
  Os resultados são processados, ordenados por data e limitados aos seis artigos mais recentes.

- **Detalhes das Ações:**  
  Fornece informações detalhadas sobre ações, incluindo eventos e metadados.

- **Gerenciamento de Chaves de API:**  
  Gerencia de forma segura as chaves de API para serviços externos (SerpApi, Brapi) via configuração.

## Tecnologias

- **.NET 8** — Plataforma robusta e moderna para aplicações web.
- **C# 12** — Linguagem de programação de última geração, com recursos avançados.
- **Minimal API** — Estrutura enxuta e eficiente, ideal para microserviços e APIs rápidas.
- **Clean Architecture** — Organização do código orientada a boas práticas, facilitando manutenção e escalabilidade.
- **AWS Lambda** — Deploy em ambiente serverless, garantindo alta disponibilidade e baixo custo operacional.
- **Brapi Api** — Consulta de informações atualizadas sobre ações listadas na B3 ([link](https://brapi.dev/)).
- **Serp Api** — Integração com Google News para obter as últimas notícias de cada ação. ([link](https://serpapi.com/)).

## Uso

1. **Configuração:**  
   Defina suas chaves de API no arquivo de configuração (exemplo: `appsettings.json`):

2. **Consulta de Notícias:**  
   Utilize os métodos de consulta para buscar cotações e notícias de ações específicas aplicando diversos filtros.

3. **Tratamento de Erros:**  
   Todas as operações retornam um objeto `Result<T>`, indicando sucesso ou falha com informações detalhadas do erro.

## Contribuição

Contribuições são bem-vindas! Faça um fork do repositório e envie um pull request.


