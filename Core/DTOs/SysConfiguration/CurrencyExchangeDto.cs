using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs.SysConfiguration
{
    public class CurrencyExchangeDto
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int ForeignId { get; set; }
        public double Sale { get; set; }
        public double Purchase { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
