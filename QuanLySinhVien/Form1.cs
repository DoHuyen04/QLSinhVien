using QuanLySinhVien.Model;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        private DataContext db = new DataContext();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            dgvSV.DataSource = null;
            dgvSV.DataSource = db.SinhViens.ToList();
        }
        public void ResetData()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            cboLop.SelectedItem = 0;
            txtTimKiem.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(txtMaSV.Text, out ma))
            {
                MessageBox.Show("Mã sv là 1 số nguyên !");
                return;
            }
            if (db.SinhViens.Any(sv => sv.masv == ma))
            {
                MessageBox.Show("Mã sv đã tồn tại !");
                return;
            }
           

            db.SinhViens.Add(
                new SinhVien { 
                
                tensv = txtMaSV.Text,
                ngaysinh = dtpNgaySinh.Value,
                gioitinh = radNam.Checked ? "Nam" : "Nữ",
                lop = cboLop.SelectedItem.ToString()

            }
            );

            db.SaveChanges();
            LoadData();
            MessageBox.Show("Thêm thành công !");
            ResetData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(txtMaSV.Text);
            var kq = db.SinhViens.FirstOrDefault(sv => sv.masv == ma);
            if (kq != null)
            {
                kq.tensv = txtTenSV.Text;
                // kq.masv = int.Parse(txtMaSV.Text);
                kq.ngaysinh = dtpNgaySinh.Value;
                kq.gioitinh = radNam.Checked ? "Nam" : "Nữ";
                kq.lop = cboLop.SelectedItem.ToString();
            }
            db.SaveChanges();
            LoadData();
            MessageBox.Show("Sửa thành công !");
            ResetData();
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaSV.Text = dgvSV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSV.Text = dgvSV.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(dgvSV.Rows[e.RowIndex].Cells[2].Value.ToString());
                cboLop.SelectedItem = dgvSV.Rows[e.RowIndex].Cells[4].ToString();
                string gt  = dgvSV.Rows[e.RowIndex].Cells[3].ToString();
                if (gt == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(txtMaSV.Text);
            var kq = db.SinhViens.FirstOrDefault(sv => sv.masv == ma);
            if (kq != null)
            {
                db.SinhViens.Remove(kq);
                db.SaveChanges();
                LoadData();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Xử lý xóa ở đây
                }

                MessageBox.Show("Xóa thành công !");
                ResetData();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text.Trim().ToLower();
            //  var kq = db.SinhViens.Where(sv => sv.tensv.Contains(timkiem));
            var kq = db.SinhViens.Where(sv => sv.tensv== timkiem);
            if (kq != null)
            {
                dgvSV.DataSource = null;
                dgvSV.DataSource = kq.ToList();
            }
            if (kq.ToList().Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào có tên " , timkiem);
            }
        }
    }
}
