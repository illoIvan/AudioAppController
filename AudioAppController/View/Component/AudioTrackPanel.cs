using AudioAppController.Model;
using AudioAppController.View.Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AudioAppController.View.Component
{
    internal class AudioTrackPanel : Panel
    {
        public AudioProcess AudioProcess { get; set; }   
        public bool IsShowing { get; set; }

        private Label lblTitle;
        private TextBox txtKeyHandler;
        private TrackBar trackBar;
        private Label lblVolume;
        private Button btnMute;
        private Button btnRemove;
        public AudioTrackPanel(AudioProcess audioProcess)
        {
            this.AudioProcess = audioProcess;
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(5);
            this.Width = 200;
            this.Height = 300;
            this.Dock = DockStyle.Top;// center vertically

            // TableLayoutPanel organize controls
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.None;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.Controls.Add(tableLayoutPanel);

            // Label title audioprocess
            lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Text = AudioProcess.ProcessName;
            lblTitle.Anchor = AnchorStyles.None; //center vertically
            lblTitle.BackColor = Color.Orange;
            lblTitle.Padding = new Padding(5);
            lblTitle.Margin = new Padding(0, 10, 0, 0);
            lblTitle.Font = new Font(lblTitle.Font.FontFamily, 10);
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(lblTitle, 0, 0);

            // TextBox key handler
            txtKeyHandler = new TextBox();
            txtKeyHandler.Anchor = AnchorStyles.None;
            txtKeyHandler.Width = this.Width - 40;
            txtKeyHandler.TextAlign = HorizontalAlignment.Center;
            txtKeyHandler.Text = AudioProcess?.KeyCombination?.ToString();
            txtKeyHandler.Padding = new Padding(5);
            txtKeyHandler.Margin = new Padding(0, 10, 0, 0);
            txtKeyHandler.Click += btnKeySelectionWindow_Click;
            txtKeyHandler.ReadOnly = true;
            txtKeyHandler.Font = new Font(txtKeyHandler.Font.FontFamily, 10);
            txtKeyHandler.BorderStyle = BorderStyle.FixedSingle;
            txtKeyHandler.Text = "click to add key";
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(txtKeyHandler, 0, 1);

            // TrackBar
            trackBar = new TrackBar();
            trackBar.Minimum = 0;
            trackBar.Maximum = 100;
            trackBar.Value = (int)AudioProcess.Volume;
            trackBar.TickStyle = TickStyle.Both;
            trackBar.Orientation = Orientation.Vertical;
            trackBar.TickFrequency = 10;
            trackBar.Height = 150;
            trackBar.Margin = new Padding(5);
            trackBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom; //center vertically
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 500));
            tableLayoutPanel.Controls.Add(trackBar, 0, 2);

            // Label volume
            lblVolume = new Label();
            lblVolume.Text = "Volume: " + trackBar.Value.ToString();
            lblVolume.Anchor = AnchorStyles.None;
            lblVolume.Font = new Font(lblVolume.Font.FontFamily, 14);
            lblVolume.Width = this.Width - 40;
            lblVolume.TextAlign = ContentAlignment.MiddleCenter;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(lblVolume, 0, 3);
            trackBar.Scroll += OnScroll;

            //FlowLayoutPanel
            FlowLayoutPanel flowLayoutPanelOptions = new FlowLayoutPanel();
            flowLayoutPanelOptions.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelOptions.Dock = DockStyle.Fill;
            flowLayoutPanelOptions.WrapContents = false;

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(flowLayoutPanelOptions, 0, 4);

            //Button mute
            btnMute = new Button();
            btnMute.Text = AudioProcess.IsMuted ? "UnMute" : "Mute";
            btnMute.Click += btnMute_Click;
            btnMute.Anchor = AnchorStyles.None;
            btnMute.BackColor = AudioProcess.IsMuted ? Color.Red : Color.Green;
            btnMute.Height = 30;

            btnMute.Font = new Font(btnMute.Font.FontFamily, 12);
            btnMute.ForeColor = Color.White;
            btnMute.Margin = new Padding(18,0,5,0);

            //Button remove
            btnRemove = new Button();
            btnRemove.Text = "X";
            btnRemove.Click += btnRemove_Click;
            btnRemove.Height = 30;
            btnRemove.Width = btnMute.Width;
            btnRemove.Font = new Font(btnRemove.Font.FontFamily, 12);

            flowLayoutPanelOptions.Controls.Add(btnMute);
            flowLayoutPanelOptions.Controls.Add(btnRemove);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.IsShowing = false;
        }

        public void btnMute_Click(Object sender, EventArgs e)
        {
            AudioProcess.ToggleVolume();
            UpdateForm();
        }

        public void OnScroll(Object sender, EventArgs e)
        {
            AudioProcess.SetVolume(trackBar.Value);
            UpdateForm();
        }

        public void UpdateForm()
        {
            lblVolume.Text = "Volume: " + AudioProcess.Volume;
            btnMute.BackColor = AudioProcess.IsMuted ? Color.Red : Color.Green;
            btnMute.Text = AudioProcess.IsMuted ? "UnMute" : "Mute";
            trackBar.Value = (int)(AudioProcess.Volume);
        }

        private void btnKeySelectionWindow_Click(object sender, EventArgs e)
        {
            String keyCombination = Mixer.OpenKeySelectionWindow(AudioProcess.KeyCombination);

            if(keyCombination == null) 
            {
                return;
            }

            AudioProcess.KeyCombination = keyCombination;
            txtKeyHandler.Text = keyCombination;
            Action action = () =>
            {
                this.AudioProcess.ToggleVolume();
            };
            AudioProcess.Action = action;
        }


    }
}
