using ComputerGraphics.UI;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class ControlTower : Renderable
    {
        private static readonly ControlTowerRoof roof = new ControlTowerRoof();
        private static readonly ControlTowerFoundation foundation = new ControlTowerFoundation();

        public override void Render()
        {
            Gl.glPushMatrix();

            // Set material properties
            float[] qaRed = { 1f, 0f, 0f, 1f };
            float[] qaBlack = { 0f, 0f, 0f, 0.5f };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, qaBlack);

            Gl.glPushMatrix();

            Gl.glRotatef(-90, 1.0f, 0.0f, 0.0f);
            Gl.glTranslatef(0f, 0f, -0.07f);

            foundation.Render();
            roof.Render();

            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }
    }
}
