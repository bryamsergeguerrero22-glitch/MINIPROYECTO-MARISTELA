namespace ProyectoMini
{
    partial class Lider
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lider));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnsalir = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblNombreUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRolUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunabtnProgramarReunion = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.gunaDGVConsultarLider = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2btnModificarReunion = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDGVConsultarLider)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnsalir);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.gunabtnProgramarReunion);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(202)))), ((int)(((byte)(183)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(292, 558);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnsalir
            // 
            this.btnsalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(82)))), ((int)(((byte)(53)))));
            this.btnsalir.BorderColor = System.Drawing.Color.White;
            this.btnsalir.BorderRadius = 2;
            this.btnsalir.BorderThickness = 1;
            this.btnsalir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsalir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsalir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsalir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsalir.FillColor = System.Drawing.Color.Transparent;
            this.btnsalir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnsalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnsalir.Image = ((System.Drawing.Image)(resources.GetObject("btnsalir.Image")));
            this.btnsalir.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnsalir.ImageSize = new System.Drawing.Size(30, 30);
            this.btnsalir.Location = new System.Drawing.Point(0, 506);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnsalir.Size = new System.Drawing.Size(292, 52);
            this.btnsalir.TabIndex = 5;
            this.btnsalir.Text = "Cerrar Sesion";
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click_2);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(161)))), ((int)(((byte)(146)))));
            this.guna2Panel2.BorderRadius = 18;
            this.guna2Panel2.BorderThickness = 3;
            this.guna2Panel2.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel2.Controls.Add(this.lblNombreUsuario);
            this.guna2Panel2.Controls.Add(this.lblRolUsuario);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(176)))), ((int)(((byte)(157)))));
            this.guna2Panel2.Location = new System.Drawing.Point(5, 4);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(281, 188);
            this.guna2Panel2.TabIndex = 4;
            this.guna2Panel2.UseTransparentBackground = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(53, 16);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(165, 78);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(176)))), ((int)(((byte)(157)))));
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(45, 101);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(193, 34);
            this.lblNombreUsuario.TabIndex = 2;
            this.lblNombreUsuario.Text = "guna2HtmlLabel1";
            // 
            // lblRolUsuario
            // 
            this.lblRolUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRolUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(176)))), ((int)(((byte)(157)))));
            this.lblRolUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblRolUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRolUsuario.Location = new System.Drawing.Point(45, 129);
            this.lblRolUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.lblRolUsuario.Name = "lblRolUsuario";
            this.lblRolUsuario.Size = new System.Drawing.Size(156, 27);
            this.lblRolUsuario.TabIndex = 3;
            this.lblRolUsuario.Text = "guna2HtmlLabel2";
            // 
            // gunabtnProgramarReunion
            // 
            this.gunabtnProgramarReunion.BackColor = System.Drawing.Color.Transparent;
            this.gunabtnProgramarReunion.BorderColor = System.Drawing.Color.White;
            this.gunabtnProgramarReunion.BorderRadius = 3;
            this.gunabtnProgramarReunion.BorderThickness = 1;
            this.gunabtnProgramarReunion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunabtnProgramarReunion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunabtnProgramarReunion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunabtnProgramarReunion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunabtnProgramarReunion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(209)))), ((int)(((byte)(197)))));
            this.gunabtnProgramarReunion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.gunabtnProgramarReunion.ForeColor = System.Drawing.Color.White;
            this.gunabtnProgramarReunion.Image = ((System.Drawing.Image)(resources.GetObject("gunabtnProgramarReunion.Image")));
            this.gunabtnProgramarReunion.ImageSize = new System.Drawing.Size(30, 30);
            this.gunabtnProgramarReunion.Location = new System.Drawing.Point(5, 313);
            this.gunabtnProgramarReunion.Margin = new System.Windows.Forms.Padding(4);
            this.gunabtnProgramarReunion.Name = "gunabtnProgramarReunion";
            this.gunabtnProgramarReunion.Size = new System.Drawing.Size(283, 55);
            this.gunabtnProgramarReunion.TabIndex = 1;
            this.gunabtnProgramarReunion.Text = "Programar Reunion";
            this.gunabtnProgramarReunion.Click += new System.EventHandler(this.gunabtnProgramarReunion_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.White;
            this.guna2Button1.BorderRadius = 3;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(209)))), ((int)(((byte)(197)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(4, 224);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(284, 55);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Consultar Reuniones";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // gunaDGVConsultarLider
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(210)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.gunaDGVConsultarLider.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gunaDGVConsultarLider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaDGVConsultarLider.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gunaDGVConsultarLider.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gunaDGVConsultarLider.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(239)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(178)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(178)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaDGVConsultarLider.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gunaDGVConsultarLider.ColumnHeadersHeight = 40;
            this.gunaDGVConsultarLider.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(210)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaDGVConsultarLider.DefaultCellStyle = dataGridViewCellStyle9;
            this.gunaDGVConsultarLider.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.Location = new System.Drawing.Point(363, 106);
            this.gunaDGVConsultarLider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaDGVConsultarLider.MultiSelect = false;
            this.gunaDGVConsultarLider.Name = "gunaDGVConsultarLider";
            this.gunaDGVConsultarLider.ReadOnly = true;
            this.gunaDGVConsultarLider.RowHeadersVisible = false;
            this.gunaDGVConsultarLider.RowHeadersWidth = 51;
            this.gunaDGVConsultarLider.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDGVConsultarLider.RowTemplate.Height = 40;
            this.gunaDGVConsultarLider.Size = new System.Drawing.Size(1040, 325);
            this.gunaDGVConsultarLider.TabIndex = 4;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaDGVConsultarLider.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(239)))), ((int)(((byte)(238)))));
            this.gunaDGVConsultarLider.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.Height = 40;
            this.gunaDGVConsultarLider.ThemeStyle.ReadOnly = true;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.Height = 40;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2btnModificarReunion
            // 
            this.guna2btnModificarReunion.BackColor = System.Drawing.Color.Transparent;
            this.guna2btnModificarReunion.BorderColor = System.Drawing.Color.White;
            this.guna2btnModificarReunion.BorderRadius = 3;
            this.guna2btnModificarReunion.BorderThickness = 1;
            this.guna2btnModificarReunion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnModificarReunion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnModificarReunion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnModificarReunion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnModificarReunion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(209)))), ((int)(((byte)(197)))));
            this.guna2btnModificarReunion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.guna2btnModificarReunion.ForeColor = System.Drawing.Color.White;
            this.guna2btnModificarReunion.Image = ((System.Drawing.Image)(resources.GetObject("guna2btnModificarReunion.Image")));
            this.guna2btnModificarReunion.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2btnModificarReunion.Location = new System.Drawing.Point(772, 490);
            this.guna2btnModificarReunion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2btnModificarReunion.Name = "guna2btnModificarReunion";
            this.guna2btnModificarReunion.Size = new System.Drawing.Size(281, 55);
            this.guna2btnModificarReunion.TabIndex = 5;
            this.guna2btnModificarReunion.Text = "Modificar reunión";
            this.guna2btnModificarReunion.UseTransparentBackground = true;
            this.guna2btnModificarReunion.Click += new System.EventHandler(this.guna2btnModificarReunion_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(176)))), ((int)(((byte)(157)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1364, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(52, 40);
            this.guna2ControlBox1.TabIndex = 6;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(176)))), ((int)(((byte)(157)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1315, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(51, 40);
            this.guna2ControlBox2.TabIndex = 7;
            // 
            // Lider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1415, 558);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2btnModificarReunion);
            this.Controls.Add(this.gunaDGVConsultarLider);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Lider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lider";
            this.Load += new System.EventHandler(this.Lider_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDGVConsultarLider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button gunabtnProgramarReunion;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRolUsuario;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNombreUsuario;
        private Guna.UI2.WinForms.Guna2DataGridView gunaDGVConsultarLider;
        private Guna.UI2.WinForms.Guna2Button guna2btnModificarReunion;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnsalir;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
    }
}