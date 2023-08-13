using AudioAppController.Model;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsInput;

namespace AudioAppController.View.Component
{

    public partial class AudioMediaPanel : TableLayoutPanel
    {
        private KeyBoardSimulator keyboardSimulator;
        private List<AudioProcess> mediaProcesses;
        public AudioMediaPanel(List<AudioProcess> mediaProcesses)
        {
            this.keyboardSimulator = new KeyBoardSimulator();
            this.mediaProcesses = mediaProcesses;
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.Dock = DockStyle.None;
            this.AutoSize = true;
            this.ColumnCount = 3;
            this.RowCount = 5;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.Location = new Point(664, 97);
            CreateMediaLayer("Media Next Track", VirtualKeyCode.MEDIA_NEXT_TRACK, 0);
            CreateMediaLayer("Media Previous Track", VirtualKeyCode.MEDIA_PREV_TRACK, 1);
            CreateMediaLayer("Media Play/Pause", VirtualKeyCode.MEDIA_PLAY_PAUSE,2);
            CreateMediaLayer("Media Stop", VirtualKeyCode.MEDIA_STOP,3);
            CreateMediaLayer("Mute Volume", VirtualKeyCode.VOLUME_MUTE,4);
        }

        private void OnChangeKeyCombination(object sender)
        {
            Control control = sender as Control;

            VirtualKeyCode virtualKey = (VirtualKeyCode)control.Tag;
            String keyCombination = control.Text;
            String newKeyCombination = CreateDialog.OpenKeySelectionWindow(keyCombination);

            if (newKeyCombination == null) return;

            AudioProcess process = GetProcessByVirtualKey(virtualKey);
            process.KeyCombination = newKeyCombination;
            control.Text = newKeyCombination;
        }


        private void ChangeButtonColor(object sender)
        {
            Button button = sender as Button;
            if (button == null) return;
            VirtualKeyCode virtualKey = (VirtualKeyCode) button.Tag;
            if(virtualKey == VirtualKeyCode.VOLUME_MUTE)
            {
                button.BackColor = button.BackColor.Equals(Color.Green) 
                    ? Color.Red 
                    : Color.Green;
            }
        }


        private void btnRemoveByVirtualKey_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            AudioProcess process = control.Tag as AudioProcess;
            if (process != null && process.virtualKeyCode != VirtualKeyCode.None)
            {
                process.KeyCombination = null;
            }
        }
        private AudioProcess GetProcessByVirtualKey(VirtualKeyCode virtualKey)
        {
            AudioProcess process = this.mediaProcesses
                .FirstOrDefault(ap => ap.virtualKeyCode == virtualKey);
            return process;
        }

        private void CreateMediaLayer(String btnTitle, VirtualKeyCode keyCode, int row)
        {
            Button btnKey = new Button();
            btnKey.Tag = keyCode;
            btnKey.BackColor = Color.Green;
            btnKey.FlatStyle = FlatStyle.Flat;
            btnKey.ForeColor = SystemColors.Control;
            btnKey.Size = new Size(80, 36);
            btnKey.Text = btnTitle;
            btnKey.UseVisualStyleBackColor = false;
            btnKey.Click += new EventHandler(this.OnClickSimulateKey);

            TextBox txtKey = new TextBox();
            txtKey.Tag = keyCode;
            txtKey.BorderStyle = BorderStyle.FixedSingle;
            txtKey.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
            txtKey.Size = new Size(160, 27);
            txtKey.Click += new EventHandler(this.OnClickAssingMediaProcess);
            txtKey.Anchor = AnchorStyles.None;

            Button btnRemoveKey = new Button();
            btnRemoveKey.Tag = GetProcessByVirtualKey(keyCode);
            btnRemoveKey.BackColor = Color.LightGray;
            btnRemoveKey.FlatStyle = FlatStyle.Flat;
            btnRemoveKey.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            btnRemoveKey.Size = new Size(25, 25);
            btnRemoveKey.Text = "X";
            btnRemoveKey.UseVisualStyleBackColor = false;
            btnRemoveKey.Anchor = AnchorStyles.None;
            btnRemoveKey.Click += (sender, e) =>
            {
                btnRemoveByVirtualKey_Click(sender, e);
                txtKey.Text = "";
            };

            this.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.Controls.Add(btnKey, 0, row);
            this.Controls.Add(txtKey, 1, row);
            this.Controls.Add(btnRemoveKey, 2, row);
        }

        private void OnClickSimulateKey(object sender, EventArgs e)
        {
            Control btn = sender as Control;
            if (btn.Tag is VirtualKeyCode enumValue)
            {
                keyboardSimulator.SimulateKey(enumValue);
                ChangeButtonColor(sender);
            }
        }
        private void OnClickAssingMediaProcess(object sender, EventArgs e)
        {
            OnChangeKeyCombination(sender);
        }
    }
}
