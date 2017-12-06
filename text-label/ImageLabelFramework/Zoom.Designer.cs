namespace ImageLabelFramework
{
    partial class Zoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zoom));
            this.Zoompicbox = new System.Windows.Forms.PictureBox();
            this.enterstring = new System.Windows.Forms.MaskedTextBox();
            this.confirmstring = new System.Windows.Forms.Button();
            this.poslab = new System.Windows.Forms.Label();
            this.poslabel = new System.Windows.Forms.Label();
            this.numlabel = new System.Windows.Forms.Label();
            this.dotlab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Zoompicbox)).BeginInit();
            this.SuspendLayout();
            // 
            // Zoompicbox
            // 
            this.Zoompicbox.Location = new System.Drawing.Point(5, 5);
            this.Zoompicbox.Name = "Zoompicbox";
            this.Zoompicbox.Size = new System.Drawing.Size(800, 600);
            this.Zoompicbox.TabIndex = 0;
            this.Zoompicbox.TabStop = false;
            // 
            // enterstring
            // 
            this.enterstring.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enterstring.Location = new System.Drawing.Point(814, 40);
            this.enterstring.Name = "enterstring";
            this.enterstring.Size = new System.Drawing.Size(445, 26);
            this.enterstring.TabIndex = 1;
            this.enterstring.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // confirmstring
            // 
            this.confirmstring.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmstring.Location = new System.Drawing.Point(814, 94);
            this.confirmstring.Name = "confirmstring";
            this.confirmstring.Size = new System.Drawing.Size(116, 28);
            this.confirmstring.TabIndex = 2;
            this.confirmstring.Text = "Confirm(&C)";
            this.confirmstring.UseVisualStyleBackColor = true;
            this.confirmstring.Click += new System.EventHandler(this.confirmstring_Click);
            // 
            // poslab
            // 
            this.poslab.AutoSize = true;
            this.poslab.Location = new System.Drawing.Point(1000, 192);
            this.poslab.Name = "poslab";
            this.poslab.Size = new System.Drawing.Size(0, 12);
            this.poslab.TabIndex = 3;
            // 
            // poslabel
            // 
            this.poslabel.AutoSize = true;
            this.poslabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.poslabel.Location = new System.Drawing.Point(813, 217);
            this.poslabel.Name = "poslabel";
            this.poslabel.Size = new System.Drawing.Size(71, 12);
            this.poslabel.TabIndex = 4;
            this.poslabel.Text = "           ";
            // 
            // numlabel
            // 
            this.numlabel.AutoSize = true;
            this.numlabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.numlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numlabel.Location = new System.Drawing.Point(813, 252);
            this.numlabel.Name = "numlabel";
            this.numlabel.Size = new System.Drawing.Size(53, 12);
            this.numlabel.TabIndex = 5;
            this.numlabel.Text = "        ";
            // 
            // dotlab
            // 
            this.dotlab.AutoSize = true;
            this.dotlab.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.dotlab.Location = new System.Drawing.Point(813, 303);
            this.dotlab.Name = "dotlab";
            this.dotlab.Size = new System.Drawing.Size(167, 12);
            this.dotlab.TabIndex = 6;
            this.dotlab.Text = "无字符                     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F);
            this.label1.Location = new System.Drawing.Point(811, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "在此输入文字：";
            // 
            // Zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 612);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dotlab);
            this.Controls.Add(this.numlabel);
            this.Controls.Add(this.poslabel);
            this.Controls.Add(this.poslab);
            this.Controls.Add(this.confirmstring);
            this.Controls.Add(this.enterstring);
            this.Controls.Add(this.Zoompicbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Zoom";
            this.Text = "ZOOM";
            this.Load += new System.EventHandler(this.Zoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Zoompicbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox enterstring;
        private System.Windows.Forms.Button confirmstring;
        public System.Windows.Forms.PictureBox Zoompicbox;
        private System.Windows.Forms.Label poslab;
        private System.Windows.Forms.Label poslabel;
        private System.Windows.Forms.Label numlabel;
        private System.Windows.Forms.Label dotlab;
        private System.Windows.Forms.Label label1;
    }
}