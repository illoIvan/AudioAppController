using AudioAppController.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AudioAppController.View.Model
{
    internal class KeySelectionWindow : Form
    {
        public String Modifiers;
        public String Key { get; set; }
        private CheckBox ChkShift { get; set; }
        private CheckBox ChkControl { get; set; }
        private CheckBox ChkAlt { get; set; }
        private ComboBox ComboBox { get; set; }

        private Button AcceptButton;

        private char KEY_SEPARATOR = char.Parse(CustomKeys.KEY_SEPARATOR);
        private String KEY_SHIFT = CustomKeys.Shift.DisplayName;
        private String KEY_CONTROL = CustomKeys.Control.DisplayName;
        private String KEY_ALT = CustomKeys.Alt.DisplayName;

        public KeySelectionWindow(CustomKey customKey) 
        {
            InitializeComponent();
            InitializeForm(customKey);
        }

        private void InitializeComponent()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Padding = new Padding(10);
            this.AutoSize = false;

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.ColumnCount = 3;
            this.Controls.Add(tableLayoutPanel);

            ChkShift = new CheckBox();
            ChkShift.Text = KEY_SHIFT;
            ChkShift.Font = new Font(ChkShift.Font.FontFamily, 14);
            ChkShift.CheckedChanged += onCheckedChanged_Click;

            ChkControl = new CheckBox();
            ChkControl.Text = KEY_CONTROL;
            ChkControl.Font = new Font(ChkControl.Font.FontFamily, 14);
            ChkControl.CheckedChanged += onCheckedChanged_Click;

            ChkAlt = new CheckBox();
            ChkAlt.Text = KEY_ALT;
            ChkAlt.Font = new Font(ChkAlt.Font.FontFamily, 14);
            ChkAlt.CheckedChanged += onCheckedChanged_Click;

            Label lblInfo = new Label();
            lblInfo.Text = "+";
            lblInfo.Font  = new Font(ChkControl.Font.FontFamily, 14);
            lblInfo.AutoSize = true;

            ComboBox = new ComboBox();
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Dock = DockStyle.Fill;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            ComboBox.Font = new Font(ChkControl.Font.FontFamily, 14);
            ComboBox.DropDownHeight = 250;
            ComboBox.DropDownWidth = 150;

            AcceptButton = new Button();
            AcceptButton.Text = "Accept";
            AcceptButton.AutoSize = true;
            AcceptButton.Click += btnAccept_Click;
            AcceptButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            AcceptButton.Font = new Font(ChkControl.Font.FontFamily, 14);
            AcceptButton.Enabled = false;
            ComboBox.DisplayMember = "DisplayName";

            ComboBox.Items.AddRange(CustomKeys.GetAllKeys().ToArray());
            ComboBox.SelectedIndex = 0;

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkShift, 0, 0);
            
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkControl, 0, 1);
            
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkAlt, 0, 2);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(lblInfo, 1, 1);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ComboBox, 2, 1);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(AcceptButton, 2, 3);

            tableLayoutPanel.Size = new Size(300, 200);
            this.Text = "Change Hotkey";
            this.Size = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void InitializeForm(CustomKey customKey)
        {
            if (customKey == null || string.IsNullOrEmpty(customKey.RealName))
            {
                return;
            }

            string[] keys = customKey.RealName.Split(KEY_SEPARATOR);
            string keySelected = keys[keys.Length - 1];

            int indexComboBox = ComboBox.Items.IndexOf(CustomKeys.GetCustomKeyByRealName(keySelected));
            ComboBox.SelectedIndex = indexComboBox;

            foreach (string key in keys.Take(keys.Length - 1))
            {
                if (key.Equals(KEY_SHIFT, StringComparison.OrdinalIgnoreCase))
                {
                    ChkShift.Checked = true;
                }
                else if (key.Equals(KEY_CONTROL, StringComparison.OrdinalIgnoreCase))
                {
                    ChkControl.Checked = true;
                }
                else if (key.Equals(KEY_ALT, StringComparison.OrdinalIgnoreCase))
                {
                    ChkAlt.Checked = true;
                }
            }

            EnableAcceptButton();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            buildModifiers();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void onCheckedChanged_Click(object sender, EventArgs e)
        {
            EnableAcceptButton();
        }

        private void EnableAcceptButton()
        {
            this.AcceptButton.Enabled = ChkShift.Checked || ChkControl.Checked || ChkAlt.Checked;
        }

        private void buildModifiers()
        {
            String key = "";
            if (ChkShift.Checked)
            {
                key += KEY_SHIFT + KEY_SEPARATOR;
            }
            if (ChkControl.Checked)
            {
                key += KEY_CONTROL + KEY_SEPARATOR;
            }
            if (ChkAlt.Checked)
            {
                key += KEY_ALT + KEY_SEPARATOR;
            }
            Modifiers = key;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1) return;

            Key = (comboBox.SelectedItem as CustomKey).RealName;
        }
    }
}
