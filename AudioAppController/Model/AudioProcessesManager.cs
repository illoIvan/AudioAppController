using AudioAppController.View.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAppController.Model
{
    public class AudioProcessesManager
    {

        private List<AudioProcess> audioProcesses;
        public AudioProcessesManager() 
        {
            audioProcesses = GetNewAudioProcesses();
        }

        public List<AudioProcess> GetAudioProcesses()
        {
            return audioProcesses;
        }

        private List<AudioProcess> GetNewAudioProcesses()
        {
            List<AudioProcess> audioProcessList = new List<AudioProcess>();

            audioProcessList.Clear();
            IList<AudioSession> audioSessionList = AudioUtilities.GetAllSessions();
            foreach (AudioSession item in audioSessionList)
            {
                if (item.Process != null)
                {
                    audioProcessList.Add(AudioProcess.ToAudioProcess(item));
                }
            }
            return audioProcessList;
        }

        public void Load()
        {
            List<AudioProcess> actualAudioProcesses = GetAudioProcesses();
            UpdateList(actualAudioProcesses);
        }

        public void Reload()
        {
            List<AudioProcess> newProcesses = GetNewAudioProcesses();
            List<AudioProcess> oldProcessesToRemove = GetAudioProcessesNotOnList(newProcesses);

            Remove(oldProcessesToRemove);
            UpdateList(newProcesses);
        }

        private void UpdateList(List<AudioProcess> newAudioProcesses)
        {
            foreach (AudioProcess audioProcess in newAudioProcesses)
            {
                Add(audioProcess);
            }
        }

        public void Add(AudioProcess audioProcess)
        {
            if (audioProcess == null || IsOnList(audioProcess)) return;

            this.audioProcesses.Add(audioProcess);
        }

        public void Add(List<AudioProcess> audioProcesses)
        {
            foreach (AudioProcess ap in audioProcesses)
            {
                Add(ap);
            }
        }

        private AudioProcess GetAudioProcess(AudioProcess audioProcess)
        {
            return this.audioProcesses.FirstOrDefault(ap => ap.ProcessName == audioProcess.ProcessName);
        }

        private AudioProcess GetAudioProcessFromList(List<AudioProcess> actualAudioProcesses,
            AudioProcess audioProcess)
        {
            return actualAudioProcesses.FirstOrDefault(ap => ap.ProcessName == audioProcess.ProcessName);
        }

        private List<AudioProcess> GetAudioProcessesNotOnList(List<AudioProcess> newAudioProcesses)
        {
            List<AudioProcess> audioProcessesToRemove = new List<AudioProcess>();

            //iterate old list audio mediaProcesses
            foreach (AudioProcess audioProcess in this.audioProcesses)
            {
                if (GetAudioProcessFromList(newAudioProcesses, audioProcess) == null)
                {
                    audioProcessesToRemove.Add(audioProcess);
                }
            }
            return audioProcessesToRemove;
        }

        private void Remove(List<AudioProcess> list)
        {
            foreach (AudioProcess audioProcess in list)
            {
                RemoveAudioProcess(audioProcess);
            }
        }

        public void RemoveAudioProcess(AudioProcess audioProcess)
        {
            if (audioProcess == null || !IsOnList(audioProcess)) return;

            audioProcess.KeyCombination = null;
            this.audioProcesses.Remove(audioProcess);
        }

        public bool IsOnList(AudioProcess audioProcess)
        {
            if (audioProcess == null) return false;

            AudioProcess apAdded = GetAudioProcess(audioProcess);
            return apAdded != null;
        }

        public void ExecuteCombination(String combination)
        {
            List<AudioProcess> processes = audioProcesses
                    .FindAll(ap => ap.KeyCombination != null && ap.KeyCombination.Equals(combination));
            if (processes.Count > 0)
            {
                foreach (AudioProcess ap in processes)
                {
                    ap.Action();
                }
            }
        }

        public bool IsAllMuted()
        {
            bool isAllMuted = true;

            if (audioProcesses.Count == 0)
            {
                return false;
            }

            foreach (AudioProcess ap in audioProcesses)
            {
                if (!ap.IsMuted)
                {
                    isAllMuted = false;
                }
            }
            return isAllMuted ;
        }
    }
}
