using static System.Net.Mime.MediaTypeNames;

namespace Cau3LTTQ
{
    partial class FrmLoaiPhong
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
            lblMaLoai = new Label();
            lblTenLoai = new Label();
            lblGia = new Label();
            lblMoTa = new Label();

            txtMaLoai = new TextBox();
            txtTenLoai = new TextBox();
            txtMoTa = new TextBox();

            numGia = new NumericUpDown();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            dgvLoaiPhong = new DataGridView();

            colMaLoai = new DataGridViewTextBoxColumn();
            colTenLoai = new DataGridViewTextBoxColumn();
            colGiaMoiDem = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).BeginInit();

            SuspendLayout();

            // lblMaLoai
            lblMaLoai.AutoSize = true;
            lblMaLoai.Location = new Point(30, 30);
            lblMaLoai.Text = "Mã loại";

            // txtMaLoai
            txtMaLoai.Enabled = false;
            txtMaLoai.Location = new Point(130, 27);
            txtMaLoai.ReadOnly = true;
            txtMaLoai.Size = new Size(260, 27);
            txtMaLoai.TabStop = false;

            // lblTenLoai
            lblTenLoai.AutoSize = true;
            lblTenLoai.Location = new Point(30, 75);
            lblTenLoai.Text = "Tên loại";

            // txtTenLoai
            txtTenLoai.Location = new Point(130, 72);
            txtTenLoai.Size = new Size(260, 27);

            // lblGia
            lblGia.AutoSize = true;
            lblGia.Location = new Point(30, 120);
            lblGia.Text = "Giá mỗi đêm";

            // numGia
            numGia.Location = new Point(130, 117);
            numGia.Maximum = 100000000;
            numGia.Minimum = 0;
            numGia.Size = new Size(260, 27);
            numGia.ThousandsSeparator = true;

            // lblMoTa
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(30, 165);
            lblMoTa.Text = "Mô tả";

            // txtMoTa
            txtMoTa.Location = new Point(130, 162);
            txtMoTa.Multiline = true;
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(260, 85);

            // btnThem
            btnThem.Location = new Point(450, 27);
            btnThem.Size = new Size(105, 40);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(570, 27);
            btnSua.Size = new Size(105, 40);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(690, 27);
            btnXoa.Size = new Size(105, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(810, 27);
            btnLamMoi.Size = new Size(105, 40);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            // dgvLoaiPhong
            dgvLoaiPhong.AllowUserToAddRows = false;
            dgvLoaiPhong.AllowUserToDeleteRows = false;
            dgvLoaiPhong.AutoGenerateColumns = false;
            dgvLoaiPhong.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvLoaiPhong.Columns.AddRange(
                colMaLoai,
                colTenLoai,
                colGiaMoiDem,
                colMoTa);

            dgvLoaiPhong.Location = new Point(30, 285);
            dgvLoaiPhong.MultiSelect = false;
            dgvLoaiPhong.ReadOnly = true;
            dgvLoaiPhong.RowHeadersWidth = 51;

            dgvLoaiPhong.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLoaiPhong.Size = new Size(885, 320);

            dgvLoaiPhong.SelectionChanged +=
                dgvLoaiPhong_SelectionChanged;

            // colMaLoai
            colMaLoai.DataPropertyName = "MaLoai";
            colMaLoai.HeaderText = "Mã loại";
            colMaLoai.Width = 90;

            // colTenLoai
            colTenLoai.DataPropertyName = "TenLoai";
            colTenLoai.HeaderText = "Tên loại";
            colTenLoai.Width = 190;

            // colGiaMoiDem
            colGiaMoiDem.DataPropertyName = "GiaMoiDem";
            colGiaMoiDem.HeaderText = "Giá mỗi đêm";
            colGiaMoiDem.Width = 160;
            colGiaMoiDem.DefaultCellStyle.Format = "N0";

            // colMoTa
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.HeaderText = "Mô tả";

            colMoTa.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            // FrmLoaiPhong
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(950, 640);

            Controls.Add(lblMaLoai);
            Controls.Add(txtMaLoai);

            Controls.Add(lblTenLoai);
            Controls.Add(txtTenLoai);

            Controls.Add(lblGia);
            Controls.Add(numGia);

            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(dgvLoaiPhong);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Name = "FrmLoaiPhong";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Quản Lý Loại Phòng - Sunrise Homestay";

            Load += FrmLoaiPhong_Load;

            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaLoai;
        private Label lblTenLoai;
        private Label lblGia;
        private Label lblMoTa;

        private TextBox txtMaLoai;
        private TextBox txtTenLoai;
        private TextBox txtMoTa;

        private NumericUpDown numGia;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvLoaiPhong;

        private DataGridViewTextBoxColumn colMaLoai;
        private DataGridViewTextBoxColumn colTenLoai;
        private DataGridViewTextBoxColumn colGiaMoiDem;
        private DataGridViewTextBoxColumn colMoTa;
    }
}