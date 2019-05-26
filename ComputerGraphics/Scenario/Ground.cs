using ComputerGraphics.UI;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class Ground : Renderable
    {
        private static readonly ControlTower tower = new ControlTower();

        public override void Render()
        {
            Gl.glPushMatrix();

            // Set material properties
            float[] qaGreen = { 0f, 1f, 0f, 1f };
            float[] qaBlack = { 0f, 0f, 0f, 0.5f };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, qaGreen);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, qaGreen);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, qaBlack);

            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, -0.3f, 0.0f);
            Gl.glColor3f(0f, 0.392157f, 0f);
            Glut.glutSolidTorus(7.0f, 0.0f, 4, 2);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }
    }
}
