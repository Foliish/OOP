namespace MyPaint
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panPain = new System.Windows.Forms.Panel();
            this.panMenu = new System.Windows.Forms.Panel();
            this.edLWidth = new System.Windows.Forms.NumericUpDown();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSetLColor = new System.Windows.Forms.Button();
            this.btnSetBColor = new System.Windows.Forms.Button();
            this.panIcon = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.clrDialogLine = new System.Windows.Forms.ColorDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.clrDialogBack = new System.Windows.Forms.ColorDialog();
            this.panPain.SuspendLayout();
            this.panMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panPain
            // 
            this.panPain.BackColor = System.Drawing.SystemColors.Menu;
            this.panPain.Controls.Add(this.panMenu);
            this.panPain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPain.Location = new System.Drawing.Point(0, 0);
            this.panPain.Name = "panPain";
            this.panPain.Size = new System.Drawing.Size(1355, 684);
            this.panPain.TabIndex = 0;
            this.panPain.Paint += new System.Windows.Forms.PaintEventHandler(this.panPaint_Paint);
            this.panPain.DoubleClick += new System.EventHandler(this.panPain_DoubleClick);
            this.panPain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panPain_MouseDown);
            this.panPain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panPain_MouseMove);
            // 
            // panMenu
            // 
            this.panMenu.Controls.Add(this.edLWidth);
            this.panMenu.Controls.Add(this.btnLoad);
            this.panMenu.Controls.Add(this.btnSave);
            this.panMenu.Controls.Add(this.btnSetLColor);
            this.panMenu.Controls.Add(this.btnSetBColor);
            this.panMenu.Controls.Add(this.panIcon);
            this.panMenu.Controls.Add(this.label1);
            this.panMenu.Location = new System.Drawing.Point(0, 0);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(479, 79);
            this.panMenu.TabIndex = 0;
            // 
            // edLWidth
            // 
            this.edLWidth.Location = new System.Drawing.Point(203, 5);
            this.edLWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.edLWidth.Name = "edLWidth";
            this.edLWidth.ReadOnly = true;
            this.edLWidth.Size = new System.Drawing.Size(49, 22);
            this.edLWidth.TabIndex = 6;
            this.edLWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edLWidth.Click += new System.EventHandler(this.edLWidth_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(367, 33);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(98, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Открыть";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(367, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSetLColor
            // 
            this.btnSetLColor.Location = new System.Drawing.Point(90, 33);
            this.btnSetLColor.Name = "btnSetLColor";
            this.btnSetLColor.Size = new System.Drawing.Size(92, 23);
            this.btnSetLColor.TabIndex = 3;
            this.btnSetLColor.Text = "Цвет линии";
            this.btnSetLColor.UseVisualStyleBackColor = true;
            this.btnSetLColor.Click += new System.EventHandler(this.btnSetLColor_Click);
            // 
            // btnSetBColor
            // 
            this.btnSetBColor.Location = new System.Drawing.Point(90, 4);
            this.btnSetBColor.Name = "btnSetBColor";
            this.btnSetBColor.Size = new System.Drawing.Size(92, 23);
            this.btnSetBColor.TabIndex = 2;
            this.btnSetBColor.Text = "Цвет фона";
            this.btnSetBColor.UseVisualStyleBackColor = true;
            this.btnSetBColor.Click += new System.EventHandler(this.btnSetBColor_Click);
            // 
            // panIcon
            // 
            this.panIcon.Location = new System.Drawing.Point(4, 4);
            this.panIcon.Name = "panIcon";
            this.panIcon.Size = new System.Drawing.Size(70, 70);
            this.panIcon.TabIndex = 1;
            this.panIcon.Click += new System.EventHandler(this.panIcon_Click);
            this.panIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.panIcon_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 0;
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            // 
            // clrDialogBack
            // 
            this.clrDialogBack.Color = System.Drawing.Color.Yellow;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1355, 684);
            this.Controls.Add(this.panPain);
            this.Name = "Form";
            this.Text = "Рисоватор3000";
            this.panPain.ResumeLayout(false);
            this.panMenu.ResumeLayout(false);
            this.panMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edLWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panPain;
        private System.Windows.Forms.Panel panMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSetLColor;
        private System.Windows.Forms.Button btnSetBColor;
        private System.Windows.Forms.Panel panIcon;
        private System.Windows.Forms.ColorDialog clrDialogLine;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.NumericUpDown edLWidth;
        private System.Windows.Forms.ColorDialog clrDialogBack;
    }
}

