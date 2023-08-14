using AudioAppController.View.Model;
using System;
using System.Windows.Forms;

namespace AudioAppController.Model
{
    public class CreateDialog
    {

        public static CustomKey OpenKeySelectionWindow(CustomKey customKey)
        {
            KeySelectionWindow keySelectionWindow = new KeySelectionWindow(customKey);
            DialogResult result = keySelectionWindow.ShowDialog();

            if (result != DialogResult.OK)
            {
                return null;
            }

            String modifiers = keySelectionWindow.Modifiers;
            String key = keySelectionWindow.Key;

            if (string.IsNullOrEmpty(modifiers)) return null;

            CustomKey keyDialog = CustomKeys.ConvertToCustomKey(modifiers + key);

            return keyDialog;
        }
    }
}
