using System;
using System.Collections.Generic;
using System.Linq;

namespace AudioAppController.Model
{
    public static class CustomKeys
    {
        public static String KEY_SEPARATOR = "+";

        public static CustomKey Left { get; } = new CustomKey("Left", "Left Arrow");
        public static CustomKey Up { get; } = new CustomKey("Up", "Up Arrow");
        public static CustomKey Right { get; } = new CustomKey("Right", "Right Arrow");
        public static CustomKey Down { get; } = new CustomKey("Down", "Down Arrow");
        public static CustomKey Back { get; } = new CustomKey("Back", "Backspace");
        public static CustomKey Enter { get; } = new CustomKey("Enter", "Enter");
        public static CustomKey Escape { get; } = new CustomKey("Escape", "Escape");
        public static CustomKey Space { get; } = new CustomKey("Space", "Spacebar");
        public static CustomKey Insert { get; } = new CustomKey("Insert", "Insert");
        public static CustomKey Home { get; } = new CustomKey("Home", "Home");
        public static CustomKey PageUp { get; } = new CustomKey("PageUp", "Page UP");
        public static CustomKey Delete { get; } = new CustomKey("Delete", "Delete");
        public static CustomKey End { get; } = new CustomKey("End", "End");
        public static CustomKey PageDown { get; } = new CustomKey("PageDown", "Page Down");
        public static CustomKey PrintScreen { get; } = new CustomKey("PrintScreen", "PrintScreen");
        public static CustomKey D0 { get; } = new CustomKey("D0", "0");
        public static CustomKey D1 { get; } = new CustomKey("D1", "1");
        public static CustomKey D2 { get; } = new CustomKey("D2", "2");
        public static CustomKey D3 { get; } = new CustomKey("D3", "3");
        public static CustomKey D4 { get; } = new CustomKey("D4", "4");
        public static CustomKey D5 { get; } = new CustomKey("D5", "5");
        public static CustomKey D6 { get; } = new CustomKey("D6", "6");
        public static CustomKey D7 { get; } = new CustomKey("D7", "7");
        public static CustomKey D8 { get; } = new CustomKey("D8", "8");
        public static CustomKey D9 { get; } = new CustomKey("D9", "9");
        public static CustomKey A { get; } = new CustomKey("A", "A");
        public static CustomKey B { get; } = new CustomKey("B", "B");
        public static CustomKey C { get; } = new CustomKey("C", "C");
        public static CustomKey D { get; } = new CustomKey("D", "D");
        public static CustomKey E { get; } = new CustomKey("E", "E");
        public static CustomKey F { get; } = new CustomKey("F", "F");
        public static CustomKey G { get; } = new CustomKey("G", "G");
        public static CustomKey H { get; } = new CustomKey("H", "H");
        public static CustomKey I { get; } = new CustomKey("I", "I");
        public static CustomKey J { get; } = new CustomKey("J", "J");
        public static CustomKey K { get; } = new CustomKey("K", "K");
        public static CustomKey L { get; } = new CustomKey("L", "L");
        public static CustomKey M { get; } = new CustomKey("M", "M");
        public static CustomKey N { get; } = new CustomKey("N", "N");
        public static CustomKey O { get; } = new CustomKey("O", "O");
        public static CustomKey P { get; } = new CustomKey("P", "P");
        public static CustomKey Q { get; } = new CustomKey("Q", "Q");
        public static CustomKey R { get; } = new CustomKey("R", "R");
        public static CustomKey S { get; } = new CustomKey("S", "S");
        public static CustomKey T { get; } = new CustomKey("T", "T");
        public static CustomKey U { get; } = new CustomKey("U", "U");
        public static CustomKey V { get; } = new CustomKey("V", "V");
        public static CustomKey W { get; } = new CustomKey("W", "W");
        public static CustomKey X { get; } = new CustomKey("X", "X");
        public static CustomKey Y { get; } = new CustomKey("Y", "Y");
        public static CustomKey Z { get; } = new CustomKey("Z", "Z");
        public static CustomKey Oemplus { get; } = new CustomKey("Oemplus", "Plus");
        public static CustomKey Oemcomma { get; } = new CustomKey("Oemcomma", "Comma(,)");
        public static CustomKey OemMinus { get; } = new CustomKey("OemMinus", "Minux(-)");
        public static CustomKey OemPeriod { get; } = new CustomKey("OemPeriod", "Period(.)");
        public static CustomKey LessThan { get; } = new CustomKey("OemBackslash", "Less Than (<)");
        public static CustomKey NumPad0 { get; } = new CustomKey("NumPad0", "NumPad0");
        public static CustomKey NumPad1 { get; } = new CustomKey("NumPad1", "NumPad1");
        public static CustomKey NumPad2 { get; } = new CustomKey("NumPad2", "NumPad2");
        public static CustomKey NumPad3 { get; } = new CustomKey("NumPad3", "NumPad3");
        public static CustomKey NumPad4 { get; } = new CustomKey("NumPad4", "NumPad4");
        public static CustomKey NumPad5 { get; } = new CustomKey("NumPad5", "NumPad5");
        public static CustomKey NumPad6 { get; } = new CustomKey("NumPad6", "NumPad6");
        public static CustomKey NumPad7 { get; } = new CustomKey("NumPad7", "NumPad7");
        public static CustomKey NumPad8 { get; } = new CustomKey("NumPad8", "NumPad8");
        public static CustomKey NumPad9 { get; } = new CustomKey("NumPad9", "NumPad9");
        public static CustomKey Divide { get; } = new CustomKey("Divide", "Divide(/)");
        public static CustomKey Multiply { get; } = new CustomKey("Multiply", "Multiply(*)");
        public static CustomKey Subtract { get; } = new CustomKey("Subtract", "Subtract(-)");
        public static CustomKey F1 { get; } = new CustomKey("F1", "F1");
        public static CustomKey F2 { get; } = new CustomKey("F2", "F2");
        public static CustomKey F3 { get; } = new CustomKey("F3", "F3");
        public static CustomKey F4 { get; } = new CustomKey("F4", "F4");
        public static CustomKey F5 { get; } = new CustomKey("F5", "F5");
        public static CustomKey F6 { get; } = new CustomKey("F6", "F6");
        public static CustomKey F7 { get; } = new CustomKey("F7", "F7");
        public static CustomKey F8 { get; } = new CustomKey("F8", "F8");
        public static CustomKey F9 { get; } = new CustomKey("F9", "F9");
        public static CustomKey F10 { get; } = new CustomKey("F10", "F10");
        public static CustomKey F11 { get; } = new CustomKey("F11", "F11");
        public static CustomKey F12 { get; } = new CustomKey("F12", "F12");

