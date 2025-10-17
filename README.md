# MonitoramentoFII

Este projeto foi criado em **C#** para monitorar **Fundos Imobiliários (FIIs)** e coletar dados de mercado diretamente da API da [Brapi.dev](https://brapi.dev).  
O objetivo é acompanhar a evolução dos FIIs antes de investir, salvar os dados em **JSON** e posteriormente criar dashboards no **Power BI** para análise visual.

---

## Funcionalidades

- Coleta dados de FIIs categorizados por tipo (Lajes, Shoppings, Logística, CRI, Fundos de Fundos).  
- Armazena os dados em arquivos **JSON** estruturados por categoria.  
- Inclui métricas de preço atual, fechamento anterior, variação diária e tendência.  
- Preparado para integração futura com **VenomBot** para envio via WhatsApp.  

---

## Tecnologias

- **C# / .NET 8**
- **Brapi.dev API** para dados de mercado
- **System.Text.Json** para manipulação de JSON
- **Power BI** (para visualização dos dados)  

---

## Como usar

1. Clone este repositório:

```bash
git clone https://github.com/RobertoMarquini05/MonitoramentoFII.git
cd MonitoramentoFII
```

2. Configure sua **API Key** da Brapi.dev:  

- **Opcional:** criar variável de ambiente `BRAPI_TOKEN`  
- Ou configurar `appsettings.json` (não deve ser enviado para o GitHub)  

```json
{
  "BRAPI": {
    "Token": "SUA_CHAVE_AQUI"
  }
}
```

3. Rode o projeto:

```bash
dotnet run
```

4. Os arquivos **JSON** serão salvos na raiz do projeto com timestamp, prontos para análise no Power BI.

---

## Próximos passos

- Integrar com **VenomBot** para enviar notificações via WhatsApp.  
- Criar **dashboard no Power BI** para monitorar tendências e evolução dos FIIs.  
- Expandir para mais fundos imobiliários e métricas de desempenho.  

---

## Estrutura do JSON gerado

```json
{
  "CRI": [
    {
      "FII": "MXRF11",
      "PrecoAtual": 10.04,
      "FechamentoAnterior": 9.99,
      "VariacaoDiaria": 0.50,
      "Tendencia": "Alta"
    }
  ],
  "Lajes": [ ... ],
  "Shoppings": [ ... ],
  "Logistica": [ ... ],
  "FundosDeFundos": [ ... ]
}
```

---

📂 Repositório no GitHub: [MonitoramentoFII](https://github.com/RobertoMarquini05/MonitoramentoFII)  

---

Este projeto é meu **jeito de praticar programação, análise de dados e estudo do mercado financeiro** ao mesmo tempo. 🚀
