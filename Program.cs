using System.Text.Json;
using MonitoramentoFII.BLL;
class Config
{
    public BrApiConfig BRAPI { get; set; } = new BrApiConfig();
}

class BrApiConfig
{
    public string Token { get; set; } = "";
}

class Program
{
    static async Task Main()
    {
        var json = await File.ReadAllTextAsync("appsettings.json");
        var config = JsonSerializer.Deserialize<Config>(json);
        string apiKey = config?.BRAPI?.Token ?? "";

        // Categorias e tickers
        var fiiCategories = new Dictionary<string, List<string>>()
        {
            ["Lajes"] = new List<string> { "HGRU11", "PVBI11" },
            ["Shoppings"] = new List<string> { "XPML11", "HSML11" },
            ["Logistica"] = new List<string> { "HGLG11", "VILG11" },
            ["CRI"] = new List<string> { "MXRF11", "KNCR11" },
            ["FundosDeFundos"] = new List<string> { "BCFF11", "RBRF11" }
        };

        var finalResult = new Dictionary<string, List<object>>();

        foreach (var category in fiiCategories)
        {
            var formattedList = new List<object>();
            foreach (var ticker in category.Value)
            {
                var metrics = await FiiManager.GetFiiMetrics(ticker, apiKey);
                if (metrics != null)
                {
                    var formatted = new
                    {
                        FII = metrics.Ticker,
                        PrecoAtual = metrics.CurrentPrice,
                        FechamentoAnterior = metrics.PrevClose,
                        VariacaoDiaria = metrics.ChangePercent,
                        Tendencia = metrics.TrendSignal
                    };
                    formattedList.Add(formatted);
                }
            }
            finalResult[category.Key] = formattedList;
        }

        // Caminho da raiz do projeto
        string projectRoot = AppContext.BaseDirectory;
        projectRoot = Path.Combine(projectRoot, "..", "..", ".."); // sobe 3 níveis até a raiz
        projectRoot = Path.GetFullPath(projectRoot);

        // Nome do arquivo
        var now = DateTime.Now;
        string path = Path.Combine(projectRoot, $"FiiMetrics_{now:yyyy-MM-dd_HH-mm-ss}.json");

        // Salva
        var options = new JsonSerializerOptions { WriteIndented = true };
        await File.WriteAllTextAsync(path, JsonSerializer.Serialize(finalResult, options));

        Console.WriteLine($"✅ Dados salvos em {path}");
    }
}
