namespace Cau3LTTQ
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaPhong = new Label();
            lblSoPhong = new Label();
            lblTangSo = new Label();
            lblLoaiPhong = new Label();
            lblTinhTrang = new Label();

            txtMaPhong = new TextBox();
            txtSoPhong = new TextBox();

            numTangSo = new NumericUpDown();

            cboLoaiPhong = new ComboBox();
            cboTinhTrang = new ComboBox();

            picPhong = new PictureBox();

            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnQuanLyLoaiPhong = new Button();

            lblLocLoai = new Label();
            lblLocTinhTrang = new Label();

            cboTimLoaiPhong = new ComboBox();
            cboTimTinhTrang = new ComboBox();

            btnTimKiem = new Button();

            dgvPhong = new DataGridView();

            colMaPhong = new DataGridViewTextBoxColumn();
            colAnh = new DataGridViewImageColumn();
            colSoPhong = new DataGridViewTextBoxColumn();
            colTangSo = new DataGridViewTextBoxColumn();
            colTenLoai = new DataGridViewTextBoxColumn();
            colGiaMoiDem = new DataGridViewTextBoxColumn();
            colTinhTrang = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)numTangSo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPhong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();

            SuspendLayout();

            // lblMaPhong
            lblMaPhong.AutoSize = true;
            lblMaPhong.Location = new Point(25, 28);
            lblMaPhong.Text = "Mã phòng";

            // txtMaPhong
            txtMaPhong.Enabled = false;
            txtMaPhong.Location = new Point(120, 25);
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Size = new Size(190, 27);
            txtMaPhong.TabStop = false;

            // lblSoPhong
            lblSoPhong.AutoSize = true;
            lblSoPhong.Location = new Point(25, 73);
            lblSoPhong.Text = "Số phòng";

            // txtSoPhong
            txtSoPhong.Location = new Point(120, 70);
            txtSoPhong.Size = new Size(190, 27);

            // lblTangSo
            lblTangSo.AutoSize = true;
            lblTangSo.Location = new Point(25, 118);
            lblTangSo.Text = "Tầng số";

            // numTangSo
            numTangSo.Location = new Point(120, 115);
            numTangSo.Minimum = 0;
            numTangSo.Maximum = 100;
            numTangSo.Size = new Size(190, 27);

            // lblLoaiPhong
            lblLoaiPhong.AutoSize = true;
            lblLoaiPhong.Location = new Point(350, 28);
            lblLoaiPhong.Text = "Loại phòng";

            // cboLoaiPhong
            cboLoaiPhong.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboLoaiPhong.Location =
                new Point(455, 25);

            cboLoaiPhong.Size =
                new Size(220, 28);

            // lblTinhTrang
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new Point(350, 73);
            lblTinhTrang.Text = "Tình trạng";

            // cboTinhTrang
            cboTinhTrang.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboTinhTrang.Location =
                new Point(455, 70);

            cboTinhTrang.Size =
                new Size(220, 28);

            // PictureBox
            picPhong.BorderStyle =
                BorderStyle.FixedSingle;

            picPhong.Location =
                new Point(710, 25);

            picPhong.Size =
                new Size(160, 120);

            picPhong.SizeMode =
                PictureBoxSizeMode.Zoom;

            // Chọn ảnh
            btnChonAnh.Location =
                new Point(710, 155);

            btnChonAnh.Size =
                new Size(160, 35);

            btnChonAnh.Text =
                "Chọn ảnh...";

            btnChonAnh.Click +=
                btnChonAnh_Click;

            // Thêm
            btnThem.Location =
                new Point(920, 25);

            btnThem.Size =
                new Size(100, 40);

            btnThem.Text = "Thêm";

            btnThem.Click +=
                btnThem_Click;

            // Sửa
            btnSua.Location =
                new Point(1035, 25);

            btnSua.Size =
                new Size(100, 40);

            btnSua.Text = "Sửa";

            btnSua.Click +=
                btnSua_Click;

            // Xóa
            btnXoa.Location =
                new Point(1150, 25);

            btnXoa.Size =
                new Size(100, 40);

            btnXoa.Text = "Xóa";

            btnXoa.Click +=
                btnXoa_Click;

            // Làm mới
            btnLamMoi.Location =
                new Point(920, 80);

            btnLamMoi.Size =
                new Size(100, 40);

            btnLamMoi.Text =
                "Làm mới";

            btnLamMoi.Click +=
                btnLamMoi_Click;

            // Quản lý loại phòng
            btnQuanLyLoaiPhong.Location =
                new Point(1035, 80);

            btnQuanLyLoaiPhong.Size =
                new Size(215, 40);

            btnQuanLyLoaiPhong.Text =
                "Quản lý loại phòng";

            btnQuanLyLoaiPhong.Click +=
                btnQuanLyLoaiPhong_Click;

            // Label lọc loại
            lblLocLoai.AutoSize = true;
            lblLocLoai.Location =
                new Point(25, 220);

            lblLocLoai.Text =
                "Loại phòng";

            // cboTimLoaiPhong
            cboTimLoaiPhong.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboTimLoaiPhong.Location =
                new Point(120, 217);

            cboTimLoaiPhong.Size =
                new Size(220, 28);

            // Label lọc tình trạng
            lblLocTinhTrang.AutoSize = true;

            lblLocTinhTrang.Location =
                new Point(375, 220);

            lblLocTinhTrang.Text =
                "Tình trạng";

            // cboTimTinhTrang
            cboTimTinhTrang.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboTimTinhTrang.Location =
                new Point(470, 217);

            cboTimTinhTrang.Size =
                new Size(220, 28);

            // Tìm kiếm
            btnTimKiem.Location =
                new Point(720, 213);

            btnTimKiem.Size =
                new Size(120, 36);

            btnTimKiem.Text =
                "Tìm kiếm";

            btnTimKiem.Click +=
                btnTimKiem_Click;

            // dgvPhong
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.AutoGenerateColumns = false;

            dgvPhong.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvPhong.Columns.AddRange(
                colMaPhong,
                colAnh,
                colSoPhong,
                colTangSo,
                colTenLoai,
                colGiaMoiDem,
                colTinhTrang);

            dgvPhong.Location =
                new Point(25, 280);

            dgvPhong.MultiSelect = false;

            dgvPhong.ReadOnly = true;

            dgvPhong.RowHeadersWidth = 51;

            dgvPhong.RowTemplate.Height = 75;

            dgvPhong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPhong.Size =
                new Size(1225, 405);

            dgvPhong.SelectionChanged +=
                dgvPhong_SelectionChanged;

            // colMaPhong
            colMaPhong.DataPropertyName =
                "MaPhong";

            colMaPhong.HeaderText =
                "Mã phòng";

            colMaPhong.Width = 90;

            // colAnh
            colAnh.DataPropertyName =
                "Anh";

            colAnh.HeaderText =
                "Ảnh";

            colAnh.ImageLayout =
                DataGridViewImageCellLayout.Zoom;

            colAnh.Width = 110;

            // colSoPhong
            colSoPhong.DataPropertyName =
                "SoPhong";

            colSoPhong.HeaderText =
                "Số phòng";

            colSoPhong.Width = 100;

            // colTangSo
            colTangSo.DataPropertyName =
                "TangSo";

            colTangSo.HeaderText =
                "Tầng";

            colTangSo.Width = 80;

            // colTenLoai
            colTenLoai.DataPropertyName =
                "TenLoai";

            colTenLoai.HeaderText =
                "Loại phòng";

            colTenLoai.Width = 180;

            // colGiaMoiDem
            colGiaMoiDem.DataPropertyName =
                "GiaMoiDem";

            colGiaMoiDem.HeaderText =
                "Giá/đêm";

            colGiaMoiDem.Width = 150;

            colGiaMoiDem.DefaultCellStyle.Format =
                "N0";

            // colTinhTrang
            colTinhTrang.DataPropertyName =
                "TinhTrang";

            colTinhTrang.HeaderText =
                "Tình trạng";

            colTinhTrang.Width = 150;

            // Form1
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(1280, 715);

            Controls.Add(lblMaPhong);
            Controls.Add(txtMaPhong);

            Controls.Add(lblSoPhong);
            Controls.Add(txtSoPhong);

            Controls.Add(lblTangSo);
            Controls.Add(numTangSo);

            Controls.Add(lblLoaiPhong);
            Controls.Add(cboLoaiPhong);

            Controls.Add(lblTinhTrang);
            Controls.Add(cboTinhTrang);

            Controls.Add(picPhong);
            Controls.Add(btnChonAnh);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnQuanLyLoaiPhong);

            Controls.Add(lblLocLoai);
            Controls.Add(cboTimLoaiPhong);

            Controls.Add(lblLocTinhTrang);
            Controls.Add(cboTimTinhTrang);

            Controls.Add(btnTimKiem);

            Controls.Add(dgvPhong);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            Name = "Form1";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Quản Lý Phòng - Sunrise Homestay";

            Load += Form1_Load;

            FormClosed +=
                Form1_FormClosed;

            ((System.ComponentModel.ISupportInitialize)numTangSo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPhong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaPhong;
        private Label lblSoPhong;
        private Label lblTangSo;
        private Label lblLoaiPhong;
        private Label lblTinhTrang;

        private TextBox txtMaPhong;
        private TextBox txtSoPhong;

        private NumericUpDown numTangSo;

        private ComboBox cboLoaiPhong;
        private ComboBox cboTinhTrang;

        private PictureBox picPhong;

        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnQuanLyLoaiPhong;

        private Label lblLocLoai;
        private Label lblLocTinhTrang;

        private ComboBox cboTimLoaiPhong;
        private ComboBox cboTimTinhTrang;

        private Button btnTimKiem;

        private DataGridView dgvPhong;

        private DataGridViewTextBoxColumn colMaPhong;
        private DataGridViewImageColumn colAnh;
        private DataGridViewTextBoxColumn colSoPhong;
        private DataGridViewTextBoxColumn colTangSo;
        private DataGridViewTextBoxColumn colTenLoai;
        private DataGridViewTextBoxColumn colGiaMoiDem;
        private DataGridViewTextBoxColumn colTinhTrang;
    }
}