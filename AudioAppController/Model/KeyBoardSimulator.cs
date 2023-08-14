using WindowsInput;

namespace AudioAppController.Model
{
    public class KeyBoardSimulator
    {
        private InputSimulator Simulator;
        public KeyBoardSimulator() 
        {
            Simulator = new InputSimulator();
        }
        public void SimulateKey(VirtualKeyCode virtualKeyCode)
        {
            Simulator.Keyboard.ModifiedKeyStroke(null, virtualKeyCode);
        }
    }
}
