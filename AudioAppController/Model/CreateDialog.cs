using AudioAppController.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioAppController.Model
{
    public class CreateDialog
    {

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
