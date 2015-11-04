namespace FnScriptTesting
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtCompileInput = new System.Windows.Forms.TextBox();
            this.txtCompileOutput = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExecutionResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnRawExecute = new System.Windows.Forms.Button();
            this.TxtRawResult = new System.Windows.Forms.TextBox();
            this.txtTemplateResult = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1026, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Compile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // txtCompileInput
            // 
            this.txtCompileInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompileInput.Location = new System.Drawing.Point(12, 41);
            this.txtCompileInput.Name = "txtCompileInput";
            this.txtCompileInput.Size = new System.Drawing.Size(1026, 20);
            this.txtCompileInput.TabIndex = 4;
            this.txtCompileInput.Text = "Round(Pi * (Abs(Pow(-3.0, 2.0)) + Sqrt(6027)))";
            // 
            // txtCompileOutput
            // 
            this.txtCompileOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompileOutput.Location = new System.Drawing.Point(12, 95);
            this.txtCompileOutput.Name = "txtCompileOutput";
            this.txtCompileOutput.Size = new System.Drawing.Size(1026, 20);
            this.txtCompileOutput.TabIndex = 5;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(12, 140);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(1026, 23);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Compiled Expression";
            // 
            // txtExecutionResult
            // 
            this.txtExecutionResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExecutionResult.Location = new System.Drawing.Point(12, 196);
            this.txtExecutionResult.Name = "txtExecutionResult";
            this.txtExecutionResult.Size = new System.Drawing.Size(1026, 20);
            this.txtExecutionResult.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Execution Result";
            // 
            // BtnRawExecute
            // 
            this.BtnRawExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRawExecute.Location = new System.Drawing.Point(12, 434);
            this.BtnRawExecute.Name = "BtnRawExecute";
            this.BtnRawExecute.Size = new System.Drawing.Size(1026, 23);
            this.BtnRawExecute.TabIndex = 10;
            this.BtnRawExecute.Text = "Execute in C# Bytecode";
            this.BtnRawExecute.UseVisualStyleBackColor = true;
            this.BtnRawExecute.Click += new System.EventHandler(this.BtnRawExecute_Click);
            // 
            // TxtRawResult
            // 
            this.TxtRawResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtRawResult.Location = new System.Drawing.Point(12, 463);
            this.TxtRawResult.Name = "TxtRawResult";
            this.TxtRawResult.Size = new System.Drawing.Size(1026, 20);
            this.TxtRawResult.TabIndex = 11;
            // 
            // txtTemplateResult
            // 
            this.txtTemplateResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateResult.Location = new System.Drawing.Point(12, 379);
            this.txtTemplateResult.Name = "txtTemplateResult";
            this.txtTemplateResult.Size = new System.Drawing.Size(1026, 20);
            this.txtTemplateResult.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(12, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(1026, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Execute Static Template";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 492);
            this.Controls.Add(this.txtTemplateResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtRawResult);
            this.Controls.Add(this.BtnRawExecute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExecutionResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtCompileOutput);
            this.Controls.Add(this.txtCompileInput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCompileInput;
        private System.Windows.Forms.TextBox txtCompileOutput;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExecutionResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnRawExecute;
        private System.Windows.Forms.TextBox TxtRawResult;
        private System.Windows.Forms.TextBox txtTemplateResult;
        private System.Windows.Forms.Button button2;
    }
}

