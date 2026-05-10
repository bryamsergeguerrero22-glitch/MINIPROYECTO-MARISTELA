namespace ProyectoMini
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtID = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2WinProgressIndicator1 = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(501, 168);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(82, 18);
            this.guna2HtmlLabel2.TabIndex = 4;
            this.guna2HtmlLabel2.Text = "Contraseña";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(168, 147);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(57, 18);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Usuario";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.BorderRadius = 20;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(124)))));
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(124)))));
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Location = new System.Drawing.Point(461, 288);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(284, 45);
            this.guna2GradientButton1.TabIndex = 2;
            this.guna2GradientButton1.Text = "Iniciar sesion";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.Teal;
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.BorderThickness = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(178)))), ((int)(((byte)(161)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(195)))), ((int)(((byte)(180)))));
            this.txtPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPassword.IconLeft")));
            this.txtPassword.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtPassword.Location = new System.Drawing.Point(461, 215);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtPassword.PlaceholderText = "Contraseña";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(284, 43);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextOffset = new System.Drawing.Point(10, 0);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.Cornsilk;
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(137)))), ((int)(((byte)(163)))));
            this.txtID.BorderRadius = 10;
            this.txtID.BorderThickness = 2;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.DefaultText = "";
            this.txtID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtID.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(178)))), ((int)(((byte)(161)))));
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtID.ForeColor = System.Drawing.Color.DimGray;
            this.txtID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(195)))), ((int)(((byte)(180)))));
            this.txtID.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtID.IconLeft")));
            this.txtID.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtID.Location = new System.Drawing.Point(461, 145);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtID.Name = "txtID";
            this.txtID.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtID.PlaceholderText = "Usuario";
            this.txtID.SelectedText = "";
            this.txtID.Size = new System.Drawing.Size(284, 41);
            this.txtID.TabIndex = 0;
            this.txtID.TextOffset = new System.Drawing.Point(10, 0);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(758, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 55);
            this.guna2ControlBox1.TabIndex = 5;
            this.guna2ControlBox1.UseTransparentBackground = true;
            // 
            // guna2WinProgressIndicator1
            // 
            this.guna2WinProgressIndicator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2WinProgressIndicator1.Location = new System.Drawing.Point(572, 355);
            this.guna2WinProgressIndicator1.Name = "guna2WinProgressIndicator1";
            this.guna2WinProgressIndicator1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(156)))), ((int)(((byte)(124)))));
            this.guna2WinProgressIndicator1.Size = new System.Drawing.Size(60, 60);
            this.guna2WinProgressIndicator1.TabIndex = 6;
            this.guna2WinProgressIndicator1.UseTransparentBackground = true;
            this.guna2WinProgressIndicator1.Visible = false;
            this.guna2WinProgressIndicator1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 524);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 524);
            this.Controls.Add(this.guna2WinProgressIndicator1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2GradientButton1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator guna2WinProgressIndicator1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

