using AudioAppController.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AudioAppController.View.Model
{
    internal class KeySelectionWindow : Form
    {
        //Modifiers
        private CheckBox chkSelectModifiers { get; set; }
        public bool isModifiers {get; private set;}

        public String Modifiers;
        public String Key { get; set; }
        private CheckBox ChkShift { get; set; }
        private CheckBox ChkControl { get; set; }
        private CheckBox ChkAlt { get; set; }
        private ComboBox modifiersCombobox { get; set; }

        //Specials keys
        public bool isSpecialKeys { get; private set; }
        private CheckBox chkSelectSpecialKeys { get; set; }
        private ComboBox specialKeysCombobox { get; set; }

        //modal buttons
        private Button btnAccept { get; set; }

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
            this.Text = "Change Hotkey";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoSize = true;
            this.Size = new Size(400, 300);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoSize = false;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.Padding = new Padding(0, 15, 0, 0);
            tableLayoutPanel.Height = 10;
            this.Controls.Add(tableLayoutPanel);

            //modifiers
            chkSelectModifiers = new CheckBox();
            chkSelectModifiers.Font = new Font(chkSelectModifiers.Font.FontFamily, 14);
            chkSelectModifiers.Text = "Modifiers";
            chkSelectModifiers.Width = 170;
            chkSelectModifiers.Click += OnChangeSelection;
            chkSelectModifiers.Margin = new Padding(5, 0, 0, 0);

            ChkShift = new CheckBox();
            ChkShift.Text = KEY_SHIFT;
            ChkShift.Font = new Font(ChkShift.Font.FontFamily, 14);
            ChkShift.CheckedChanged += onCheckedChanged_Click;
            ChkShift.Enabled = false;
            ChkShift.Margin = new Padding(20, 0, 0, 0);

            ChkControl = new CheckBox();
            ChkControl.Text = KEY_CONTROL;
            ChkControl.Font = new Font(ChkControl.Font.FontFamily, 14);
            ChkControl.CheckedChanged += onCheckedChanged_Click;
            ChkControl.Enabled = false;
            ChkControl.Margin = new Padding(20, 0, 0, 0);

            ChkAlt = new CheckBox();
            ChkAlt.Text = KEY_ALT;
            ChkAlt.Font = new Font(ChkAlt.Font.FontFamily, 14);
            ChkAlt.CheckedChanged += onCheckedChanged_Click;
            ChkAlt.Enabled = false;
            ChkAlt.Margin = new Padding(20, 0, 0, 0);

            Label lblInfo = new Label();
            lblInfo.Text = "+";
            lblInfo.Font  = new Font(lblInfo.Font.FontFamily, 14);
            lblInfo.AutoSize = true;

            modifiersCombobox = new ComboBox();
            modifiersCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            modifiersCombobox.Dock = DockStyle.Fill;
            modifiersCombobox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            modifiersCombobox.Font = new Font(modifiersCombobox.Font.FontFamily, 14);
            modifiersCombobox.DropDownHeight = 250;
            modifiersCombobox.DropDownWidth = 150;
            modifiersCombobox.DisplayMember = "DisplayName";
            modifiersCombobox.Items.AddRange(CustomKeys.GetAllKeys().ToArray());
            modifiersCombobox.SelectedIndex = 0;
            modifiersCombobox.Enabled = false;

            btnAccept = new Button();
            btnAccept.Text = "Accept";
            btnAccept.AutoSize = true;
            btnAccept.Click += btnAccept_Click;
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.Font = new Font(btnAccept.Font.FontFamily, 14);
            btnAccept.Enabled = false;
            

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(chkSelectModifiers, 0, 0);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkShift, 0, 1);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(lblInfo, 1, 2);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(modifiersCombobox, 2, 2);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkControl, 0, 2);
            
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkAlt, 0, 3);

            //specials keys
            chkSelectSpecialKeys = new CheckBox();
            chkSelectSpecialKeys.Font = new Font(chkSelectSpecialKeys.Font.FontFamily, 14);
            chkSelectSpecialKeys.Text = "Special key";
            chkSelectSpecialKeys.Width = 200;
            chkSelectSpecialKeys.Click += OnChangeSelection;
            chkSelectSpecialKeys.Margin = new Padding(5, 0, 0,0);

            specialKeysCombobox = new ComboBox();
            specialKeysCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            specialKeysCombobox.Dock = DockStyle.Fill;
            specialKeysCombobox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            specialKeysCombobox.Font = new Font(specialKeysCombobox.Font.FontFamily, 14);
            specialKeysCombobox.DropDownHeight = 250;
            specialKeysCombobox.DropDownWidth = 150;
            specialKeysCombobox.Items.AddRange(CustomKeys.GetAllSpecialKeys().ToArray());
            specialKeysCombobox.DisplayMember = "DisplayName";
            specialKeysCombobox.SelectedIndex = 0;
            specialKeysCombobox.Enabled = false;

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent));
            tableLayoutPanel.Controls.Add(chkSelectSpecialKeys, 0, 4);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(specialKeysCombobox, 0, 5);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(btnAccept, 2, 6);
        }

        private void InitializeForm(CustomKey customKey)
        {
            if (customKey == null || string.IsNullOrEmpty(customKey.RealName))
            {
                return;
            }

            string[] keys = customKey.RealName.Split(KEY_SEPARATOR);

            if (keys.Length == 1) // special key
            {
                string specialKey = keys[0];
                Key = specialKey;
                chkSelectSpecialKeys.Checked = true;
                specialKeysCombobox.SelectedItem = CustomKeys.GetCustomKeyByRealName(specialKey);
                OnChangeSelection(specialKeysCombobox, EventArgs.Empty);
            }
            else if (keys.Length > 1) // modifiers + key
            {
                string keySelected = keys.Last();
                int indexComboBox = modifiersCombobox.Items.IndexOf(CustomKeys.GetCustomKeyByRealName(keySelected));
                modifiersCombobox.SelectedIndex = indexComboBox;
                Key = keySelected;
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

                chkSelectModifiers.Checked = true;
                OnChangeSelection(chkSelectModifiers, EventArgs.Empty);
            }
            EnableAcceptButton();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (chkSelectModifiers.Checked)
            {
                buildModifiers();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void onCheckedChanged_Click(object sender, EventArgs e)
        {
            EnableAcceptButton();
        }

        private void EnableAcceptButton()
        {
            this.btnAccept.Enabled = ChkShift.Checked 
                || ChkControl.Checked 
                || ChkAlt.Checked
                || chkSelectSpecialKeys.Checked;
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

        private void OnChangeSelection(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = sender as CheckBox;

            if (clickedCheckbox == chkSelectModifiers)
            {
                chkSelectSpecialKeys.Checked = false;
                Key = (modifiersCombobox.SelectedItem as CustomKey).RealName;
            }
            else if (clickedCheckbox == chkSelectSpecialKeys)
            {
                chkSelectModifiers.Checked = false;
                Key = (specialKeysCombobox.SelectedItem as CustomKey).RealName;
            }

            isModifiers = chkSelectModifiers.Checked;
            isSpecialKeys = chkSelectSpecialKeys.Checked;

            modifiersCombobox.Enabled = isModifiers;
            ChkShift.Enabled = isModifiers;
            ChkControl.Enabled = isModifiers;
            ChkAlt.Enabled = isModifiers;

            specialKeysCombobox.Enabled = isSpecialKeys;

            if (isSpecialKeys)
            {
                ChkShift.Checked = false;
                ChkControl.Checked = false;
                ChkAlt.Checked = false;
            }

            EnableAcceptButton();
        }
    }
}
