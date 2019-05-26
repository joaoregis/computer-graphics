using ComputerGraphics.UI;
using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class Scene : Renderable, IKeyboardControl
    {
        static float rotationX = -9f;

        private static readonly Ground ground = new Ground();
        private static readonly ControlTower tower = new ControlTower();

        public override void Render()
        {
            Gl.glPushMatrix();

            Gl.glRotatef(rotationX, 1.0f, 0.0f, 0.0f);

            ground.Render();
            tower.Render();

            Gl.glPopMatrix();

        }

        public void KeyboardHandler(int key, int x, int y)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_UP:
                    rotationX += 0.5f;
                    break;

                case Glut.GLUT_KEY_DOWN:
                    rotationX -= 0.5f;
                    break;
            }

            Console.WriteLine(rotationX);

            Glut.glutPostRedisplay();

        }
    }
}
