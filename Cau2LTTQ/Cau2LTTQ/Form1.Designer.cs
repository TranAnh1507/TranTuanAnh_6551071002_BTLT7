namespace Cau2LTTQ
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaHV = new Label();
            lblHoTen = new Label();
            lblSDT = new Label();
            lblEmail = new Label();
            lblNgaySinh = new Label();
            lblHangThanhVien = new Label();

            txtMaHV = new TextBox();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();

            grpGioiTinh = new GroupBox();

            radNam = new RadioButton();
            radNu = new RadioButton();

            dtpNgaySinh = new DateTimePicker();

            cboHangThanhVien = new ComboBox();

            chkDangHoatDong = new CheckBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            txtTimKiem = new TextBox();

            lblTimHang = new Label();

            cboTimHang = new ComboBox();

            btnTimKiem = new Button();

            dgvHoiVien = new DataGridView();

            colMaHV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colHangThanhVien = new DataGridViewTextBoxColumn();
            colNgayDangKy = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();

            grpGioiTinh.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)dgvHoiVien)
                .BeginInit();

            SuspendLayout();

            // ==============================
            // lblMaHV
            // ==============================
            lblMaHV.AutoSize = true;
            lblMaHV.Location = new Point(30, 32);
            lblMaHV.Name = "lblMaHV";
            lblMaHV.Size = new Size(91, 20);
            lblMaHV.Text = "Mã hội viên";

            // ==============================
            // txtMaHV
            // ==============================
            txtMaHV.Enabled = false;
            txtMaHV.Location = new Point(150, 29);
            txtMaHV.Name = "txtMaHV";
            txtMaHV.ReadOnly = true;
            txtMaHV.Size = new Size(250, 27);
            txtMaHV.TabStop = false;

            // ==============================
            // lblHoTen
            // ==============================
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 75);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ tên";

            // ==============================
            // txtHoTen
            // ==============================
            txtHoTen.Location = new Point(150, 72);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 27);

            // ==============================
            // lblSDT
            // ==============================
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(30, 118);
            lblSDT.Name = "lblSDT";
            lblSDT.Text = "Số điện thoại";

            // ==============================
            // txtSDT
            // ==============================
            txtSDT.Location = new Point(150, 115);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 27);

            // ==============================
            // lblEmail
            // ==============================
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 161);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email";

            // ==============================
            // txtEmail
            // ==============================
            txtEmail.Location = new Point(150, 158);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);

            // ==============================
            // Group giới tính
            // ==============================
            grpGioiTinh.Controls.Add(radNam);
            grpGioiTinh.Controls.Add(radNu);

            grpGioiTinh.Location = new Point(450, 25);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(230, 90);
            grpGioiTinh.Text = "Giới tính";

            // radNam
            radNam.AutoSize = true;
            radNam.Checked = true;
            radNam.Location = new Point(30, 40);
            radNam.Name = "radNam";
            radNam.Size = new Size(62, 24);
            radNam.Text = "Nam";

            // radNu
            radNu.AutoSize = true;
            radNu.Location = new Point(130, 40);
            radNu.Name = "radNu";
            radNu.Size = new Size(49, 24);
            radNu.Text = "Nữ";

            // ==============================
            // Ngày sinh
            // ==============================
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(30, 204);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh";

            dtpNgaySinh.Format =
                DateTimePickerFormat.Custom;

            dtpNgaySinh.CustomFormat =
                "dd/MM/yyyy";

            dtpNgaySinh.Location =
                new Point(150, 201);

            dtpNgaySinh.Name =
                "dtpNgaySinh";

            dtpNgaySinh.Size =
                new Size(250, 27);

            // ==============================
            // Hạng thành viên
            // ==============================
            lblHangThanhVien.AutoSize = true;

            lblHangThanhVien.Location =
                new Point(30, 247);

            lblHangThanhVien.Name =
                "lblHangThanhVien";

            lblHangThanhVien.Text =
                "Hạng thành viên";

            cboHangThanhVien.Location =
                new Point(150, 244);

            cboHangThanhVien.Name =
                "cboHangThanhVien";

            cboHangThanhVien.Size =
                new Size(250, 28);

            cboHangThanhVien.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // ==============================
            // Checkbox
            // ==============================
            chkDangHoatDong.AutoSize = true;

            chkDangHoatDong.Checked = true;

            chkDangHoatDong.Location =
                new Point(30, 295);

            chkDangHoatDong.Name =
                "chkDangHoatDong";

            chkDangHoatDong.Text =
                "Đang hoạt động";

            // ==============================
            // Các button
            // ==============================
            btnThem.Location =
                new Point(735, 30);

            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.Text = "Thêm";

            btnThem.Click +=
                btnThem_Click;


            btnSua.Location =
                new Point(735, 80);

            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.Text = "Sửa";

            btnSua.Click +=
                btnSua_Click;


            btnXoa.Location =
                new Point(735, 130);

            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.Text = "Xóa";

            btnXoa.Click +=
                btnXoa_Click;


            btnLamMoi.Location =
                new Point(735, 180);

            btnLamMoi.Name =
                "btnLamMoi";

            btnLamMoi.Size =
                new Size(120, 40);

            btnLamMoi.Text =
                "Làm mới";

            btnLamMoi.Click +=
                btnLamMoi_Click;

            // ==============================
            // Tìm kiếm
            // ==============================
            txtTimKiem.Location =
                new Point(30, 350);

            txtTimKiem.Name =
                "txtTimKiem";

            txtTimKiem.PlaceholderText =
                "Nhập họ tên cần tìm...";

            txtTimKiem.Size =
                new Size(300, 27);


            lblTimHang.AutoSize = true;

            lblTimHang.Location =
                new Point(350, 353);

            lblTimHang.Name =
                "lblTimHang";

            lblTimHang.Text =
                "Hạng:";


            cboTimHang.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboTimHang.Location =
                new Point(405, 350);

            cboTimHang.Name =
                "cboTimHang";

            cboTimHang.Size =
                new Size(170, 28);


            btnTimKiem.Location =
                new Point(600, 346);

            btnTimKiem.Name =
                "btnTimKiem";

            btnTimKiem.Size =
                new Size(120, 35);

            btnTimKiem.Text =
                "Tìm kiếm";

            btnTimKiem.Click +=
                btnTimKiem_Click;

            // ==============================
            // DATAGRIDVIEW
            // ==============================
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;

            dgvHoiVien.AutoGenerateColumns = false;

            dgvHoiVien.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvHoiVien.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colMaHV,
                    colHoTen,
                    colGioiTinh,
                    colNgaySinh,
                    colSDT,
                    colEmail,
                    colHangThanhVien,
                    colNgayDangKy,
                    colTrangThai
                });

            dgvHoiVien.Location =
                new Point(30, 405);

            dgvHoiVien.MultiSelect = false;

            dgvHoiVien.Name =
                "dgvHoiVien";

            dgvHoiVien.ReadOnly = true;

            dgvHoiVien.RowHeadersWidth = 51;

            dgvHoiVien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHoiVien.Size =
                new Size(1050, 320);

            dgvHoiVien.SelectionChanged +=
                dgvHoiVien_SelectionChanged;

            dgvHoiVien.CellFormatting +=
                dgvHoiVien_CellFormatting;

            // ==============================
            // COLUMN MaHV
            // ==============================
            colMaHV.DataPropertyName =
                "MaHv";

            colMaHV.HeaderText =
                "Mã HV";

            colMaHV.Name =
                "colMaHV";

            colMaHV.ReadOnly = true;

            colMaHV.Width = 70;

            // ==============================
            // COLUMN Họ tên
            // ==============================
            colHoTen.DataPropertyName =
                "HoTen";

            colHoTen.HeaderText =
                "Họ tên";

            colHoTen.Name =
                "colHoTen";

            colHoTen.ReadOnly = true;

            colHoTen.Width = 150;

            // ==============================
            // COLUMN Giới tính
            // ==============================
            colGioiTinh.DataPropertyName =
                "GioiTinh";

            colGioiTinh.HeaderText =
                "Giới tính";

            colGioiTinh.Name =
                "colGioiTinh";

            colGioiTinh.ReadOnly = true;

            colGioiTinh.Width = 80;

            // ==============================
            // COLUMN Ngày sinh
            // ==============================
            colNgaySinh.DataPropertyName =
                "NgaySinh";

            colNgaySinh.HeaderText =
                "Ngày sinh";

            colNgaySinh.Name =
                "colNgaySinh";

            colNgaySinh.ReadOnly = true;

            colNgaySinh.Width = 100;

            // ==============================
            // COLUMN SDT
            // ==============================
            colSDT.DataPropertyName =
                "Sdt";

            colSDT.HeaderText =
                "SĐT";

            colSDT.Name =
                "colSDT";

            colSDT.ReadOnly = true;

            colSDT.Width = 110;

            // ==============================
            // COLUMN Email
            // ==============================
            colEmail.DataPropertyName =
                "Email";

            colEmail.HeaderText =
                "Email";

            colEmail.Name =
                "colEmail";

            colEmail.ReadOnly = true;

            colEmail.Width = 160;

            // ==============================
            // COLUMN Hạng
            // ==============================
            colHangThanhVien.DataPropertyName =
                "HangThanhVien";

            colHangThanhVien.HeaderText =
                "Hạng thành viên";

            colHangThanhVien.Name =
                "colHangThanhVien";

            colHangThanhVien.ReadOnly = true;

            colHangThanhVien.Width = 120;

            // ==============================
            // COLUMN Ngày đăng ký
            // ==============================
            colNgayDangKy.DataPropertyName =
                "NgayDangKy";

            colNgayDangKy.HeaderText =
                "Ngày đăng ký";

            colNgayDangKy.Name =
                "colNgayDangKy";

            colNgayDangKy.ReadOnly = true;

            colNgayDangKy.Width = 140;

            // ==============================
            // COLUMN Trạng thái
            // ==============================
            colTrangThai.DataPropertyName =
                "TrangThai";

            colTrangThai.HeaderText =
                "Trạng thái";

            colTrangThai.Name =
                "colTrangThai";

            colTrangThai.ReadOnly = true;

            colTrangThai.Width = 130;

            // ==============================
            // FORM
            // ==============================
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(1110, 755);

            Controls.Add(lblMaHV);
            Controls.Add(txtMaHV);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(lblEmail);
            Controls.Add(txtEmail);

            Controls.Add(grpGioiTinh);

            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);

            Controls.Add(lblHangThanhVien);
            Controls.Add(cboHangThanhVien);

            Controls.Add(chkDangHoatDong);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(txtTimKiem);
            Controls.Add(lblTimHang);
            Controls.Add(cboTimHang);
            Controls.Add(btnTimKiem);

            Controls.Add(dgvHoiVien);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            Name = "Form1";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Quản Lý Hội Viên Phòng Gym FitZone";

            Load += Form1_Load;

            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvHoiVien)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaHV;
        private Label lblHoTen;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblNgaySinh;
        private Label lblHangThanhVien;

        private TextBox txtMaHV;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtEmail;

        private GroupBox grpGioiTinh;

        private RadioButton radNam;
        private RadioButton radNu;

        private DateTimePicker dtpNgaySinh;

        private ComboBox cboHangThanhVien;

        private CheckBox chkDangHoatDong;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private TextBox txtTimKiem;

        private Label lblTimHang;

        private ComboBox cboTimHang;

        private Button btnTimKiem;

        private DataGridView dgvHoiVien;

        private DataGridViewTextBoxColumn colMaHV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colHangThanhVien;
        private DataGridViewTextBoxColumn colNgayDangKy;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}