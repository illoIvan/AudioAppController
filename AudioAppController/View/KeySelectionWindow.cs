using AudioAppController.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AudioAppController.View.Model
{
    internal class KeySelectionWindow : Form
    {

        public String Modifiers;
        public String Key { get; set; }
        private CheckBox ChkShift { get; set; }
        private CheckBox ChkCtrl { get; set; }
        private CheckBox ChkAlt { get; set; }
        private ComboBox ComboBox { get; set; }


        private const char KEY_SEPARATOR = '+';
        private const String KEY_SHIFT = "Shift";
        private const String KEY_CONTROL = "Control";
        private const String KEY_ALT = "Alt";

        public KeySelectionWindow(String keyCombination = null) 
        {
            InitializeComponent();
            InitializeForm(keyCombination);
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

            ChkCtrl = new CheckBox();
            ChkCtrl.Text = KEY_CONTROL;
            ChkCtrl.Font = new Font(ChkCtrl.Font.FontFamily, 14);

            ChkAlt = new CheckBox();
            ChkAlt.Text = KEY_ALT;
            ChkAlt.Font = new Font(ChkAlt.Font.FontFamily, 14);

            Label lblInfo = new Label();
            lblInfo.Text = "+";
            lblInfo.Font  = new Font(ChkCtrl.Font.FontFamily, 14);
            lblInfo.AutoSize = true;

            ComboBox = new ComboBox();
            ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox.Dock = DockStyle.Fill;
            ComboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            ComboBox.Font = new Font(ChkCtrl.Font.FontFamily, 14);
            ComboBox.DropDownHeight = 250; 

            Button acceptbutton = new Button();
            acceptbutton.Text = "Accept";
            acceptbutton.AutoSize = true;
            acceptbutton.Click += btnAccept_Click;
            acceptbutton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            acceptbutton.Font = new Font(ChkCtrl.Font.FontFamily, 14);

            Array keysArray = Enum.GetValues(typeof(CustomKeys));
            List<String> keysList = new List<String>();
            foreach (var item in keysArray)
            {
                keysList.Add(item.ToString());
            }
            ComboBox.Items.AddRange(keysList.ToArray());
            ComboBox.SelectedIndex = 0;

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkShift, 0, 0);
            
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkCtrl, 0, 1);
            
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ChkAlt, 0, 2);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(lblInfo, 1, 1);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(ComboBox, 2, 1);

            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.Controls.Add(acceptbutton, 2, 3);

            tableLayoutPanel.Size = new Size(300, 200);
            this.Text = "Change Hotkey";
            this.Size = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void InitializeForm(String keyCombination)
        {
            if(keyCombination == null || keyCombination.Length == 0)
            {
                return;
            }
            int indexLastSeparator = keyCombination.LastIndexOf(KEY_SEPARATOR);
            String keySelected = keyCombination.Substring(indexLastSeparator + 1);

            int indexComboBox = ComboBox.Items.IndexOf(keySelected);
            ComboBox.SelectedIndex = indexComboBox;

            String checkBoxesKeys = keyCombination.Substring(0,indexLastSeparator);
            String[] checkboxesKeysArray = checkBoxesKeys.Split(KEY_SEPARATOR);
            for(int i = 0; i < checkboxesKeysArray.Length; i++)
            {
                String key = checkboxesKeysArray[i];
                if (key.Equals(KEY_SHIFT, StringComparison.OrdinalIgnoreCase))
                {
                    ChkShift.Checked = true;
                }
                else if (key.Equals(KEY_CONTROL, StringComparison.OrdinalIgnoreCase))
                {
                    ChkCtrl.Checked = true;
                }
                else if (key.Equals(KEY_ALT, StringComparison.OrdinalIgnoreCase))
                {
                    ChkAlt.Checked = true;
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            buildCombination();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buildCombination()
        {
            String key = "";
            if (ChkShift.Checked)
            {
                key += KEY_SHIFT + KEY_SEPARATOR;
            }
            if (ChkCtrl.Checked)
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
            Key = comboBox.SelectedItem.ToString();
        }
    }
}
