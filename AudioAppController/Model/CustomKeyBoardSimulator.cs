using WindowsInput;

namespace AudioAppController.Model
{
    public class CustomKeyBoardSimulator
    {
        private InputSimulator Simulator;
        public CustomKeyBoardSimulator() 
        {
            Simulator = new InputSimulator();
        }
        public void SimulateKey(VirtualKeyCode virtualKeyCode)
        {
            Simulator.Keyboard.ModifiedKeyStroke(null, virtualKeyCode);
        }
    }
}
