
namespace quantas_xicaras_cps
{
    partial class formPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblCabecalho = new System.Windows.Forms.Label();
            this.timerSerial = new System.Windows.Forms.Timer(this.components);
            this.btnHandleConnection = new System.Windows.Forms.Button();
            this.lblStatusSerial = new System.Windows.Forms.Label();
            this.cbSerialComs = new System.Windows.Forms.ComboBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.btnCooelrOn = new System.Windows.Forms.Button();
            this.btnCoolerOff = new System.Windows.Forms.Button();
            this.lblCooler = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::quantas_xicaras_cps.Properties.Resources.pacote;
            this.pbLogo.Location = new System.Drawing.Point(14, 16);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(104, 133);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // lblCabecalho
            // 
            this.lblCabecalho.AutoSize = true;
            this.lblCabecalho.Font = new System.Drawing.Font("Lato", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCabecalho.Location = new System.Drawing.Point(125, 16);
            this.lblCabecalho.Name = "lblCabecalho";
            this.lblCabecalho.Size = new System.Drawing.Size(375, 36);
            this.lblCabecalho.TabIndex = 1;
            this.lblCabecalho.Text = "Quantas Xícaras? [Estoque]";
            // 
            // timerSerial
            // 
            this.timerSerial.Interval = 2000;
            this.timerSerial.Tick += new System.EventHandler(this.timerSerial_Tick);
            // 
            // btnHandleConnection
            // 
            this.btnHandleConnection.Location = new System.Drawing.Point(352, 73);
            this.btnHandleConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHandleConnection.Name = "btnHandleConnection";
            this.btnHandleConnection.Size = new System.Drawing.Size(133, 31);
            this.btnHandleConnection.TabIndex = 2;
            this.btnHandleConnection.Text = "Conectar";
            this.btnHandleConnection.UseVisualStyleBackColor = true;
            this.btnHandleConnection.Click += new System.EventHandler(this.btnHandleConnection_Click);
            // 
            // lblStatusSerial
            // 
            this.lblStatusSerial.AutoSize = true;
            this.lblStatusSerial.ForeColor = System.Drawing.Color.Red;
            this.lblStatusSerial.Location = new System.Drawing.Point(491, 78);
            this.lblStatusSerial.Name = "lblStatusSerial";
            this.lblStatusSerial.Size = new System.Drawing.Size(97, 20);
            this.lblStatusSerial.TabIndex = 3;
            this.lblStatusSerial.Text = "Desconetado";
            // 
            // cbSerialComs
            // 
            this.cbSerialComs.FormattingEnabled = true;
            this.cbSerialComs.Location = new System.Drawing.Point(142, 73);
            this.cbSerialComs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSerialComs.Name = "cbSerialComs";
            this.cbSerialComs.Size = new System.Drawing.Size(193, 28);
            this.cbSerialComs.TabIndex = 4;
            this.cbSerialComs.Text = "Selecione a Porta COM";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(142, 129);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(96, 20);
            this.lblTemp.TabIndex = 5;
            this.lblTemp.Text = "Temperatura:";
            // 
            // btnCooelrOn
            // 
            this.btnCooelrOn.Location = new System.Drawing.Point(455, 125);
            this.btnCooelrOn.Name = "btnCooelrOn";
            this.btnCooelrOn.Size = new System.Drawing.Size(94, 29);
            this.btnCooelrOn.TabIndex = 6;
            this.btnCooelrOn.Text = "ON";
            this.btnCooelrOn.UseVisualStyleBackColor = true;
            this.btnCooelrOn.Click += new System.EventHandler(this.btnCoolerOn_Click);
            // 
            // btnCoolerOff
            // 
            this.btnCoolerOff.Location = new System.Drawing.Point(555, 125);
            this.btnCoolerOff.Name = "btnCoolerOff";
            this.btnCoolerOff.Size = new System.Drawing.Size(94, 29);
            this.btnCoolerOff.TabIndex = 7;
            this.btnCoolerOff.Text = "OFF";
            this.btnCoolerOff.UseVisualStyleBackColor = true;
            this.btnCoolerOff.Click += new System.EventHandler(this.btnCoolerOff_Click);
            // 
            // lblCooler
            // 
            this.lblCooler.AutoSize = true;
            this.lblCooler.Location = new System.Drawing.Point(352, 129);
            this.lblCooler.Name = "lblCooler";
            this.lblCooler.Size = new System.Drawing.Size(97, 20);
            this.lblCooler.TabIndex = 8;
            this.lblCooler.Text = "Refrigeração:";
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 189);
            this.Controls.Add(this.lblCooler);
            this.Controls.Add(this.btnCoolerOff);
            this.Controls.Add(this.btnCooelrOn);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.cbSerialComs);
            this.Controls.Add(this.lblStatusSerial);
            this.Controls.Add(this.btnHandleConnection);
            this.Controls.Add(this.lblCabecalho);
            this.Controls.Add(this.pbLogo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblCabecalho;
        private System.Windows.Forms.Timer timerSerial;
        private System.Windows.Forms.Button btnHandleConnection;
        private System.Windows.Forms.Label lblStatusSerial;
        private System.Windows.Forms.ComboBox cbSerialComs;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Button btnCooelrOn;
        private System.Windows.Forms.Button btnCoolerOff;
        private System.Windows.Forms.Label lblCooler;
    }
}

