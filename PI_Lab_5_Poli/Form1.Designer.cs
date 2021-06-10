
namespace PI_Lab_5_Poli
{
    partial class Form1
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

            this.button1 = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.pictureBox1 = new System.Windows.Forms.PictureBox();

            this.label1 = new System.Windows.Forms.Label();

            this.label2 = new System.Windows.Forms.Label();

            this.label3 = new System.Windows.Forms.Label();

            this.label4 = new System.Windows.Forms.Label();

            this.label5 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();

            this.SuspendLayout();

            //

            // button1

            //

            this.button1.Location = new System.Drawing.Point(126, 247);

            this.button1.Name = "button1";

            this.button1.Size = new System.Drawing.Size(75, 41);

            this.button1.TabIndex = 0;

            this.button1.Text = "Построить диаграмму";

            this.button1.UseVisualStyleBackColor = true;

            this.button1.Click += new System.EventHandler(this.button1_Click);

            //

            // dataGridView1

            //

            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dataGridView1.Location = new System.Drawing.Point(40, 150);

            this.dataGridView1.Name = "dataGridView1";

            this.dataGridView1.Size = new System.Drawing.Size(245, 91);

            this.dataGridView1.TabIndex = 1;

            //

            // pictureBox1

            //

            this.pictureBox1.Location = new System.Drawing.Point(323, 12);

            this.pictureBox1.Name = "pictureBox1";

            this.pictureBox1.Size = new System.Drawing.Size(350, 350);

            this.pictureBox1.TabIndex = 2;

            this.pictureBox1.TabStop = false;

            //

            // label1

            //

            this.label1.AutoSize = true;

            this.label1.BackColor = System.Drawing.Color.SeaShell;

            this.label1.Location = new System.Drawing.Point(493, 53);

            this.label1.Name = "label1";

            this.label1.Size = new System.Drawing.Size(13, 13);

            this.label1.TabIndex = 3;

            this.label1.Text = "0";

            //

            // label2

            //

            this.label2.AutoSize = true;

            this.label2.BackColor = System.Drawing.Color.SeaShell;

            this.label2.Location = new System.Drawing.Point(493, 176);

            this.label2.Name = "label2";

            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.label2.Size = new System.Drawing.Size(13, 13);

            this.label2.TabIndex = 4;

            this.label2.Text = "0";

            //

            // label3

            //

            this.label3.AutoSize = true;

            this.label3.BackColor = System.Drawing.Color.SeaShell;

            this.label3.Location = new System.Drawing.Point(493, 298);

            this.label3.Name = "label3";

            this.label3.Size = new System.Drawing.Size(13, 13);

            this.label3.TabIndex = 5;

            this.label3.Text = "0";

            //

            // label4

            //

            this.label4.AutoSize = true;

            this.label4.Location = new System.Drawing.Point(123, 53);

            this.label4.Name = "label4";

            this.label4.Size = new System.Drawing.Size(78, 13);

            this.label4.TabIndex = 6;

            this.label4.Text = "Общая сумма";

            //

            // label5

            //

            this.label5.AutoSize = true;

            this.label5.BackColor = System.Drawing.SystemColors.Control;

            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;

            this.label5.Location = new System.Drawing.Point(147, 81);

            this.label5.Name = "label5";

            this.label5.Size = new System.Drawing.Size(13, 13);

            this.label5.TabIndex = 7;

            this.label5.Text = "0";

            //

            // Form1

            //

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(685, 372);

            this.Controls.Add(this.label5);

            this.Controls.Add(this.label4);

            this.Controls.Add(this.label3);

            this.Controls.Add(this.label2);

            this.Controls.Add(this.label1);

            this.Controls.Add(this.pictureBox1);

            this.Controls.Add(this.dataGridView1);

            this.Controls.Add(this.button1);

            this.Name = "Form1";

            this.Text = "Линейчатая диаграмма";

            this.Load += new System.EventHandler(this.Form1_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label5;

    }
}


