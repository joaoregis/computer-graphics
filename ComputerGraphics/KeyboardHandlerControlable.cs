using System;

namespace ComputerGraphics
{
    public class KeyboardHandlerControlable
    {
        public Action<int> Action { get; set; }
        public int[] Keys { get; set; }
    }
}
