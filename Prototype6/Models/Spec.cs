using System.ComponentModel.DataAnnotations;

namespace Prototype6.Models
{
    public class Spec
    {
        [Key]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Spesies { get; set; }
        public int Klasifikasi { get; set; }
    }
}
