using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public  class ExchangeDto
    {
        public long ID { get; set; }
        public string PercentName { get; set; } //Hisse senedi adı
        public string PercentCode { get; set; } //Hisse senedi kodu
        public double InstantPrice { get; set; } //anlık fiyat bilgisi
        public byte Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
