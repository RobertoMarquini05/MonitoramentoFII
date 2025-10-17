using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MonitoramentoFII.Models;

namespace MonitoramentoFII.BLL
{
    public static class FiiManager
    {
        public static async Task<FiiMetrics?> GetFiiMetrics(string ticker, string apiKey)
        {
            try
            {
                using var http = new HttpClient();
                string url = $"https://brapi.dev/api/quote/{ticker}?token={apiKey}";
                var resp = await http.GetStringAsync(url);

                if (!resp.TrimStart().StartsWith("{"))
                {
                    Console.WriteLine($"Erro: a resposta da API não é JSON para {ticker}");
                    return null;
                }

                using var doc = JsonDocument.Parse(resp);
                var result = doc.RootElement.GetProperty("results")[0];

                decimal price = result.GetProperty("regularMarketPrice").GetDecimal();
                decimal prevClose = result.GetProperty("regularMarketPreviousClose").GetDecimal();
                decimal change = result.GetProperty("regularMarketChangePercent").GetDecimal();

                return new FiiMetrics
                {
                    Ticker = ticker,
                    CurrentPrice = price,
                    PrevClose = prevClose,
                    ChangePercent = change
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao coletar {ticker}: {ex.Message}");
                return null;
            }
        }
    }
}
