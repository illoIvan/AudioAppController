using AudioAppController.Model;
using AudioAppController.View.Component;
using AudioAppController.View.Model;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsInput;

namespace AudioAppController
{
    internal class Mixer
    {
        private FlowLayoutPanel FlowLayoutSoundPanel;
        private List<AudioProcess> AudioProcesses;
        private List<AudioProcess> MediaPlayProcesses;
        private static List<AudioTrackPanel> AudioTrackPanels;
        private IKeyboardMouseEvents GlobalHook;
        private InputSimulator Simulator;
        private bool AllMuted = false;

        public Mixer(FlowLayoutPanel flowLayoutSoundPanel) 
        {
            FlowLayoutSoundPanel = flowLayoutSoundPanel;
            AudioProcesses = new List<AudioProcess>();
            MediaPlayProcesses = new List<AudioProcess>();
            Simulator = new InputSimulator();
            AudioTrackPanels = new List<AudioTrackPanel>();
            GlobalHook = Hook.GlobalEvents();
            GlobalHook.KeyUp += KeyboardHook_KeyUp;
            Load();
        }

        public void Close()
        {
            GlobalHook.Dispose();
            GlobalHook = null;
        }

        public void Load()
        {
            List<AudioProcess> actualAudioProcesses = LoadAudioProcesses();
            AddNewAudioProcesses(actualAudioProcesses);
        }

        public void Reload()
        {
            List<AudioProcess> actualAudioProcesses = LoadAudioProcesses();

            RemoveAudioProcessesNotInList(actualAudioProcesses);
            AddNewAudioProcesses(actualAudioProcesses);
        }

        private List<AudioProcess> LoadAudioProcesses()
        {
            return AudioProcess.LoadAllAudioProcess();
        }

        public void ShowAllLoadedProcesses()
        {
            foreach (AudioTrackPanel atp in AudioTrackPanels)
            {
                ShowAudioTrackPanel(atp);
            }
        }

        private void AddNewAudioProcesses(List<AudioProcess> actualAudioProcesses)
        {
            foreach (var audioProcess in actualAudioProcesses)
            {
                if (GetAudioProcessFromList(this.AudioProcesses, audioProcess) == null)
                {
                    AddAudioProcess(audioProcess);
                }
            }
        }

        private void RemoveAudioProcessesNotInList(List<AudioProcess> actualAudioProcesses)
        {
            List<AudioProcess> audioProcessesToRemove = new List<AudioProcess>();

            foreach (AudioProcess audioProcess in this.AudioProcesses)
            {
                if (GetAudioProcessFromList(actualAudioProcesses, audioProcess) == null)
                {
                    AudioTrackPanel soundPanel = GetAudioTrackPanel(audioProcess);
                    if (soundPanel != null)
                    {
                        audioProcessesToRemove.Add(audioProcess);
                    }
                }
            }

            foreach (AudioProcess audioProcessToRemove in audioProcessesToRemove)
            {
                RemoveAudioProcess(audioProcessToRemove);
            }
        }

        public void RemoveAudioProcess(AudioProcess audioProcess)
        {
            if (audioProcess == null) return;

            this.AudioProcesses.Remove(audioProcess);
            AudioTrackPanel audioTrackPanel = GetAudioTrackPanel(audioProcess);
            if (audioTrackPanel != null)
            {
                AudioTrackPanels.Remove(audioTrackPanel);
                RemoveFromView(audioTrackPanel);
            }
        }

        private void RemoveFromView(AudioTrackPanel audioTrackPanel)
        {
            if (audioTrackPanel == null || !audioTrackPanel.IsShowing) return;
            audioTrackPanel.IsShowing = false;
            FlowLayoutSoundPanel.Controls.Remove(audioTrackPanel);
        }

        public void AddAudioProcess(AudioProcess audioProcess, bool showAudioTrackPanel = false)
        {
            if (audioProcess == null) return;
            AudioTrackPanel atpAdded = GetAudioTrackPanel(audioProcess);

            if(atpAdded != null)
            {
                ShowAudioTrackPanel(atpAdded);
                return;
            }

            AudioTrackPanel newAtp = new AudioTrackPanel(audioProcess);
            if (newAtp != null)
            {
                AudioProcesses.Add(audioProcess);
                AudioTrackPanels.Add(newAtp);
                if (showAudioTrackPanel)
                {
                    ShowAudioTrackPanel(newAtp);
                }
            }
        }

