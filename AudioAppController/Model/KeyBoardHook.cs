using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAppController.Model
{
    public class KeyBoardHook
    {

        public IKeyboardMouseEvents GlobalHook { get; set; }

        public KeyBoardHook() 
        {
            GlobalHook = Hook.GlobalEvents();
        }
        public void Close()
        {
            GlobalHook.Dispose();
            GlobalHook = null;
        }
    }
}
