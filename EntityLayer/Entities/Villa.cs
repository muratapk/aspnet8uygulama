using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name="Villa Adı")]
        public string? Name { get; set; }

        [Display(Name = "Villa Açıklaması")]
        public string? Description { get; set; }
        [Display(Name = "Villa Fiyatı")]
        [Range(10000,1000000)]
        public double Price { get; set; }
        [Display(Name = "Villa Kat Sayısı")]
        [Range(1,5)]
        public int Sqft { get; set; }
        [Display(Name = "Villa Doluluk Durumu")]
        public int Occupancy { get; set; }
        [Display(Name = "Villa Resimin Yolu")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }  
        public DateTime? UpdatedDate { get;set; }
    }
}
