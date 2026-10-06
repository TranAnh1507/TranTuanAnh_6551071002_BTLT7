namespace Cau4LTTQ
{
    partial class FrmBacSi
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
            lblMaBS = new Label();
            lblHoTen = new Label();
            lblChuyenKhoa = new Label();
            lblSDT = new Label();

            txtMaBS = new TextBox();
            txtHoTen = new TextBox();
            txtChuyenKhoa = new TextBox();
            txtSDT = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();

            dgvBacSi = new DataGridView();

            colMaBS = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colChuyenKhoa = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();

            SuspendLayout();

            // Mã bác sĩ
            lblMaBS.AutoSize = true;
            lblMaBS.Location = new Point(30, 30);
            lblMaBS.Text = "Mã bác sĩ";

            txtMaBS.Enabled = false;
            txtMaBS.Location = new Point(145, 27);
            txtMaBS.ReadOnly = true;
            txtMaBS.Size = new Size(250, 27);
            txtMaBS.TabStop = false;

            // Họ tên
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 75);
            lblHoTen.Text = "Họ tên";

            txtHoTen.Location = new Point(145, 72);
            txtHoTen.Size = new Size(250, 27);

            // Chuyên khoa
            lblChuyenKhoa.AutoSize = true;
            lblChuyenKhoa.Location = new Point(30, 120);
            lblChuyenKhoa.Text = "Chuyên khoa";

            txtChuyenKhoa.Location = new Point(145, 117);
            txtChuyenKhoa.Size = new Size(250, 27);

            // SĐT
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(30, 165);
            lblSDT.Text = "Số điện thoại";

            txtSDT.Location = new Point(145, 162);
            txtSDT.Size = new Size(250, 27);

            // Buttons
            btnThem.Location = new Point(450, 27);
            btnThem.Size = new Size(105, 40);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(570, 27);
            btnSua.Size = new Size(105, 40);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(690, 27);
            btnXoa.Size = new Size(105, 40);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(810, 27);
            btnLamMoi.Size = new Size(105, 40);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            // DataGridView
            dgvBacSi.AllowUserToAddRows = false;
            dgvBacSi.AllowUserToDeleteRows = false;
            dgvBacSi.AutoGenerateColumns = false;

            dgvBacSi.Columns.AddRange(
                colMaBS,
                colHoTen,
                colChuyenKhoa,
                colSDT);

            dgvBacSi.Location = new Point(30, 230);
            dgvBacSi.MultiSelect = false;
            dgvBacSi.ReadOnly = true;
            dgvBacSi.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBacSi.Size = new Size(885, 320);

            dgvBacSi.SelectionChanged +=
                dgvBacSi_SelectionChanged;

            colMaBS.DataPropertyName = "MaBs";
            colMaBS.HeaderText = "Mã BS";
            colMaBS.Width = 100;

            colHoTen.DataPropertyName = "HoTen";
            colHoTen.HeaderText = "Họ tên";
            colHoTen.Width = 240;

            colChuyenKhoa.DataPropertyName = "ChuyenKhoa";
            colChuyenKhoa.HeaderText = "Chuyên khoa";
            colChuyenKhoa.Width = 260;

            colSDT.DataPropertyName = "Sdt";
            colSDT.HeaderText = "SĐT";
            colSDT.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            // Form
            ClientSize = new Size(950, 585);

            Controls.Add(lblMaBS);
            Controls.Add(txtMaBS);

            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);

            Controls.Add(lblChuyenKhoa);
            Controls.Add(txtChuyenKhoa);

            Controls.Add(lblSDT);
            Controls.Add(txtSDT);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(dgvBacSi);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Name = "FrmBacSi";
            StartPosition = FormStartPosition.CenterParent;

            Text = "Quản Lý Bác Sĩ - An Khang Clinic";

            Load += FrmBacSi_Load;

            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaBS;
        private Label lblHoTen;
        private Label lblChuyenKhoa;
        private Label lblSDT;

        private TextBox txtMaBS;
        private TextBox txtHoTen;
        private TextBox txtChuyenKhoa;
        private TextBox txtSDT;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvBacSi;

        private DataGridViewTextBoxColumn colMaBS;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colChuyenKhoa;
        private DataGridViewTextBoxColumn colSDT;
    }
}