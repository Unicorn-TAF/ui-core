﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Unicorn.UIDesktop.Input
{
    //BUG: KeysConverter
    /// <summary>
    /// Represents Keyboard attachment to the machine.
    /// </summary>
    public class Keyboard
    {
        private static readonly List<KeyboardInput.SpecialKeys> scanCodeDependent = new List<KeyboardInput.SpecialKeys>
                                                                               {
                                                                                   KeyboardInput.SpecialKeys.RIGHT_ALT,
                                                                                   KeyboardInput.SpecialKeys.INSERT,
                                                                                   KeyboardInput.SpecialKeys.DELETE,
                                                                                   KeyboardInput.SpecialKeys.LEFT,
                                                                                   KeyboardInput.SpecialKeys.HOME,
                                                                                   KeyboardInput.SpecialKeys.END,
                                                                                   KeyboardInput.SpecialKeys.UP,
                                                                                   KeyboardInput.SpecialKeys.DOWN,
                                                                                   KeyboardInput.SpecialKeys.PAGEUP,
                                                                                   KeyboardInput.SpecialKeys.PAGEDOWN,
                                                                                   KeyboardInput.SpecialKeys.RIGHT,
                                                                                   KeyboardInput.SpecialKeys.LWIN,
                                                                                   KeyboardInput.SpecialKeys.RWIN
                                                                               };

        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput(uint numberOfInputs, ref Input input, int structSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        private static extern ushort GetKeyState(uint virtKey);

        private readonly List<KeyboardInput.SpecialKeys> heldKeys = new List<KeyboardInput.SpecialKeys>();

        /// <summary>
        /// Use Window.Keyboard method to get handle to the Keyboard. Keyboard instance got using this method would not wait while the application
        /// is busy.
        /// </summary>
        public static readonly Keyboard Instance = new Keyboard();

        private readonly List<int> keysHeld = new List<int>();

        private Keyboard()
        {
        }

        public virtual void Enter(string keysToType)
        {
            Send(keysToType);
        }

        public virtual void Send(string keysToType)
        {
            CapsLockOn = false;
            foreach (char c in keysToType)
            {
                short key = VkKeyScan(c);
                if (c.Equals('\r')) continue;

                if (ShiftKeyIsNeeded(key)) SendKeyDown((short)KeyboardInput.SpecialKeys.SHIFT, false);
                Press(key, false);
                if (ShiftKeyIsNeeded(key)) SendKeyUp((short)KeyboardInput.SpecialKeys.SHIFT, false);
            }
        }

        public virtual void PressSpecialKey(KeyboardInput.SpecialKeys key)
        {
            Send(key, true);
        }

        public virtual void HoldKey(KeyboardInput.SpecialKeys key)
        {
            SendKeyDown((short)key, true);
            heldKeys.Add(key);
        }

        public virtual void LeaveKey(KeyboardInput.SpecialKeys key)
        {
            SendKeyUp((short)key, true);
            heldKeys.Remove(key);
        }

        private void Press(short key, bool specialKey)
        {
            SendKeyDown(key, specialKey);
            SendKeyUp(key, specialKey);
        }

        private void Send(KeyboardInput.SpecialKeys key, bool specialKey)
        {
            Press((short)key, specialKey);
        }

        private static bool ShiftKeyIsNeeded(short key)
        {
            return ((key >> 8) & 1) == 1;
        }

        private void SendKeyUp(short b, bool specialKey)
        {
            if (!keysHeld.Contains(b)) throw new Exception(string.Format("Cannot press the key {0} as its already pressed", b));
            keysHeld.Remove(b);
            KeyboardInput.KeyUpDown keyUpDown = GetSpecialKeyCode(specialKey, KeyboardInput.KeyUpDown.KEYEVENTF_KEYUP);
            SendInput(GetInputFor(b, keyUpDown));
        }

        private static KeyboardInput.KeyUpDown GetSpecialKeyCode(bool specialKey, KeyboardInput.KeyUpDown key)
        {
            if (specialKey && scanCodeDependent.Contains((KeyboardInput.SpecialKeys)key)) key |= KeyboardInput.KeyUpDown.KEYEVENTF_EXTENDEDKEY;
            return key;
        }

        private void SendKeyDown(short b, bool specialKey)
        {
            if (keysHeld.Contains(b)) throw new Exception(string.Format("Cannot press the key {0} as its already pressed", b));
            keysHeld.Add(b);
            KeyboardInput.KeyUpDown keyUpDown = GetSpecialKeyCode(specialKey, KeyboardInput.KeyUpDown.KEYEVENTF_KEYDOWN);
            SendInput(GetInputFor(b, keyUpDown));
        }

        private static void SendInput(Input input)
        {
            SendInput(1, ref input, Marshal.SizeOf(typeof(Input)));
        }

        private static Input GetInputFor(short character, KeyboardInput.KeyUpDown keyUpOrDown)
        {
            return Input.Keyboard(new KeyboardInput(character, keyUpOrDown, GetMessageExtraInfo()));
        }

        public virtual bool CapsLockOn
        {
            get
            {
                ushort state = GetKeyState((uint)KeyboardInput.SpecialKeys.CAPS);
                return state != 0;
            }
            set { if (CapsLockOn != value) Send(KeyboardInput.SpecialKeys.CAPS, true); }
        }

        public virtual KeyboardInput.SpecialKeys[] HeldKeys
        {
            get { return heldKeys.ToArray(); }
        }

        public virtual void LeaveAllKeys()
        {
            new List<KeyboardInput.SpecialKeys>(heldKeys).ForEach(LeaveKey);
        }
    }
}
