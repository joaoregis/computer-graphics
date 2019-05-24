using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics
{
    public static class Casa
    {
        static float rotation = 0.0f;

        public static void Render ()
        {
            Gl.glPushMatrix();
            Gl.glRotatef(rotation, 1.0f, 0.0f, 0.0f);

            BaseCasa.Render();
            Telhado.Render();

            Gl.glPopMatrix();

        }

        public static void KeyboardHandler(int key, int x, int y)
        {

            switch (key)
            {
                case Glut.GLUT_KEY_UP:
                    rotation += 5;
                    break;

                case Glut.GLUT_KEY_DOWN:
                    rotation -= 5;
                    break;
            }

            Glut.glutPostRedisplay();

        }
    }
}
