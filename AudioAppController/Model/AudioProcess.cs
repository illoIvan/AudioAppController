
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace AudioAppController.Model
{
    public class AudioProcess
    {

        public Process Process { get; private set; }
        public string ProcessName { get; private set; }
        public int ProcessId { get; private set; }
        public string Description { get; private set; }
        public float Volume { get; set; }
        public string IconPath { get; private set; }
        public string WindowTitle { get; private set; }
        public bool IsMuted { get { return Volume == 0; }}
        public float OriginalVolume { get; set; }
        public Action Action { get; set; }
        public String KeyCombination { get; set; }

        public AudioProcess() { }

        public AudioProcess(Process process, string processName = "", int processId = 0
            ,string description = "", float volume = 0f, string iconPath = "")
        {
            this.ProcessName = processName;
            this.ProcessId = processId;
            this.Process = process;
            this.Description = description;
            this.Volume = volume;
            this.IconPath = iconPath;
        }

        public static List<AudioProcess> LoadAllAudioProcess()
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

        public static AudioProcess ToAudioProcess(AudioSession audioSession)
        {
            AudioProcess audioProcess = new AudioProcess();
            Process process = audioSession.Process;

            audioProcess.Process = process;
            audioProcess.IconPath = audioSession.IconPath;

            if(process != null)
            {
                audioProcess.Volume = VolumeMixer.GetApplicationVolume(process.Id);
                audioProcess.ProcessId = process.Id;
                audioProcess.ProcessName = process.ProcessName;
                audioProcess.WindowTitle = process.MainWindowTitle;
            }
            return audioProcess;
        }



        public bool HasExited()
        {
            return this.Process.HasExited;
        }

        public void SetVolume(float volume)
        {
            //Debug.WriteLine(string.Format("{0} Actual volumen: {1} | SetVolumen: {2}",ProcessName, this.Volume, volume));
            this.OriginalVolume = this.Volume;
            this.Volume = volume;

            VolumeMixer.SetApplicationVolume(ProcessId, volume);
        }

        public void RestoreVolume()
        {
            SetVolume(OriginalVolume);
        }

        public void Mute()
        {
            SetVolume(0);
        }

        public void ToggleVolume()
        {
            if (IsMuted)
            {
                RestoreVolume();
            }
            else
            {
                Mute();
            }
        }
        public override int GetHashCode()
        {
            return -641338391 + EqualityComparer<string>.Default.GetHashCode(ProcessName);
        }
        public override bool Equals(object obj)
        {
            return obj is AudioProcess process &&
                   ProcessName == process.ProcessName;
        }

    }
}