        private void ShowAudioTrackPanel(AudioTrackPanel audioTrackPanel)
        {
            if (audioTrackPanel == null || audioTrackPanel.IsShowing) return;
            audioTrackPanel.IsShowing = true;
            FlowLayoutSoundPanel.Controls.Add(audioTrackPanel);
        }

        public bool ToggleMuteAll()
        {
            bool newMuteValue = !AllMuted;

            foreach (AudioTrackPanel atp in AudioTrackPanels)
            {
                if (atp.IsShowing && atp.AudioProcess.IsMuted != newMuteValue)
                {
                    atp.AudioProcess.ToggleVolume();
                    atp.UpdateForm();
                }
            }

            AllMuted = newMuteValue;
            return AllMuted;
        }
        
        private AudioProcess GetAudioProcessFromList(List<AudioProcess> actualAudioProcesses,
            AudioProcess audioProcess)
        {
            return actualAudioProcesses.FirstOrDefault(ap => ap.ProcessName == audioProcess.ProcessName);
        }

        private AudioTrackPanel GetAudioTrackPanel(AudioProcess audioProcess)
        {
            return AudioTrackPanels
                .FirstOrDefault(sp => sp.AudioProcess.ProcessName == audioProcess.ProcessName);
        }

        public List<AudioProcess> GetAudioProcesses()
        {
            return AudioProcesses;
        }

        public void AddMediaPlayProcess(String keyCombination, VirtualKeyCode virtualKeyCode)
        {
            Action action = () =>
            {
                Simulator.Keyboard.ModifiedKeyStroke(null, virtualKeyCode);
            };
            AudioProcess audioProcess = new AudioProcess();
            audioProcess.KeyCombination = keyCombination;
            audioProcess.Action = action;
            MediaPlayProcesses.Add(audioProcess);
        }

        public void ChangeKeyMediaPlayProcess(String oldKeyCombination, String newKeyCombination)
        {
            List<AudioProcess> audioProcess = MediaPlayProcesses.FindAll(ap => ap.KeyCombination != null && ap.KeyCombination.Equals(oldKeyCombination));

            if(audioProcess.Count > 0)
            {
                foreach (AudioProcess ap in audioProcess)
                {
                    ap.KeyCombination = newKeyCombination;
                }
            }
        }

        public void SimulateKey(VirtualKeyCode virtualKeyCode)
        {
            Simulator.Keyboard.ModifiedKeyStroke(null, virtualKeyCode);
        }

        private void KeyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            String[] keys = e.KeyData.ToString().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            String key = keys[0];
            String modifiers = string.Join("+", keys.Skip(1));

            if (keys.Length == 0) return;
            
            String combination = modifiers + "+" + key;
            List<AudioTrackPanel> audioTrackPanel = AudioTrackPanels.FindAll(atp => atp.AudioProcess.KeyCombination != null && atp.AudioProcess.KeyCombination.Equals(combination));
            if (audioTrackPanel.Count > 0)
            {
                foreach (AudioTrackPanel atp in audioTrackPanel)
                {
                    if (atp.IsShowing)
                    {
                        atp.AudioProcess.Action();
                        atp.UpdateForm();
                    }
                }
            }
            List<AudioProcess> mediaPlayProcesses = MediaPlayProcesses.FindAll(ap => ap.KeyCombination != null && ap.KeyCombination.Equals(combination));

            if (mediaPlayProcesses.Count > 0)
            {
                foreach (AudioProcess ap in mediaPlayProcesses)
                {
                    ap.Action();
                }
            }
        }
        public static String OpenKeySelectionWindow(String keyCombination)
        {
            KeySelectionWindow keySelectionWindow = new KeySelectionWindow(keyCombination);
            DialogResult result = keySelectionWindow.ShowDialog();

            if (!(result == DialogResult.OK))
            {
                return null;
            }

            String modifiers = keySelectionWindow.Modifiers;
            String key = keySelectionWindow.Key;
            if (modifiers == null || modifiers.Length == 0)
            {
                return null;
            }

            return modifiers + key;
        }
    }
}
