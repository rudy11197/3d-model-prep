namespace Engine
{
    partial class OptionsForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericMove = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericTurn = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textGridScale = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(457, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 51;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(376, 227);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 50;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Movement Speed:";
            // 
            // numericMove
            // 
            this.numericMove.DecimalPlaces = 1;
            this.numericMove.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMove.Location = new System.Drawing.Point(144, 24);
            this.numericMove.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMove.Name = "numericMove";
            this.numericMove.Size = new System.Drawing.Size(120, 20);
            this.numericMove.TabIndex = 0;
            this.numericMove.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Turn Speed:";
            // 
            // numericTurn
            // 
            this.numericTurn.DecimalPlaces = 1;
            this.numericTurn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTurn.Location = new System.Drawing.Point(144, 56);
            this.numericTurn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTurn.Name = "numericTurn";
            this.numericTurn.Size = new System.Drawing.Size(120, 20);
            this.numericTurn.TabIndex = 1;
            this.numericTurn.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Grid square width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Unit(s).  Calculated when the model is loaded";
            // 
            // textGridScale
            // 
            this.textGridScale.Location = new System.Drawing.Point(144, 91);
            this.textGridScale.Name = "textGridScale";
            this.textGridScale.ReadOnly = true;
            this.textGridScale.Size = new System.Drawing.Size(100, 20);
            this.textGridScale.TabIndex = 2;
            this.textGridScale.TabStop = false;
            this.textGridScale.Text = "1";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 262);
            this.Controls.Add(this.textGridScale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericTurn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericMove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Name = "OptionsForm";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.numericMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTurn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericMove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericTurn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textGridScale;
    }
}