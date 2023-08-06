
using AudioAppController.Model;
using AudioAppController.View.Component;
using AudioAppController.View.Model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput;

namespace AudioAppController
{
    public partial class Form1 : Form
    {
        private Mixer Mixer;
        private bool isReloading = false;
        
        public Form1()
        {
            InitializeComponent();
            Mixer = new Mixer(flowLayoutSoundPanel);
            this.btnMuteAll.Click += ToggleMuteAll;
            this.btnAddAll.Click += btnAddAll_Click;
            this.btnReload.Click += btnReload_Click;
            FormClosing += Form_Closing;
            ReloadComboboxList();
        }
        private void Form_Closing(object sender, CancelEventArgs e)
        {
            Mixer.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            isReloading = true;
            Mixer.Reload();
            ReloadComboboxList();
            isReloading = false;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            Mixer.ShowAllLoadedProcesses();
        }

        private void ToggleMuteAll(object sender, EventArgs e)
        {
            bool isAllMuted = Mixer.ToggleMuteAll();
            btnMuteAll.Text = isAllMuted ? "Unmute All" : "Mute All";
        }

        private void ReloadComboboxList()
        {
            audioProcessBindingSource.DataSource = Mixer.GetAudioProcesses();
            audioProcessBindingSource.ResetBindings(false);
        }

        private void cbListAudioProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListAudioProcesses.SelectedItem != null && !isReloading)
            {
                AudioProcess selectedProcess = (AudioProcess)cbListAudioProcesses.SelectedItem;
                Mixer.AddAudioProcess(selectedProcess,true);
            }
        }

        private void txtMediaPlayPause_Click(object sender, EventArgs e)
        {
            ChangeMediaPlayProcess(sender, VirtualKeyCode.MEDIA_PLAY_PAUSE);
        }

        private void txtMediaStop_Click(object sender, EventArgs e)
        {
            ChangeMediaPlayProcess(sender, VirtualKeyCode.MEDIA_STOP);
        }

        private void txtMediaNextTrack_Click(object sender, EventArgs e)
        {
            ChangeMediaPlayProcess(sender, VirtualKeyCode.MEDIA_NEXT_TRACK);
        }

        private void txtMediaPreviousTrack_Click(object sender, EventArgs e)
        {
            ChangeMediaPlayProcess(sender, VirtualKeyCode.MEDIA_PREV_TRACK);
        }

        private void txtMuteAudio_Click(object sender, EventArgs e)
        {
            ChangeMediaPlayProcess(sender, VirtualKeyCode.VOLUME_MUTE);
        }

        private void btnMediaPlayPause_Click(object sender, EventArgs e)
        {
            Mixer.SimulateKey(VirtualKeyCode.MEDIA_PLAY_PAUSE);
            ChangeButtonColor(sender);
        }
        private void btnMediaStop_Click(object sender, EventArgs e)
        {
            Mixer.SimulateKey(VirtualKeyCode.MEDIA_STOP);
            ChangeButtonColor(sender);
        }

        private void btnMediaNextTrack_Click(object sender, EventArgs e)
        {
            Mixer.SimulateKey(VirtualKeyCode.MEDIA_NEXT_TRACK);
            ChangeButtonColor(sender);
        }

        private void btnPreviousTrack_Click(object sender, EventArgs e)
        {
            Mixer.SimulateKey(VirtualKeyCode.MEDIA_PREV_TRACK);
            ChangeButtonColor(sender);
        }

        private void btnMuteAudio_Click(object sender, EventArgs e)
        {
            Mixer.SimulateKey(VirtualKeyCode.VOLUME_MUTE);
            ChangeButtonColor(sender);
        }

        private void ChangeButtonColor(object sender)
        {
            Button button = sender as Button;
            button.BackColor = button.BackColor.Equals(Color.Green) ? Color.Red : Color.Green;
        }

        private void ChangeMediaPlayProcess(object sender, VirtualKeyCode virtualKeyCode)
        {
            TextBox textBox = (TextBox)sender;

            String keyCombination = textBox.Text;
            String newKeyCombination = Mixer.OpenKeySelectionWindow(keyCombination);
            bool hasKeyCombination = keyCombination != null && keyCombination.Length > 0;
            bool hasNewKeyCombination = newKeyCombination != null && newKeyCombination.Length > 0;

            if (!hasNewKeyCombination) return;

            if (hasKeyCombination && !newKeyCombination.Equals(keyCombination))
            {
                Mixer.ChangeKeyMediaPlayProcess(keyCombination, newKeyCombination);
            }

            if (!hasKeyCombination && hasNewKeyCombination)
            {
                Mixer.AddMediaPlayProcess(newKeyCombination, virtualKeyCode);
            }

            textBox.Text = newKeyCombination;
        }

    }
}
