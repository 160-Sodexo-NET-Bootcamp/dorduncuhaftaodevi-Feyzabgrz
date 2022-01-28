using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModel
{
    public class Exchange 
    {
        public long ID { get; set; }
        public string PercentName { get; set; } //Hisse senedi adı
        public string PercentCode { get; set; } //Hisse senedi kodu
        public double InstantPrice { get; set; } //anlık fiyat bilgisi
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; } //oluşturulma tarihi


    }
}
