using ComputerGraphics.UI;
using System;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class TreesGroup : Renderable
    {
        private static readonly Tree tree = new Tree();

        public override void Render()
        {
            for (int i = 0; i < 7; i++)
            {

                Gl.glPushMatrix();
                Gl.glTranslatef(-5f + i * 1.7f, -0.2f, -0.8f);
                tree.Render();
                Gl.glPopMatrix();
                Gl.glPushMatrix();
                Gl.glTranslatef(-5f + i * 1.7f, -0.2f, 0.8f);
                tree.Render();
                Gl.glPopMatrix();

            }
        }
    }
}
