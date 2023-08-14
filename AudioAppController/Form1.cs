
using AudioAppController.Model;
using AudioAppController.View.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AudioAppController
{
    public partial class Form1 : Form
    {
        private bool isReloading = false;
        private AudioMediaPanel audioMediaPanel;
        private AudioMediaManager audioMediaManager;
        private AudioProcessesPanel audioProcessesPanel;
        private AudioProcessesManager audioProcessesManager;
        private KeyBoardHook keyBoardHook;
        private bool isAllAudioTrackPanelsMuted = false;
        public Form1()
        {
            InitializeComponent();
            LoadComponents();
            FormClosing += Form_Closing;
        }

        public void LoadComponents()
        {
            audioProcessesPanel = new AudioProcessesPanel();
            audioProcessesPanel.OnAudioTrackPanelMute += OnAudioTrackPanelMute;
            audioProcessesManager = new AudioProcessesManager();
            audioMediaManager = new AudioMediaManager();
            audioMediaPanel = new AudioMediaPanel(audioMediaManager.mediaProcesses);
            keyBoardHook = new KeyBoardHook();  
            keyBoardHook.GlobalHook.KeyUp += KeyboardHook_KeyUp;
            this.Controls.Add(audioProcessesPanel);
            this.Controls.Add(audioMediaPanel); 
            ReloadComboboxList();
            OnAllAudioTrackPanelsMuted();
        }

        private void Form_Closing(object sender, CancelEventArgs e)
        {
            audioProcessesPanel = null;
            audioMediaPanel = null;
            audioProcessesManager = null;
            audioMediaManager = null;
            keyBoardHook.Close();
        }

        private void cbListAudioProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListAudioProcesses.SelectedItem != null && !isReloading)
            {
                AudioProcess selectedProcess = (AudioProcess)cbListAudioProcesses.SelectedItem;
                audioProcessesManager.Add(selectedProcess);
                audioProcessesPanel.AddAudioTrackPanel(selectedProcess, true);
            }
        }

        private void ReloadComboboxList()
        {
            audioProcessBindingSource.DataSource = audioProcessesManager.GetAudioProcesses();
            audioProcessBindingSource.ResetBindings(false);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            isReloading = true;
            audioProcessesManager.Reload();
            ReloadComboboxList();
            isReloading = false;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            List<AudioProcess> audioProcesses = this.audioProcessesManager.GetAudioProcesses();
            audioProcessesPanel.AddAudioTrackPanel(audioProcesses, true);
        }   

        private void OnAudioTrackPanelMute(object sender, EventArgs e)
        {
            OnAllAudioTrackPanelsMuted();
        }

        private void OnAllAudioTrackPanelsMuted()
        {
            this.isAllAudioTrackPanelsMuted = audioProcessesManager.IsAllMuted();
            btnMuteAll.Text = this.isAllAudioTrackPanelsMuted ? "Unmute All" : "Mute All";
        }

        private void OnAudioTrackPanelRemove(object sender, EventArgs e)
        {
            AudioTrackPanel audioTrackPanel = (AudioTrackPanel)sender;
            this.audioProcessesManager.RemoveAudioProcess(audioTrackPanel.AudioProcess);
        }

        private void btnMuteAll_Click(object sender, EventArgs e)
        {
            if (!audioProcessesPanel.HasAudioTrackPanels())
            {
                return;
            }
            bool newMuteValue = !this.isAllAudioTrackPanelsMuted;
            audioProcessesPanel.ToggleMute(newMuteValue);
            this.isAllAudioTrackPanelsMuted = newMuteValue;
            OnAllAudioTrackPanelsMuted();
        }
        
        private void KeyboardHook_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            String[] keys = e.KeyData.ToString().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            String key = keys[0];
            String modifiers = string.Join("+", keys.Skip(1));

            //Debug.WriteLine("keys: "+string.Join(", ", keys));  
            if (keys.Length == 0) return;

            String realCombination = modifiers + "+" + key;

            audioProcessesManager.ExecuteRealCombination(realCombination);
            audioMediaManager.ExecuteRealCombination(realCombination);
            audioProcessesPanel.UpdateViewPanelList(audioProcessesPanel.GetByRealKey(realCombination));
            this.OnAllAudioTrackPanelsMuted();
        }
    }
}
