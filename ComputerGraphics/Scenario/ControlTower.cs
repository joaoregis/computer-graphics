using ComputerGraphics.UI;
using System;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class ControlTower : Renderable
    {
        private static readonly ControlTowerRoof roof = new ControlTowerRoof();
        private static readonly ControlTowerFoundation foundation = new ControlTowerFoundation();

        static Random r = new Random();

        float cor1 = 0;
        float cor2 = 0;
        float cor3 = 0;

        public ControlTower()
        {
            cor1 = float.Parse(r.NextDouble().ToString());
            cor2 = float.Parse(r.NextDouble().ToString());
            cor3 = float.Parse(r.NextDouble().ToString());
        }

        void Cor(float r, float g, float b)
        {
            float[] qaRed = { r, g, b, 1f };
            float[] qaBlack = { 0f, 0f, 0f, 0.5f };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, qaBlack);
        }

        public override void Render(bool chave)
        {
            Gl.glPushMatrix();

            Gl.glRotatef(-90, 1.0f, 0.0f, 0.0f);
            Gl.glTranslatef(0f, 0f, -0.07f);

            Gl.glPushMatrix();
            Cor(1, 0.870588f, 0.678431f);
            foundation.Render();
            Gl.glPopMatrix();

            Gl.glPushMatrix();

            if (chave)
            {
                cor1 = float.Parse(r.NextDouble().ToString());
                cor1 = float.Parse(r.NextDouble().ToString());
                cor1 = float.Parse(r.NextDouble().ToString());
            }

            Cor(
               cor1,
               cor2,
               cor3
            );

            roof.Render();
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

    }
}
