using System.Windows.Forms;

namespace ImageLabelFramework
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgChooseDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.bottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.Click0Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.Click1Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.Click2Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.avalabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bottomToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.remove = new System.Windows.Forms.Button();
            this.edittext = new System.Windows.Forms.Button();
            this.deletetext = new System.Windows.Forms.Button();
            this.Confirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.avaitext = new System.Windows.Forms.ComboBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.redrawButton = new System.Windows.Forms.Button();
            this.preButton = new System.Windows.Forms.Button();
            this.sealButton = new System.Windows.Forms.Button();
            this.availableButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.bottomStatusStrip.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(839, 25);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            this.mainMenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainMenuStrip_Move);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.menuToolStripMenuItem.Text = "Load(&L)";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenu
            // 
            this.exitToolStripMenu.Name = "exitToolStripMenu";
            this.exitToolStripMenu.Size = new System.Drawing.Size(40, 21);
            this.exitToolStripMenu.Text = "Exit";
            this.exitToolStripMenu.Click += new System.EventHandler(this.exitToolStripMenu_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Enabled = false;
            this.mainPictureBox.Location = new System.Drawing.Point(12, 28);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(640, 640);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_Click);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_Move);
            // 
            // bottomStatusStrip
            // 
            this.bottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Click0Label,
            this.Click1Label,
            this.Click2Label,
            this.avalabel,
            this.bottomToolStripStatusLabel});
            this.bottomStatusStrip.Location = new System.Drawing.Point(0, 679);
            this.bottomStatusStrip.Name = "bottomStatusStrip";
            this.bottomStatusStrip.Size = new System.Drawing.Size(839, 22);
            this.bottomStatusStrip.TabIndex = 2;
            // 
            // Click0Label
            // 
            this.Click0Label.AutoSize = false;
            this.Click0Label.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Click0Label.Enabled = false;
            this.Click0Label.Name = "Click0Label";
            this.Click0Label.Size = new System.Drawing.Size(140, 17);
            // 
            // Click1Label
            // 
            this.Click1Label.AutoSize = false;
            this.Click1Label.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Click1Label.Enabled = false;
            this.Click1Label.Name = "Click1Label";
            this.Click1Label.Size = new System.Drawing.Size(70, 17);
            // 
            // Click2Label
            // 
            this.Click2Label.AutoSize = false;
            this.Click2Label.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Click2Label.Enabled = false;
            this.Click2Label.Name = "Click2Label";
            this.Click2Label.Size = new System.Drawing.Size(70, 17);
            // 
            // avalabel
            // 
            this.avalabel.AutoSize = false;
            this.avalabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.avalabel.Enabled = false;
            this.avalabel.Name = "avalabel";
            this.avalabel.Size = new System.Drawing.Size(140, 17);
            // 
            // bottomToolStripStatusLabel
            // 
            this.bottomToolStripStatusLabel.Name = "bottomToolStripStatusLabel";
            this.bottomToolStripStatusLabel.Size = new System.Drawing.Size(12, 17);
            this.bottomToolStripStatusLabel.Text = " ";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.remove);
            this.buttonPanel.Controls.Add(this.edittext);
            this.buttonPanel.Controls.Add(this.deletetext);
            this.buttonPanel.Controls.Add(this.Confirm);
            this.buttonPanel.Controls.Add(this.label1);
            this.buttonPanel.Controls.Add(this.avaitext);
            this.buttonPanel.Controls.Add(this.nextButton);
            this.buttonPanel.Controls.Add(this.redrawButton);
            this.buttonPanel.Controls.Add(this.preButton);
            this.buttonPanel.Controls.Add(this.sealButton);
            this.buttonPanel.Controls.Add(this.availableButton);
            this.buttonPanel.Controls.Add(this.undoButton);
            this.buttonPanel.Controls.Add(this.clearButton);
            this.buttonPanel.Location = new System.Drawing.Point(658, 33);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(169, 635);
            this.buttonPanel.TabIndex = 3;
            this.buttonPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonPanel_Move);
            // 
            // remove
            // 
            this.remove.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.remove.Location = new System.Drawing.Point(31, 547);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(106, 45);
            this.remove.TabIndex = 10;
            this.remove.Text = "REMOVE";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // edittext
            // 
            this.edittext.Enabled = false;
            this.edittext.Location = new System.Drawing.Point(31, 437);
            this.edittext.Name = "edittext";
            this.edittext.Size = new System.Drawing.Size(75, 23);
            this.edittext.TabIndex = 9;
            this.edittext.Text = "Edit(&E)";
            this.edittext.UseVisualStyleBackColor = true;
            this.edittext.Click += new System.EventHandler(this.edittext_Click);
            // 
            // deletetext
            // 
            this.deletetext.Enabled = false;
            this.deletetext.Location = new System.Drawing.Point(31, 397);
            this.deletetext.Name = "deletetext";
            this.deletetext.Size = new System.Drawing.Size(75, 23);
            this.deletetext.TabIndex = 8;
            this.deletetext.Text = "Delete(&D)";
            this.deletetext.UseVisualStyleBackColor = true;
            this.deletetext.Click += new System.EventHandler(this.deletetext_Click);
            // 
            // Confirm
            // 
            this.Confirm.Enabled = false;
            this.Confirm.Location = new System.Drawing.Point(31, 257);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 4;
            this.Confirm.Text = "Confirm(&Q)";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "现有文本：";
            // 
            // avaitext
            // 
            this.avaitext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.avaitext.Enabled = false;
            this.avaitext.FormattingEnabled = true;
            this.avaitext.Location = new System.Drawing.Point(29, 357);
            this.avaitext.Name = "avaitext";
            this.avaitext.Size = new System.Drawing.Size(121, 20);
            this.avaitext.TabIndex = 5;
            this.avaitext.SelectedIndexChanged += new System.EventHandler(this.avaitext_SelectedIndexChanged);
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(31, 214);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Next(&X)";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // redrawButton
            // 
            this.redrawButton.Enabled = false;
            this.redrawButton.Location = new System.Drawing.Point(31, 13);
            this.redrawButton.Name = "redrawButton";
            this.redrawButton.Size = new System.Drawing.Size(75, 23);
            this.redrawButton.TabIndex = 5;
            this.redrawButton.Text = "Redraw(&R)";
            this.redrawButton.UseVisualStyleBackColor = true;
            this.redrawButton.Click += new System.EventHandler(this.redrawButton_Click);
            // 
            // preButton
            // 
            this.preButton.Enabled = false;
            this.preButton.Location = new System.Drawing.Point(31, 185);
            this.preButton.Name = "preButton";
            this.preButton.Size = new System.Drawing.Size(75, 23);
            this.preButton.TabIndex = 1;
            this.preButton.Text = "Pre(&Z)";
            this.preButton.UseVisualStyleBackColor = true;
            this.preButton.Click += new System.EventHandler(this.preButton_Click);
            // 
            // sealButton
            // 
            this.sealButton.Enabled = false;
            this.sealButton.Location = new System.Drawing.Point(31, 42);
            this.sealButton.Name = "sealButton";
            this.sealButton.Size = new System.Drawing.Size(75, 23);
            this.sealButton.TabIndex = 6;
            this.sealButton.Text = "Seal(&S)";
            this.sealButton.UseVisualStyleBackColor = true;
            this.sealButton.Click += new System.EventHandler(this.sealButton_Click);
            // 
            // availableButton
            // 
            this.availableButton.Enabled = false;
            this.availableButton.Location = new System.Drawing.Point(31, 156);
            this.availableButton.Name = "availableButton";
            this.availableButton.Size = new System.Drawing.Size(75, 23);
            this.availableButton.TabIndex = 4;
            this.availableButton.Text = "Avai(&A)";
            this.availableButton.UseVisualStyleBackColor = true;
            this.availableButton.Click += new System.EventHandler(this.availableButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Enabled = false;
            this.undoButton.Location = new System.Drawing.Point(31, 71);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 2;
            this.undoButton.Text = "Undo(&U)";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Enabled = false;
            this.clearButton.Location = new System.Drawing.Point(31, 100);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(839, 701);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.bottomStatusStrip);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Image Labeling Toolbox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.bottomStatusStrip.ResumeLayout(false);
            this.bottomStatusStrip.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog dlgChooseDirectory;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.StatusStrip bottomStatusStrip;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button preButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button availableButton;
        private System.Windows.Forms.ToolStripStatusLabel bottomToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel Click0Label;
        private System.Windows.Forms.ToolStripStatusLabel Click1Label;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel Click2Label;
        private System.Windows.Forms.Button sealButton;
        private System.Windows.Forms.Button redrawButton;
        private System.Windows.Forms.Button Confirm;
        private ToolStripStatusLabel avalabel;
        private ToolStripMenuItem exitToolStripMenu;
        private ComboBox avaitext;
        private Label label1;
        private Button deletetext;
        private Button edittext;
        private Button remove;
    }
}

