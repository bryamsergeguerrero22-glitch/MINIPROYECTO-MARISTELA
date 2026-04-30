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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnsalir = new System.Windows.Forms.Button();
            this.lblRolUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNombreUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunabtnProgramarReunion = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.gunaDGVConsultarLider = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2btnModificarReunion = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDGVConsultarLider)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnsalir);
            this.guna2Panel1.Controls.Add(this.lblRolUsuario);
            this.guna2Panel1.Controls.Add(this.lblNombreUsuario);
            this.guna2Panel1.Controls.Add(this.gunabtnProgramarReunion);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(202)))), ((int)(((byte)(183)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(219, 519);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.Brown;
            this.btnsalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsalir.Location = new System.Drawing.Point(40, 436);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(128, 46);
            this.btnsalir.TabIndex = 3;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // lblRolUsuario
            // 
            this.lblRolUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblRolUsuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRolUsuario.Location = new System.Drawing.Point(64, 100);
            this.lblRolUsuario.Name = "lblRolUsuario";
            this.lblRolUsuario.Size = new System.Drawing.Size(86, 15);
            this.lblRolUsuario.TabIndex = 3;
            this.lblRolUsuario.Text = "guna2HtmlLabel2";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNombreUsuario.Location = new System.Drawing.Point(40, 72);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(144, 22);
            this.lblNombreUsuario.TabIndex = 2;
            this.lblNombreUsuario.Text = "guna2HtmlLabel1";
            // 
            // gunabtnProgramarReunion
            // 
            this.gunabtnProgramarReunion.BackColor = System.Drawing.Color.Transparent;
            this.gunabtnProgramarReunion.BorderRadius = 18;
            this.gunabtnProgramarReunion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gunabtnProgramarReunion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gunabtnProgramarReunion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gunabtnProgramarReunion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gunabtnProgramarReunion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunabtnProgramarReunion.ForeColor = System.Drawing.Color.White;
            this.gunabtnProgramarReunion.Location = new System.Drawing.Point(12, 283);
            this.gunabtnProgramarReunion.Name = "gunabtnProgramarReunion";
            this.gunabtnProgramarReunion.Size = new System.Drawing.Size(180, 45);
            this.gunabtnProgramarReunion.TabIndex = 1;
            this.gunabtnProgramarReunion.Text = "Programar Reunion";
            this.gunabtnProgramarReunion.Click += new System.EventHandler(this.gunabtnProgramarReunion_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 18;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(12, 182);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Consultar Reuniones";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // gunaDGVConsultarLider
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaDGVConsultarLider.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gunaDGVConsultarLider.ColumnHeadersHeight = 18;
            this.gunaDGVConsultarLider.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaDGVConsultarLider.DefaultCellStyle = dataGridViewCellStyle6;
            this.gunaDGVConsultarLider.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.Location = new System.Drawing.Point(239, 169);
            this.gunaDGVConsultarLider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaDGVConsultarLider.MultiSelect = false;
            this.gunaDGVConsultarLider.Name = "gunaDGVConsultarLider";
            this.gunaDGVConsultarLider.ReadOnly = true;
            this.gunaDGVConsultarLider.RowHeadersVisible = false;
            this.gunaDGVConsultarLider.RowHeadersWidth = 51;
            this.gunaDGVConsultarLider.RowTemplate.Height = 24;
            this.gunaDGVConsultarLider.Size = new System.Drawing.Size(552, 173);
            this.gunaDGVConsultarLider.TabIndex = 4;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaDGVConsultarLider.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaDGVConsultarLider.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gunaDGVConsultarLider.ThemeStyle.HeaderStyle.Height = 18;
            this.gunaDGVConsultarLider.ThemeStyle.ReadOnly = true;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.Height = 24;
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gunaDGVConsultarLider.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2btnModificarReunion
            // 
            this.guna2btnModificarReunion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnModificarReunion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2btnModificarReunion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2btnModificarReunion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2btnModificarReunion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2btnModificarReunion.ForeColor = System.Drawing.Color.White;
            this.guna2btnModificarReunion.Location = new System.Drawing.Point(451, 358);
            this.guna2btnModificarReunion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.guna2btnModificarReunion.Name = "guna2btnModificarReunion";
            this.guna2btnModificarReunion.Size = new System.Drawing.Size(135, 37);
            this.guna2btnModificarReunion.TabIndex = 5;
            this.guna2btnModificarReunion.Text = "Modificar reunión";
            this.guna2btnModificarReunion.Click += new System.EventHandler(this.guna2btnModificarReunion_Click);
            // 
            // Lider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.guna2btnModificarReunion);
            this.Controls.Add(this.gunaDGVConsultarLider);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "Lider";
            this.Text = "Lider";
            this.Load += new System.EventHandler(this.Lider_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDGVConsultarLider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button gunabtnProgramarReunion;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRolUsuario;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNombreUsuario;
        private System.Windows.Forms.Button btnsalir;
        private Guna.UI2.WinForms.Guna2DataGridView gunaDGVConsultarLider;
        private Guna.UI2.WinForms.Guna2Button guna2btnModificarReunion;
    }
}