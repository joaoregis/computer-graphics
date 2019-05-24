using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics
{
    public static class Chao
    {
        public static void Render ()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, -0.3f, 0.0f);
            Gl.glColor3f(0f, 0.392157f, 0f);
            Glut.glutSolidTorus(3.0f, 0.0f, 4, 2);
            Gl.glPopMatrix();
        }
    }
}
