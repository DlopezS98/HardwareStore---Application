using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStore.Core.DTOs
{
    public class Response
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
