using ComputerGraphics.UI;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class ControlTowerFoundation : Renderable
    {
        public override void Render()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Glut.glutSolidCube(0.5f);
            Gl.glPopMatrix();
        }
    }
}
