using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoramentoFII.Models
{
    public class FiiMetrics
    {
        public string Ticker { get; set; } = "";
        public decimal CurrentPrice { get; set; }
        public decimal PrevClose { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal Avg5Days { get; set; }
        public decimal TrendPercent { get; set; }
        public int UpDays { get; set; }
        public int DownDays { get; set; }
        public string TrendSignal => TrendPercent > 0 ? "Alta" : "Baixa";
    }
}
