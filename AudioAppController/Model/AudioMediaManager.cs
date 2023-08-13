using AudioAppController.View.Component;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace AudioAppController.Model
{
    public class AudioMediaManager
    {
        public List<AudioProcess> mediaProcesses { get; private set; }
        private KeyBoardSimulator keyboardSimulator;
        public AudioMediaManager() 
        {
            this.mediaProcesses = new List<AudioProcess>();
            this.keyboardSimulator = new KeyBoardSimulator();
            LoadMediaProcesses();
        } 

        private void LoadMediaProcesses()
        {
            AddMediaPlayProcess(null, VirtualKeyCode.MEDIA_NEXT_TRACK);
            AddMediaPlayProcess(null, VirtualKeyCode.MEDIA_PREV_TRACK);
            AddMediaPlayProcess(null, VirtualKeyCode.MEDIA_PLAY_PAUSE);
            AddMediaPlayProcess(null, VirtualKeyCode.MEDIA_STOP);
            AddMediaPlayProcess(null, VirtualKeyCode.VOLUME_MUTE);
        }

        public void AddMediaPlayProcess(String keyCombination, VirtualKeyCode virtualKeyCode)
        {
            Action action = () =>
            {
                keyboardSimulator.SimulateKey(virtualKeyCode);
            };
            AudioProcess audioProcess = new AudioProcess();
            audioProcess.KeyCombination = keyCombination;
            audioProcess.Action = action;
            audioProcess.virtualKeyCode = virtualKeyCode;
            mediaProcesses.Add(audioProcess);
        }

        public void ChangeKeyMediaPlayProcess(String oldKeyCombination, String newKeyCombination)
        {
            List<AudioProcess> audioProcess = mediaProcesses.FindAll(ap => ap.KeyCombination != null && ap.KeyCombination.Equals(oldKeyCombination));

            if (audioProcess.Count > 0)
            {
                foreach (AudioProcess ap in audioProcess)
                {
                    ap.KeyCombination = newKeyCombination;
                }
            }
        }

        public void ChangeKeyComnbination(String oldKeyCombination, String newKeyCombination, VirtualKeyCode keyCode)
        {
            bool hasKeyCombination = oldKeyCombination != null && oldKeyCombination.Length > 0;
            bool hasNewKeyCombination = newKeyCombination != null && newKeyCombination.Length > 0;

            if (!hasNewKeyCombination)
            {
                return;
            };

            if (hasKeyCombination && !newKeyCombination.Equals(oldKeyCombination))
            {
                ChangeKeyMediaPlayProcess(oldKeyCombination, newKeyCombination);
            }

            if (!hasKeyCombination && hasNewKeyCombination)
            {
                AddMediaPlayProcess(newKeyCombination, keyCode);
            }
        }

        public void ExecuteCombination(String combination)
        {
            List<AudioProcess> processes = mediaProcesses
                    .FindAll(ap => ap.KeyCombination != null 
                    && ap.KeyCombination.Equals(combination));
            if (processes.Count > 0)
            {
                foreach (AudioProcess ap in processes)
                {
                    ap.Action();                    
                }
            }
        }
    }
}
