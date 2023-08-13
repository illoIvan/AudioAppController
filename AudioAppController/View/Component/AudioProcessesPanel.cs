using AudioAppController.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioAppController.View.Component
{
    public class AudioProcessesPanel : FlowLayoutPanel
    {
        private List<AudioTrackPanel> trackPanels;
        public event EventHandler OnAudioTrackPanelMute;
        public event EventHandler OnAudioTrackPanelRemove;
        public AudioProcessesPanel()
        {
            this.trackPanels = new List<AudioTrackPanel>();
            InitializeComponent();
        }

        public List<AudioTrackPanel> GetAudioTrackPanels()
        {
            return this.trackPanels;
        }

        private void InitializeComponent()
        {
            int panelOutMargin = 50;
            //number of audioTrackPanels to show per row
            int numberPanelsPerRow = 3;
            int width = CustomProperties.AudioTrackPanelWidth * numberPanelsPerRow + panelOutMargin;
            int height = CustomProperties.AudioTrackPanelHeight + 80;

            this.Size = new Size(width, height);
            this.AutoScroll = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Location = new Point(12, 100);
        }

        public void LoadAndShow(List<AudioProcess> audioProcesses)
        {
            UpdateList(audioProcesses, true);
        }

        public void Reload(List<AudioProcess> newAudioProcesses)
        {
            List<AudioProcess> oldAudioProcesses = GetNoInList(newAudioProcesses);
            Remove(oldAudioProcesses);
            UpdateList(newAudioProcesses);
        }

        private List<AudioProcess> GetNoInList(List<AudioProcess> actualAudioProcesses)
        {
            List<AudioProcess> listToRemove = new List<AudioProcess>();

            foreach (AudioTrackPanel atp in this.trackPanels)
            {
                AudioProcess audioProcess = atp.AudioProcess;
                if (IsOnList(actualAudioProcesses, audioProcess))
                {
                    listToRemove.Add(audioProcess);
                }
            }
            return listToRemove;
        }

        private List<AudioTrackPanel> ToAudioPanels(List<AudioProcess> list)
        {
            List<AudioTrackPanel> panels = new List<AudioTrackPanel>();
            foreach (AudioProcess audioProcess in list)
            {
                AudioTrackPanel newAtp = new AudioTrackPanel(audioProcess);
                panels.Add(newAtp);
            }
            return panels;
        }

        private AudioTrackPanel GetAudioPanel(AudioProcess audioProcess)
        {
            return trackPanels
                .FirstOrDefault(atp => atp.AudioProcess.ProcessName == audioProcess.ProcessName);
        }

        private void UpdateList(List<AudioProcess> audioProcesses, bool show = false)
        {
            List<AudioTrackPanel> audioTrackPanels = ToAudioPanels(audioProcesses);

            foreach (AudioTrackPanel audioPanel in audioTrackPanels)
            {
                AudioProcess audioProcess = audioPanel.AudioProcess;
                if (!IsOnList(audioProcess))
                {
                    AddAudioTrackPanel(audioProcess, show);
                }
            }
        }

        private bool IsOnList(AudioProcess audioProcess)
        {
            if (audioProcess == null) return false;

            AudioTrackPanel atpAdded = GetAudioPanel(audioProcess);
            return atpAdded != null;
        }

        private void ShowAudioPanel(AudioTrackPanel audioTrackPanel)
        {
            if (audioTrackPanel == null || audioTrackPanel.IsShowing) return;
            audioTrackPanel.IsShowing = true;
            this.Controls.Add(audioTrackPanel);
        }

        public void AddAudioTrackPanel(AudioProcess audioProcess, bool show = false)
        {
            if (audioProcess == null) return;
            AudioTrackPanel atpAdded = GetAudioPanel(audioProcess);

            if (atpAdded != null)
            {
                ShowAudioPanel(atpAdded);
                return;
            }

            AudioTrackPanel newAtp = new AudioTrackPanel(audioProcess);
            if (newAtp != null)
            {
                newAtp.OnRemoveFromView += (sender, e) => { 
                    this.RemoveAudioTrackPanel(((AudioTrackPanel)sender).AudioProcess);
                };
                newAtp.OnMute += (sender, e) =>
                {
                    OnAudioTrackPanelMute?.Invoke(this, EventArgs.Empty);
                };
                trackPanels.Add(newAtp);
                if (show)
                {
                    ShowAudioPanel(newAtp);
                }
            }
        }



        public void AddAudioTrackPanel(List<AudioProcess> audioProcesses, bool show = false)
        {
            List<AudioProcess> audioProcessesToAdd = new List<AudioProcess>();
            foreach (AudioProcess audioProcess in audioProcesses)
            {
                if (!IsOnList(audioProcess))
                {
                    audioProcessesToAdd.Add(audioProcess);
                }
            }

            foreach (AudioProcess audioProcess in audioProcessesToAdd)
            {
                AddAudioTrackPanel(audioProcess, show);
            }
        }

        public void RemoveAudioTrackPanel(AudioProcess audioProcess)
        {
            if(audioProcess == null) return;

            AudioTrackPanel audioPanelToRemove = GetAudioPanel(audioProcess);
            if (audioPanelToRemove == null) return;

            audioPanelToRemove.AudioProcess.KeyCombination = null;
            audioPanelToRemove.IsShowing = false;
            this.trackPanels.Remove(audioPanelToRemove);
            this.Controls.Remove(audioPanelToRemove);
            this.OnAudioTrackPanelRemove?.Invoke(audioPanelToRemove, EventArgs.Empty);
        }

        public void Remove(List<AudioProcess> oldAudioProcesses)
        {
            if (oldAudioProcesses == null) return;
            List<AudioProcess> audioProcessesToRemove = new List<AudioProcess>();

            foreach (AudioTrackPanel atp in this.trackPanels)
            {
                AudioProcess audioProcess = atp.AudioProcess;
                if (!IsOnList(oldAudioProcesses, audioProcess))
                {
                    AudioTrackPanel soundPanel = GetAudioPanel(audioProcess);
                    if (soundPanel != null)
                    {
                        audioProcessesToRemove.Add(audioProcess);
                    }
                }
            }
            foreach (AudioProcess audioProcess in audioProcessesToRemove)
            {
                RemoveAudioTrackPanel(audioProcess);
            }
        }

        private bool IsOnList(List<AudioProcess> newAudioProcesses,AudioProcess audioProcess)
        {
            AudioProcess process = newAudioProcesses
                .FirstOrDefault(ap => ap.ProcessName == audioProcess.ProcessName);
            return process != null;
        }


        public void ToggleMute(bool mute)
        {
            foreach (AudioTrackPanel atp in this.trackPanels)
            {
                if (atp.IsShowing && atp.AudioProcess.IsMuted != mute)
                {
                    atp.AudioProcess.ToggleVolume();
                    atp.UpdateView();
                }
            }
        }

        public List<AudioTrackPanel> GetByCombination(String combination)
        {
            if (combination == null) return new List<AudioTrackPanel> ();

            List<AudioTrackPanel> audioTrackPanels = trackPanels
                .FindAll(atp => atp.AudioProcess != null 
                    && atp.AudioProcess.KeyCombination != null 
                    && atp.AudioProcess.KeyCombination.Equals(combination));

            return audioTrackPanels;
        }

        public void UpdateViewPanelList(List<AudioTrackPanel> audioTrackPanels)
        {
            if(audioTrackPanels == null) return;

            foreach (AudioTrackPanel atp in audioTrackPanels)
            {
                atp.UpdateView();
            }
        }

        public bool HasAudioTrackPanels()
        {
            return this.trackPanels.Count > 0;
        }
    }
}
