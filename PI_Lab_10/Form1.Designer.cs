
namespace PI_Lab_10
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
            this.after_Min1 = new PI_Lab_10.After_Min();
            this.redact_ToolTip1 = new PI_Lab_10.Redact_ToolTip();
            this.SuspendLayout();
            // 
            // after_Min1
            // 
            this.after_Min1.Location = new System.Drawing.Point(12, 12);
            this.after_Min1.Name = "after_Min1";
            this.after_Min1.Size = new System.Drawing.Size(162, 99);
            this.after_Min1.TabIndex = 3;
            // 
            // redact_ToolTip1
            // 
            this.redact_ToolTip1.Location = new System.Drawing.Point(180, 12);
            this.redact_ToolTip1.Name = "redact_ToolTip1";
            this.redact_ToolTip1.Size = new System.Drawing.Size(179, 177);
            this.redact_ToolTip1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 184);
            this.Controls.Add(this.redact_ToolTip1);
            this.Controls.Add(this.after_Min1);
            this.Name = "Form1";
            this.Text = "Лабораторная работа 10";
            this.ResumeLayout(false);

        }

        #endregion
        private After_Min after_Min1;
        private Redact_ToolTip redact_ToolTip1;
    }
}

