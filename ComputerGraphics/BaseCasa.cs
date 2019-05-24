using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics
{
    public static class BaseCasa
    {
        public static void Render ()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Glut.glutSolidCube(0.5f);
            Gl.glPopMatrix();
        }
    }
}
