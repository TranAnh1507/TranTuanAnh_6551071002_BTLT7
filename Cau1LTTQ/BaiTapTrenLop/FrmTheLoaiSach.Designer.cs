namespace QuanLyTheLoaiSach
{
    partial class FrmTheLoaiSach
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblMaTL = new Label();
            lblTenTheLoai = new Label();
            lblMoTa = new Label();
            lblNgayTaoTitle = new Label();

            txtMaTL = new TextBox();
            txtTenTheLoai = new TextBox();
            txtMoTa = new TextBox();

            lblNgayTao = new Label();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            txtTimKiem = new TextBox();
            btnTimKiem = new Button();

            dgvTheLoaiSach = new DataGridView();

            colMaTL = new DataGridViewTextBoxColumn();
            colTenTheLoai = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();
            colSoLuongSach = new DataGridViewTextBoxColumn();
            colNgayTao = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach).BeginInit();

            SuspendLayout();

            // lblMaTL
            lblMaTL.AutoSize = true;
            lblMaTL.Location = new Point(25, 30);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new Size(76, 20);
            lblMaTL.Text = "Mã thể loại";

            // txtMaTL
            txtMaTL.Location = new Point(125, 27);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.ReadOnly = true;
            txtMaTL.Enabled = false;
            txtMaTL.TabStop = false;
            txtMaTL.Size = new Size(250, 27);
            txtMaTL.TabIndex = 0;

            // lblTenTheLoai
            lblTenTheLoai.AutoSize = true;
            lblTenTheLoai.Location = new Point(25, 75);
            lblTenTheLoai.Name = "lblTenTheLoai";
            lblTenTheLoai.Size = new Size(87, 20);
            lblTenTheLoai.Text = "Tên thể loại";

            // txtTenTheLoai
            txtTenTheLoai.Location = new Point(125, 72);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(250, 27);
            txtTenTheLoai.TabIndex = 1;

            // lblMoTa
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(25, 120);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(47, 20);
            lblMoTa.Text = "Mô tả";

            // txtMoTa
            txtMoTa.Location = new Point(125, 117);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(250, 90);
            txtMoTa.TabIndex = 2;

            // lblNgayTaoTitle
            lblNgayTaoTitle.AutoSize = true;
            lblNgayTaoTitle.Location = new Point(25, 225);
            lblNgayTaoTitle.Name = "lblNgayTaoTitle";
            lblNgayTaoTitle.Size = new Size(70, 20);
            lblNgayTaoTitle.Text = "Ngày tạo";

            // lblNgayTao
            lblNgayTao.AutoSize = true;
            lblNgayTao.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold,
                GraphicsUnit.Point);

            lblNgayTao.Location = new Point(125, 225);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(14, 20);
            lblNgayTao.Text = "-";

            // btnThem
            btnThem.Location = new Point(455, 27);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 38);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(570, 27);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 38);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(685, 27);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 38);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(800, 27);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 38);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;

            // txtTimKiem
            txtTimKiem.Location = new Point(25, 280);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm...";
            txtTimKiem.Size = new Size(350, 27);
            txtTimKiem.TabIndex = 7;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // btnTimKiem
            btnTimKiem.Location = new Point(390, 276);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 35);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;

            // dgvTheLoaiSach
            dgvTheLoaiSach.AllowUserToAddRows = false;
            dgvTheLoaiSach.AllowUserToDeleteRows = false;
            dgvTheLoaiSach.AutoGenerateColumns = false;
            dgvTheLoaiSach.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTheLoaiSach.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvTheLoaiSach.Columns.AddRange(
                new DataGridViewColumn[]
                {
                    colMaTL,
                    colTenTheLoai,
                    colMoTa,
                    colSoLuongSach,
                    colNgayTao
                });

            dgvTheLoaiSach.Location = new Point(25, 330);
            dgvTheLoaiSach.MultiSelect = false;
            dgvTheLoaiSach.Name = "dgvTheLoaiSach";
            dgvTheLoaiSach.ReadOnly = true;

            dgvTheLoaiSach.RowHeadersWidth = 51;

            dgvTheLoaiSach.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTheLoaiSach.Size = new Size(875, 300);
            dgvTheLoaiSach.TabIndex = 9;

            dgvTheLoaiSach.SelectionChanged +=
                dgvTheLoaiSach_SelectionChanged;

            // colMaTL
            colMaTL.DataPropertyName = "MaTl";
            colMaTL.HeaderText = "Mã TL";
            colMaTL.MinimumWidth = 6;
            colMaTL.Name = "colMaTL";
            colMaTL.ReadOnly = true;
            colMaTL.FillWeight = 45;

            // colTenTheLoai
            colTenTheLoai.DataPropertyName = "TenTheLoai";
            colTenTheLoai.HeaderText = "Tên thể loại";
            colTenTheLoai.MinimumWidth = 6;
            colTenTheLoai.Name = "colTenTheLoai";
            colTenTheLoai.ReadOnly = true;
            colTenTheLoai.FillWeight = 100;

            // colMoTa
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.HeaderText = "Mô tả";
            colMoTa.MinimumWidth = 6;
            colMoTa.Name = "colMoTa";
            colMoTa.ReadOnly = true;
            colMoTa.FillWeight = 150;

            // colSoLuongSach
            colSoLuongSach.DataPropertyName = "SoLuongSach";
            colSoLuongSach.HeaderText = "Số lượng sách";
            colSoLuongSach.MinimumWidth = 6;
            colSoLuongSach.Name = "colSoLuongSach";
            colSoLuongSach.ReadOnly = true;
            colSoLuongSach.FillWeight = 70;

            // colNgayTao
            colNgayTao.DataPropertyName = "NgayTao";
            colNgayTao.HeaderText = "Ngày tạo";
            colNgayTao.MinimumWidth = 6;
            colNgayTao.Name = "colNgayTao";
            colNgayTao.ReadOnly = true;
            colNgayTao.FillWeight = 100;
            colNgayTao.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            // FrmTheLoaiSach
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(930, 660);

            Controls.Add(lblMaTL);
            Controls.Add(txtMaTL);

            Controls.Add(lblTenTheLoai);
            Controls.Add(txtTenTheLoai);

            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);

            Controls.Add(lblNgayTaoTitle);
            Controls.Add(lblNgayTao);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);

            Controls.Add(dgvTheLoaiSach);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Name = "FrmTheLoaiSach";

            StartPosition = FormStartPosition.CenterScreen;

            Text = "Quản Lý Thể Loại Sách - Tri Thức Books";

            Load += FrmTheLoaiSach_Load;

            ((System.ComponentModel.ISupportInitialize)dgvTheLoaiSach)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaTL;
        private Label lblTenTheLoai;
        private Label lblMoTa;
        private Label lblNgayTaoTitle;

        private TextBox txtMaTL;
        private TextBox txtTenTheLoai;
        private TextBox txtMoTa;

        private Label lblNgayTao;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private TextBox txtTimKiem;
        private Button btnTimKiem;

        private DataGridView dgvTheLoaiSach;

        private DataGridViewTextBoxColumn colMaTL;
        private DataGridViewTextBoxColumn colTenTheLoai;
        private DataGridViewTextBoxColumn colMoTa;
        private DataGridViewTextBoxColumn colSoLuongSach;
        private DataGridViewTextBoxColumn colNgayTao;
    }
}