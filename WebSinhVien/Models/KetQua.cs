
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSinhVien.Models
{
    public class KetQua
    {
        [Key]
        public int makq  { get; set; }
        [ForeignKey("masv")]
        public int masv { get; set; }
        public SinhVien? SinhVien { get; set; }
        public string monhoc { get; set; } = string.Empty;
        public float diem { get; set; }
    }
}