        //virtual keys
        public static CustomKey F13 { get; } = new CustomKey("F13", "F13");
        public static CustomKey F14 { get; } = new CustomKey("F14", "F14");
        public static CustomKey F15 { get; } = new CustomKey("F15", "F15");
        public static CustomKey F16 { get; } = new CustomKey("F16", "F16");
        public static CustomKey F17 { get; } = new CustomKey("F17", "F17");
        public static CustomKey F18 { get; } = new CustomKey("F18", "F18");
        public static CustomKey F19 { get; } = new CustomKey("F19", "F19");
        public static CustomKey F20 { get; } = new CustomKey("F20", "F20");
        public static CustomKey F21 { get; } = new CustomKey("F21", "F21");
        public static CustomKey F22 { get; } = new CustomKey("F22", "F22");
        public static CustomKey F23 { get; } = new CustomKey("F23", "F23");
        public static CustomKey F24 { get; } = new CustomKey("F24", "F24");

        //modifiers
        public static CustomKey Alt { get; } = new CustomKey("Alt", "Alt");
        public static CustomKey Control { get; } = new CustomKey("Control", "Control");
        public static CustomKey Shift { get; } = new CustomKey("Shift", "Shift");
        public static List<CustomKey> GetAllKeys()
        {
            return new List<CustomKey>
            {
                Escape,PrintScreen,

                Insert, Home,PageUp,
                Delete, End,PageDown,

                Left, Up, Right, Down,

                LessThan,

                D0, D1, D2, D3, D4, D5, D6, D7, D8, D9,

                A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
                Back,Enter,Space,

                Oemplus, Oemcomma, OemMinus, OemPeriod,

                Multiply, Subtract,Divide,

                NumPad0, NumPad1, NumPad2, NumPad3, NumPad4,
                NumPad5, NumPad6, NumPad7, NumPad8, NumPad9, 

                F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12
            };
        }
        public static List<CustomKey> GetAllModifiers()
        {
            return new List<CustomKey> { Shift, Control, Alt };
        }

