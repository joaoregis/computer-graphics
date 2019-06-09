using System;
using System.Collections.Generic;
using System.Linq;
using Tao.OpenGl;

namespace ComputerGraphics
{
    public static class KeyboardHandler
    {
        static List<KeyboardHandlerControlable> Methods = new List<KeyboardHandlerControlable>();

        public static void RegisterMethod(Action<int> act, int[] glutKeys)
        {
            Methods.Add(new KeyboardHandlerControlable
            {
                Action = act,
                Keys = glutKeys
            });
        }

        public static void Handler(int key, int x, int y)
        {
            var method = Methods.Where((f) => f.Keys.Contains(key)).FirstOrDefault();

            if (method != null) method.Action(key);

            Glut.glutPostRedisplay();
        }
    }
}
