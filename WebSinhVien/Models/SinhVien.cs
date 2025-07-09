using System.ComponentModel.DataAnnotations;

namespace WebSinhVien.Models
{
    public class SinhVien
    {

        [Key]
        public int masv { get; set; }
        public string tensv { get; set; } = string.Empty;
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; } = string.Empty;
        public string lop { get; set; } = string.Empty;
        public ICollection<KetQua>? KetQuas { get; set; }
    }
}
