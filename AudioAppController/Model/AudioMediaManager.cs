using System;
using System.Collections.Generic;
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

        public void AddMediaPlayProcess(CustomKey customKey, VirtualKeyCode virtualKeyCode)
        {
            Action action = () =>
            {
                keyboardSimulator.SimulateKey(virtualKeyCode);
            };
            AudioProcess audioProcess = new AudioProcess();
            audioProcess.CustomKey = customKey;
            audioProcess.Action = action;
            audioProcess.virtualKeyCode = virtualKeyCode;
            mediaProcesses.Add(audioProcess);
        }


        public void ExecuteRealCombination(String combination)
        {
            List<AudioProcess> processes = mediaProcesses
                    .FindAll(ap => ap.CustomKey != null 
                    && ap.CustomKey.RealName.Equals(combination));
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
