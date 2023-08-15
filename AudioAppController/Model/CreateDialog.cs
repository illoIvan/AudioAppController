using AudioAppController.View.Model;
using System;
using System.Text;
using System.Windows.Forms;

namespace AudioAppController.Model
{
    public class CreateDialog
    {

        public static CustomKey OpenKeySelectionWindow(CustomKey customKey)
        {
            using (KeySelectionWindow keySelectionWindow = new KeySelectionWindow(customKey))
            {
                if (keySelectionWindow.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }

                StringBuilder finalKey = new StringBuilder();

                if (keySelectionWindow.isSpecialKeys 
                    && !string.IsNullOrEmpty(keySelectionWindow.Key))
                {
                    finalKey.Append(keySelectionWindow.Key);
                }

                if (keySelectionWindow.isModifiers 
                    && !string.IsNullOrEmpty(keySelectionWindow.Modifiers))
                {
                    finalKey.Append(keySelectionWindow.Modifiers + keySelectionWindow.Key);
                }

                if (finalKey.Length == 0)
                {
                    return null;
                }

                return CustomKeys.ConvertToCustomKey(finalKey.ToString());
            }
        }
    }
    
}
