﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Unicorn.UIDesktop.Input
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)]
        private int type;
        [FieldOffset(4)]
        private MouseInput mi;
        [FieldOffset(4)]
        private KeyboardInput ki;
        [FieldOffset(4)]
        private readonly HardwareInput hi;

        public static Input Mouse(MouseInput mouseInput)
        {
            return new Input { type = WindowsConstants.INPUT_MOUSE, mi = mouseInput };
        }

        public static Input Keyboard(KeyboardInput keyboardInput)
        {
            return new Input { type = WindowsConstants.INPUT_KEYBOARD, ki = keyboardInput };
        }
    }
}
