namespace AudioAppController
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
            this.btnMuteAll = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.cbListAudioProcesses = new System.Windows.Forms.ComboBox();
            this.audioProcessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnReload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.audioProcessBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMuteAll
            // 
            this.btnMuteAll.Location = new System.Drawing.Point(310, 73);
            this.btnMuteAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMuteAll.Name = "btnMuteAll";
            this.btnMuteAll.Size = new System.Drawing.Size(117, 46);
            this.btnMuteAll.TabIndex = 1;
            this.btnMuteAll.Text = "Mute All";
            this.btnMuteAll.UseVisualStyleBackColor = true;
            this.btnMuteAll.Click += new System.EventHandler(this.btnMuteAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(433, 74);
            this.btnAddAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(117, 46);
            this.btnAddAll.TabIndex = 2;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // cbListAudioProcesses
            // 
            this.cbListAudioProcesses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbListAudioProcesses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbListAudioProcesses.DataSource = this.audioProcessBindingSource;
            this.cbListAudioProcesses.DisplayMember = "ProcessName";
            this.cbListAudioProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListAudioProcesses.FormattingEnabled = true;
            this.cbListAudioProcesses.Location = new System.Drawing.Point(123, 12);
            this.cbListAudioProcesses.Name = "cbListAudioProcesses";
            this.cbListAudioProcesses.Size = new System.Drawing.Size(495, 37);
            this.cbListAudioProcesses.TabIndex = 3;
            this.cbListAudioProcesses.SelectedIndexChanged += new System.EventHandler(this.cbListAudioProcesses_SelectedIndexChanged);
            // 
            // audioProcessBindingSource
            // 
            this.audioProcessBindingSource.DataSource = typeof(AudioAppController.Model.AudioProcess);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(624, 10);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(114, 46);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Processes:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1282, 636);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.cbListAudioProcesses);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnMuteAll);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "AudioAppControl";
            ((System.ComponentModel.ISupportInitialize)(this.audioProcessBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMuteAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.BindingSource audioProcessBindingSource;
        private System.Windows.Forms.ComboBox cbListAudioProcesses;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label2;
    }
}

