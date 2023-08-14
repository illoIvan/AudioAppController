using Gma.System.MouseKeyHook;

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
