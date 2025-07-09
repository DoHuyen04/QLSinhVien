using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Model
{
    public class SinhVien
    {
        [Key]
        public int masv {  get; set; }
        public string tensv { get; set; } = string.Empty;
        public DateTime ngaysinh    { get; set; }
        public string gioitinh { get; set; }=string.Empty;
        public string lop  { get; set; }=  string.Empty;
    }
}
