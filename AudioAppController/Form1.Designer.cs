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
            this.flowLayoutSoundPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMuteAll = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.cbListAudioProcesses = new System.Windows.Forms.ComboBox();
            this.audioProcessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnReload = new System.Windows.Forms.Button();
            this.btnMediaPlayPause = new System.Windows.Forms.Button();
            this.txtMediaNextTrack = new System.Windows.Forms.TextBox();
            this.btnMediaNextTrack = new System.Windows.Forms.Button();
            this.btnPreviousTrack = new System.Windows.Forms.Button();
            this.txtMediaPreviousTrack = new System.Windows.Forms.TextBox();
            this.txtMediaPlayPause = new System.Windows.Forms.TextBox();
            this.btnMediaStop = new System.Windows.Forms.Button();
            this.txtMediaStop = new System.Windows.Forms.TextBox();
            this.txtMuteAudio = new System.Windows.Forms.TextBox();
            this.btnMuteAudio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.audioProcessBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutSoundPanel
            // 
            this.flowLayoutSoundPanel.AutoScroll = true;
            this.flowLayoutSoundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutSoundPanel.Location = new System.Drawing.Point(12, 123);
            this.flowLayoutSoundPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutSoundPanel.Name = "flowLayoutSoundPanel";
            this.flowLayoutSoundPanel.Size = new System.Drawing.Size(1145, 501);
            this.flowLayoutSoundPanel.TabIndex = 0;
            // 
            // btnMuteAll
            // 
            this.btnMuteAll.Location = new System.Drawing.Point(454, 73);
            this.btnMuteAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMuteAll.Name = "btnMuteAll";
            this.btnMuteAll.Size = new System.Drawing.Size(117, 46);
            this.btnMuteAll.TabIndex = 1;
            this.btnMuteAll.Text = "Mute All";
            this.btnMuteAll.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(577, 73);
            this.btnAddAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(117, 46);
            this.btnAddAll.TabIndex = 2;
            this.btnAddAll.Text = "Add All";
            this.btnAddAll.UseVisualStyleBackColor = true;
            // 
            // cbListAudioProcesses
            // 
            this.cbListAudioProcesses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbListAudioProcesses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbListAudioProcesses.DataSource = this.audioProcessBindingSource;
            this.cbListAudioProcesses.DisplayMember = "ProcessName";
            this.cbListAudioProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListAudioProcesses.FormattingEnabled = true;
            this.cbListAudioProcesses.Location = new System.Drawing.Point(310, 12);
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
            this.btnReload.Location = new System.Drawing.Point(811, 8);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(114, 46);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnMediaPlayPause
            // 
            this.btnMediaPlayPause.BackColor = System.Drawing.Color.Green;
            this.btnMediaPlayPause.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMediaPlayPause.Location = new System.Drawing.Point(1168, 221);
            this.btnMediaPlayPause.Name = "btnMediaPlayPause";
            this.btnMediaPlayPause.Size = new System.Drawing.Size(117, 46);
            this.btnMediaPlayPause.TabIndex = 7;
            this.btnMediaPlayPause.Text = "Media Play Pause";
            this.btnMediaPlayPause.UseVisualStyleBackColor = false;
            this.btnMediaPlayPause.Click += new System.EventHandler(this.btnMediaPlayPause_Click);
            // 
            // txtMediaNextTrack
            // 
            this.txtMediaNextTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediaNextTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaNextTrack.Location = new System.Drawing.Point(1291, 132);
            this.txtMediaNextTrack.Name = "txtMediaNextTrack";
            this.txtMediaNextTrack.ReadOnly = true;
            this.txtMediaNextTrack.Size = new System.Drawing.Size(210, 27);
            this.txtMediaNextTrack.TabIndex = 8;
            this.txtMediaNextTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMediaNextTrack.Click += new System.EventHandler(this.txtMediaNextTrack_Click);
            // 
            // btnMediaNextTrack
            // 
            this.btnMediaNextTrack.BackColor = System.Drawing.Color.Green;
            this.btnMediaNextTrack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMediaNextTrack.Location = new System.Drawing.Point(1168, 122);
            this.btnMediaNextTrack.Name = "btnMediaNextTrack";
            this.btnMediaNextTrack.Size = new System.Drawing.Size(117, 46);
            this.btnMediaNextTrack.TabIndex = 9;
            this.btnMediaNextTrack.Text = "Media Next Track";
            this.btnMediaNextTrack.UseVisualStyleBackColor = false;
            this.btnMediaNextTrack.Click += new System.EventHandler(this.btnMediaNextTrack_Click);
            // 
            // btnPreviousTrack
            // 
            this.btnPreviousTrack.BackColor = System.Drawing.Color.Green;
            this.btnPreviousTrack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPreviousTrack.Location = new System.Drawing.Point(1168, 171);
            this.btnPreviousTrack.Name = "btnPreviousTrack";
            this.btnPreviousTrack.Size = new System.Drawing.Size(117, 46);
            this.btnPreviousTrack.TabIndex = 10;
            this.btnPreviousTrack.Text = "Media Previous Track";
            this.btnPreviousTrack.UseVisualStyleBackColor = false;
            this.btnPreviousTrack.Click += new System.EventHandler(this.btnPreviousTrack_Click);
            // 
            // txtMediaPreviousTrack
            // 
            this.txtMediaPreviousTrack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediaPreviousTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaPreviousTrack.Location = new System.Drawing.Point(1291, 181);
            this.txtMediaPreviousTrack.Name = "txtMediaPreviousTrack";
            this.txtMediaPreviousTrack.ReadOnly = true;
            this.txtMediaPreviousTrack.Size = new System.Drawing.Size(210, 27);
            this.txtMediaPreviousTrack.TabIndex = 14;
            this.txtMediaPreviousTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMediaPreviousTrack.Click += new System.EventHandler(this.txtMediaPreviousTrack_Click);
            // 
            // txtMediaPlayPause
            // 
            this.txtMediaPlayPause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediaPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaPlayPause.Location = new System.Drawing.Point(1291, 231);
            this.txtMediaPlayPause.Name = "txtMediaPlayPause";
            this.txtMediaPlayPause.ReadOnly = true;
            this.txtMediaPlayPause.Size = new System.Drawing.Size(210, 27);
            this.txtMediaPlayPause.TabIndex = 13;
            this.txtMediaPlayPause.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMediaPlayPause.Click += new System.EventHandler(this.txtMediaPlayPause_Click);
            // 
            // btnMediaStop
            // 
            this.btnMediaStop.BackColor = System.Drawing.Color.Green;
            this.btnMediaStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMediaStop.Location = new System.Drawing.Point(1168, 270);
            this.btnMediaStop.Name = "btnMediaStop";
            this.btnMediaStop.Size = new System.Drawing.Size(117, 46);
            this.btnMediaStop.TabIndex = 15;
            this.btnMediaStop.Text = "Media Stop";
            this.btnMediaStop.UseVisualStyleBackColor = false;
            this.btnMediaStop.Click += new System.EventHandler(this.btnMediaStop_Click);
            // 
            // txtMediaStop
            // 
            this.txtMediaStop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediaStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaStop.Location = new System.Drawing.Point(1291, 280);
            this.txtMediaStop.Name = "txtMediaStop";
            this.txtMediaStop.ReadOnly = true;
            this.txtMediaStop.Size = new System.Drawing.Size(210, 27);
            this.txtMediaStop.TabIndex = 16;
            this.txtMediaStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMediaStop.Click += new System.EventHandler(this.txtMediaStop_Click);
            // 
            // txtMuteAudio
            // 
            this.txtMuteAudio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMuteAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMuteAudio.Location = new System.Drawing.Point(1291, 332);
            this.txtMuteAudio.Name = "txtMuteAudio";
            this.txtMuteAudio.ReadOnly = true;
            this.txtMuteAudio.Size = new System.Drawing.Size(210, 27);
            this.txtMuteAudio.TabIndex = 18;
            this.txtMuteAudio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMuteAudio.Click += new System.EventHandler(this.txtMuteAudio_Click);
            // 
            // btnMuteAudio
            // 
            this.btnMuteAudio.BackColor = System.Drawing.Color.Green;
            this.btnMuteAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuteAudio.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMuteAudio.Location = new System.Drawing.Point(1168, 322);
            this.btnMuteAudio.Name = "btnMuteAudio";
            this.btnMuteAudio.Size = new System.Drawing.Size(117, 46);
            this.btnMuteAudio.TabIndex = 17;
            this.btnMuteAudio.Text = "Mute Volume";
            this.btnMuteAudio.UseVisualStyleBackColor = false;
            this.btnMuteAudio.Click += new System.EventHandler(this.btnMuteAudio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1361, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Binds:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 22);
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
            this.ClientSize = new System.Drawing.Size(1512, 636);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMuteAudio);
            this.Controls.Add(this.btnMuteAudio);
            this.Controls.Add(this.txtMediaStop);
            this.Controls.Add(this.btnMediaStop);
            this.Controls.Add(this.txtMediaPreviousTrack);
            this.Controls.Add(this.txtMediaPlayPause);
            this.Controls.Add(this.btnPreviousTrack);
            this.Controls.Add(this.btnMediaNextTrack);
            this.Controls.Add(this.txtMediaNextTrack);
            this.Controls.Add(this.btnMediaPlayPause);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.cbListAudioProcesses);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnMuteAll);
            this.Controls.Add(this.flowLayoutSoundPanel);
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

        private System.Windows.Forms.FlowLayoutPanel flowLayoutSoundPanel;
        private System.Windows.Forms.Button btnMuteAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.BindingSource audioProcessBindingSource;
        private System.Windows.Forms.ComboBox cbListAudioProcesses;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnMediaPlayPause;
        private System.Windows.Forms.TextBox txtMediaNextTrack;
        private System.Windows.Forms.Button btnMediaNextTrack;
        private System.Windows.Forms.Button btnPreviousTrack;
        private System.Windows.Forms.TextBox txtMediaPreviousTrack;
        private System.Windows.Forms.TextBox txtMediaPlayPause;
        private System.Windows.Forms.Button btnMediaStop;
        private System.Windows.Forms.TextBox txtMediaStop;
        private System.Windows.Forms.TextBox txtMuteAudio;
        private System.Windows.Forms.Button btnMuteAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

