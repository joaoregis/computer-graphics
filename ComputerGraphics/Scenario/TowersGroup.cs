using ComputerGraphics.UI;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    class TowersGroup : Renderable
    {
        private static readonly ControlTower tower = new ControlTower();

        public override void Render()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(5f, 0f, 0.3f);
            tower.Render();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(5f, 0f, -0.6f);
            tower.Render();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(5.1f, 0f, 2f);
            tower.Render();
            Gl.glPopMatrix();

        }
    }
}
