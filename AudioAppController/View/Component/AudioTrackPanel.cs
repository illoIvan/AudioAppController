using AudioAppController.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AudioAppController.View.Component
{
    public class AudioTrackPanel : Panel
    {
        public AudioProcess AudioProcess { get; set; }   
        public bool IsShowing { get; set; }

        private Label lblTitle;
        private TextBox txtKeyHandler;
        private TrackBar trackBar;
        private Label lblVolume;
        private Button btnMute;
        private Button btnRemove;
        public event EventHandler OnRemoveFromView;
        public event EventHandler OnMute;
        public AudioTrackPanel(AudioProcess audioProcess)
        {
            this.AudioProcess = audioProcess;
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(5);
            this.Width = CustomProperties.AudioTrackPanelWidth;
            this.Height = CustomProperties.AudioTrackPanelHeight;
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

            // FlowLayoutPanel txtHandler and clear txtHandler
            FlowLayoutPanel flowLayoutPanelHandler = new FlowLayoutPanel();
            flowLayoutPanelHandler.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelHandler.Dock = DockStyle.Fill;
            flowLayoutPanelHandler.AutoSize = true;

            //Button clear txtHandler
            Button btnClearHandler = new Button();
            btnClearHandler.Anchor = AnchorStyles.None;
            btnClearHandler.Text = "X";
            btnClearHandler.Width = 20;
            btnClearHandler.BackColor = Color.LightGray;
            btnClearHandler.FlatStyle = FlatStyle.Flat;
            btnClearHandler.FlatAppearance.BorderSize = 0;
            btnClearHandler.Click += btnClearHandler_Click;

            // TextBox key handler
            txtKeyHandler = new TextBox();
            txtKeyHandler.Anchor = AnchorStyles.None;
            txtKeyHandler.Width = this.Width - 40;
            txtKeyHandler.TextAlign = HorizontalAlignment.Center;
            txtKeyHandler.Text = AudioProcess?.CustomKey?.DisplayName.ToString();
            txtKeyHandler.Padding = new Padding(5);
            txtKeyHandler.Click += btnKeySelectionWindow_Click;
            txtKeyHandler.ReadOnly = true;
            txtKeyHandler.Font = new Font(txtKeyHandler.Font.FontFamily, 10);
            txtKeyHandler.BorderStyle = BorderStyle.FixedSingle;
            txtKeyHandler.Text = "click to add key";

            flowLayoutPanelHandler.Controls.Add(btnClearHandler);
            flowLayoutPanelHandler.Controls.Add(txtKeyHandler);
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(flowLayoutPanelHandler, 0, 1);

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
            btnMute.FlatStyle = FlatStyle.Flat;
            btnMute.FlatAppearance.BorderSize = 0;

            //Button remove
            btnRemove = new Button();
            btnRemove.Text = "X";
            btnRemove.Click += btnRemove_Click;
            btnRemove.Height = 30;
            btnRemove.Width = btnMute.Width;
            btnRemove.Font = new Font(btnRemove.Font.FontFamily, 12);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.BackColor = Color.LightGray;
            btnRemove.Tag = AudioProcess;

            flowLayoutPanelOptions.Controls.Add(btnMute);
            flowLayoutPanelOptions.Controls.Add(btnRemove);
        }


        private void btnClearHandler_Click(object sender, EventArgs e)
        {
            ClearKeyCombination();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemoveFromView?.Invoke(this, EventArgs.Empty);
        }

        public void btnMute_Click(Object sender, EventArgs e)
        {
            AudioProcess.ToggleVolume();
            UpdateView();
            OnMute?.Invoke(this, EventArgs.Empty);
        }

        public void OnScroll(Object sender, EventArgs e)
        {
            AudioProcess.SetVolume(trackBar.Value);
            UpdateView();
            if(trackBar.Value == 0)
            {
                OnMute?.Invoke(this, EventArgs.Empty);
            }
        }

        public void UpdateView()
        {
            lblVolume.Text = "Volume: " + AudioProcess.Volume;
            btnMute.BackColor = AudioProcess.IsMuted ? Color.Red : Color.Green;
            btnMute.Text = AudioProcess.IsMuted ? "UnMute" : "Mute";
            trackBar.Value = (int)(AudioProcess.Volume);
        }

        private void btnKeySelectionWindow_Click(object sender, EventArgs e)
        {
            CustomKey newCustomKey = CreateDialog.OpenKeySelectionWindow(AudioProcess.CustomKey);

            if(newCustomKey == null && this.AudioProcess.CustomKey != null)
            {
                return;
            }

            if(newCustomKey == null) 
            {
                ClearKeyCombination();
                return;
            }

            AudioProcess.CustomKey = newCustomKey;
            txtKeyHandler.Text = newCustomKey.DisplayName;
            Action action = () =>
            {
                this.AudioProcess.ToggleVolume();
            };
            AudioProcess.Action = action;
        }

        private void ClearKeyCombination()
        {
            AudioProcess.CustomKey = null;
            txtKeyHandler.Text = "click to add key";
        }
    }
}
