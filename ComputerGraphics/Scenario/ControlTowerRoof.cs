using ComputerGraphics.UI;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class ControlTowerRoof : Renderable
    {
        public override void Render()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, 0.25f);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Glut.glutSolidCone(0.4f, 0.7f, 4, 4);
            Gl.glPopMatrix();
        }
    }
}