        public static List<CustomKey> GetAllSpecialKeys()
        {
            return new List<CustomKey> { 
                F13, F14, F15, F16, F17, F18, F19, F20, F21, F22, F23, F24 
            };
        }

        public static List<String> GetDisplayNameKeys()
        {
            return GetAllKeys().Select(key => key.DisplayName).ToList();
        }
        public static List<String> GetRealNameKeys()
        {
            return GetAllKeys().Select(key => key.RealName).ToList();
        }
        public static CustomKey GetCustomKeyByRealName(String key)
        {
            if (key == null || key.Length == 0) return null;

            if (IsModifier(key))
            {
                return GetAllModifiers().FirstOrDefault(k => k.RealName.Equals(key));
            }

            if (IsSpecialKey(key))
            {
                return GetAllSpecialKeys().FirstOrDefault(k => k.RealName.Equals(key));
            }

            return GetAllKeys().FirstOrDefault(k => k.RealName.Equals(key));
            
        }
        public static bool IsModifier(string input)
        {
            List<CustomKey> keys = GetAllModifiers();

            return keys.Exists(k => k.RealName.Equals(input));
        }

        public static bool IsSpecialKey(string input)
        {
            List<CustomKey> keys = GetAllSpecialKeys();

            return keys.Exists(k => k.RealName.Equals(input));
        }

        public static CustomKey ConvertToCustomKey(string keyInput)
        {
            if (string.IsNullOrEmpty(keyInput))
            {
                return null;
            }

            string[] keyStrings = keyInput.Split('+');
            List<CustomKey> modifiers = new List<CustomKey>();
            List<CustomKey> keys = new List<CustomKey>();

            foreach (string keyString in keyStrings)
            {
                string trimmedKey = keyString.Trim();
                CustomKey customKey = GetCustomKeyByRealName(trimmedKey);

                if (IsModifier(trimmedKey))
                {
                    modifiers.Add(customKey);
                }
                else
                {
                    keys.Add(customKey);
                }
            }

            if (keys.Count == 0 && modifiers.Count == 0)
            {
                return null;
            }

            string strModifiersRealName = string.Join(KEY_SEPARATOR, modifiers.Select(k => k.RealName));
            string strModifiersDisplayName = string.Join(KEY_SEPARATOR, modifiers.Select(k => k.DisplayName));

            string strKeysRealName = string.Join(KEY_SEPARATOR, keys.Select(k => k.RealName));
            string strKeysDisplayName = string.Join(KEY_SEPARATOR, keys.Select(k => k.DisplayName));

            string strRealName = modifiers.Count > 0
                ? $"{strModifiersRealName}{KEY_SEPARATOR}{strKeysRealName}"
                : strKeysRealName;

            string strDisplayName = modifiers.Count > 0
                ? $"{strModifiersDisplayName}{KEY_SEPARATOR}{strKeysDisplayName}"
                : strKeysDisplayName;

            return new CustomKey(strRealName, strDisplayName);
        }
    }
}
