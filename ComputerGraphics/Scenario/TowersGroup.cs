using ComputerGraphics.UI;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class TowersGroup : Renderable, IKeyboardControl
    {
        private static readonly ControlTower tower = new ControlTower();

        ControlTower[] towers = new ControlTower[14];

        bool chave = false;

        public TowersGroup ()
        {
            for (int i = 0; i < 14; i++)
                towers[i] = new ControlTower();

        }

        public void KeyboardHandler(int key)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_F5:
                    chave = !chave;
                    break;
            }

            Glut.glutPostRedisplay();

        }

        public override void Render()
        {
            for (int i = 0; i < 7; i++)
            {

                Gl.glPushMatrix();
                Gl.glTranslatef(4.4f - i * 1.7f, 0f, 1.5f);
                towers[i].Render(chave);
                Gl.glPopMatrix();
                Gl.glPushMatrix();
                Gl.glTranslatef(4.4f - i * 1.7f, 0f, -1.5f);
                towers[i+1].Render(chave);
                Gl.glPopMatrix();

            }
        }
    }
}
