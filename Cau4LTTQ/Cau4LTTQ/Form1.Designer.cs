namespace Cau4LTTQ
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
            lblMaLich = new Label();
            lblTenBenhNhan = new Label();
            lblSDT = new Label();
            lblNgayKham = new Label();
            lblGioKham = new Label();
            lblBacSi = new Label();
            lblTrangThai = new Label();

            txtMaLich = new TextBox();
            txtTenBenhNhan = new TextBox();
            txtSDT = new TextBox();

            dtpNgayKham = new DateTimePicker();
            dtpGioKham = new DateTimePicker();

            cboBacSi = new ComboBox();
            cboTrangThai = new ComboBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnQuanLyBacSi = new Button();

            lblTuNgay = new Label();
            lblDenNgay = new Label();
            lblTimBacSi = new Label();

            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();

            cboTimBacSi = new ComboBox();

            btnTimKiem = new Button();

            dgvLichKham = new DataGridView();

            colMaLich = new DataGridViewTextBoxColumn();
            colTenBenhNhan = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colNgayKham = new DataGridViewTextBoxColumn();
            colGioKham = new DataGridViewTextBoxColumn();
            colTenBacSi = new DataGridViewTextBoxColumn();
            colChuyenKhoa = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();

            SuspendLayout();

            // Mã lịch
            lblMaLich.AutoSize = true;
            lblMaLich.Location = new Point(25, 25);
            lblMaLich.Text = "Mã lịch";

            txtMaLich.Enabled = false;
            txtMaLich.Location = new Point(145, 22);
            txtMaLich.ReadOnly = true;
            txtMaLich.Size = new Size(245, 27);
            txtMaLich.TabStop = false;

            // Tên bệnh nhân
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Location = new Point(25, 68);
            lblTenBenhNhan.Text = "Tên bệnh nhân";

            txtTenBenhNhan.Location = new Point(145, 65);
            txtTenBenhNhan.Size = new Size(245, 27);

            // SĐT
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(25, 111);
            lblSDT.Text = "Số điện thoại";

            txtSDT.Location = new Point(145, 108);
            txtSDT.Size = new Size(245, 27);

            // Ngày khám
            lblNgayKham.AutoSize = true;
            lblNgayKham.Location = new Point(25, 154);
            lblNgayKham.Text = "Ngày khám";

            dtpNgayKham.Format =
                DateTimePickerFormat.Custom;

            dtpNgayKham.CustomFormat =
                "dd/MM/yyyy";

            dtpNgayKham.Location =
                new Point(145, 151);

            dtpNgayKham.Size =
                new Size(245, 27);

            // Giờ khám
            lblGioKham.AutoSize = true;
            lblGioKham.Location = new Point(430, 25);
            lblGioKham.Text = "Giờ khám";

            dtpGioKham.Format =
                DateTimePickerFormat.Custom;

            dtpGioKham.CustomFormat =
                "HH:mm";

            dtpGioKham.ShowUpDown = true;

            dtpGioKham.Location =
                new Point(525, 22);

            dtpGioKham.Size =
                new Size(150, 27);

            // Bác sĩ
            lblBacSi.AutoSize = true;
            lblBacSi.Location = new Point(430, 68);
            lblBacSi.Text = "Bác sĩ";

            cboBacSi.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboBacSi.Location =
                new Point(525, 65);

            cboBacSi.Size =
                new Size(335, 28);

            // Trạng thái
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(430, 111);
            lblTrangThai.Text = "Trạng thái";

            cboTrangThai.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboTrangThai.Location =
                new Point(525, 108);

            cboTrangThai.Size =
                new Size(200, 28);

            // Buttons
            btnThem.Location = new Point(900, 22);
            btnThem.Size = new Size(100, 40);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1015, 22);
            btnSua.Size = new Size(100, 40);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1130, 22);
            btnXoa.Size = new Size(100, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(900, 75);
            btnLamMoi.Size = new Size(100, 40);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            btnQuanLyBacSi.Location = new Point(1015, 75);
            btnQuanLyBacSi.Size = new Size(215, 40);
            btnQuanLyBacSi.Text = "Quản lý bác sĩ";
            btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;

            // Từ ngày
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(25, 220);
            lblTuNgay.Text = "Từ ngày";

            dtpTuNgay.Format =
                DateTimePickerFormat.Custom;

            dtpTuNgay.CustomFormat =
                "dd/MM/yyyy";

            dtpTuNgay.Location =
                new Point(100, 217);

            dtpTuNgay.Size =
                new Size(160, 27);

            // Đến ngày
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(285, 220);
            lblDenNgay.Text = "Đến ngày";

            dtpDenNgay.Format =
                DateTimePickerFormat.Custom;

            dtpDenNgay.CustomFormat =
                "dd/MM/yyyy";

            dtpDenNgay.Location =
                new Point(370, 217);

            dtpDenNgay.Size =
                new Size(160, 27);

            // Bác sĩ tìm kiếm
            lblTimBacSi.AutoSize = true;
            lblTimBacSi.Location = new Point(560, 220);
            lblTimBacSi.Text = "Bác sĩ";

            cboTimBacSi.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboTimBacSi.Location =
                new Point(620, 217);

            cboTimBacSi.Size =
                new Size(340, 28);

            // Tìm kiếm
            btnTimKiem.Location = new Point(985, 213);
            btnTimKiem.Size = new Size(110, 36);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click;

            // Grid
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoGenerateColumns = false;

            dgvLichKham.Columns.AddRange(
                colMaLich,
                colTenBenhNhan,
                colSDT,
                colNgayKham,
                colGioKham,
                colTenBacSi,
                colChuyenKhoa,
                colTrangThai);

            dgvLichKham.Location =
                new Point(25, 280);

            dgvLichKham.MultiSelect = false;
            dgvLichKham.ReadOnly = true;

            dgvLichKham.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLichKham.Size =
                new Size(1205, 400);

            dgvLichKham.SelectionChanged +=
                dgvLichKham_SelectionChanged;

            colMaLich.DataPropertyName = "MaLich";
            colMaLich.HeaderText = "Mã lịch";
            colMaLich.Width = 75;

            colTenBenhNhan.DataPropertyName =
                "TenBenhNhan";

            colTenBenhNhan.HeaderText =
                "Tên bệnh nhân";

            colTenBenhNhan.Width = 170;

            colSDT.DataPropertyName = "Sdt";
            colSDT.HeaderText = "SĐT";
            colSDT.Width = 110;

            colNgayKham.DataPropertyName =
                "NgayKhamText";

            colNgayKham.HeaderText =
                "Ngày khám";

            colNgayKham.Width = 105;

            colGioKham.DataPropertyName =
                "GioKhamText";

            colGioKham.HeaderText =
                "Giờ khám";

            colGioKham.Width = 90;

            colTenBacSi.DataPropertyName =
                "TenBacSi";

            colTenBacSi.HeaderText =
                "Bác sĩ";

            colTenBacSi.Width = 180;

            colChuyenKhoa.DataPropertyName =
                "ChuyenKhoa";

            colChuyenKhoa.HeaderText =
                "Chuyên khoa";

            colChuyenKhoa.Width = 170;

            colTrangThai.DataPropertyName =
                "TrangThai";

            colTrangThai.HeaderText =
                "Trạng thái";

            colTrangThai.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            // Form
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(1260, 710);

            Controls.Add(lblMaLich);
            Controls.Add(txtMaLich);

            Controls.Add(lblTenBenhNhan);
            Controls.Add(txtTenBenhNhan);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(lblNgayKham);
            Controls.Add(dtpNgayKham);

            Controls.Add(lblGioKham);
            Controls.Add(dtpGioKham);

            Controls.Add(lblBacSi);
            Controls.Add(cboBacSi);

            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnQuanLyBacSi);

            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);

            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);

            Controls.Add(lblTimBacSi);
            Controls.Add(cboTimBacSi);

            Controls.Add(btnTimKiem);

            Controls.Add(dgvLichKham);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            Name = "Form1";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Quản Lý Lịch Khám Bệnh - An Khang Clinic";

            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaLich;
        private Label lblTenBenhNhan;
        private Label lblSDT;
        private Label lblNgayKham;
        private Label lblGioKham;
        private Label lblBacSi;
        private Label lblTrangThai;

        private TextBox txtMaLich;
        private TextBox txtTenBenhNhan;
        private TextBox txtSDT;

        private DateTimePicker dtpNgayKham;
        private DateTimePicker dtpGioKham;

        private ComboBox cboBacSi;
        private ComboBox cboTrangThai;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnQuanLyBacSi;

        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblTimBacSi;

        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;

        private ComboBox cboTimBacSi;

        private Button btnTimKiem;

        private DataGridView dgvLichKham;

        private DataGridViewTextBoxColumn colMaLich;
        private DataGridViewTextBoxColumn colTenBenhNhan;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colNgayKham;
        private DataGridViewTextBoxColumn colGioKham;
        private DataGridViewTextBoxColumn colTenBacSi;
        private DataGridViewTextBoxColumn colChuyenKhoa;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}