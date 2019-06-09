using ComputerGraphics.UI;
using System;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class Scene : Renderable, IKeyboardControl
    {
        static float rotationX = 2f;
        static float rotationY = 77f;

        static float cameraVelocity = 5f;

        private static readonly Ground ground = new Ground();
        private static readonly TowersGroup towersGroup = new TowersGroup();

        public override void Render()
        {
            Gl.glPushMatrix();

            Gl.glRotatef(rotationX, 1.0f, 0.0f, 0.0f);

            Gl.glPushMatrix();

            Gl.glRotatef(rotationY, 0.0f, 1.0f, 0.0f);

            ground.Render();
            towersGroup.Render();

            Gl.glPopMatrix();

            Gl.glPopMatrix();

        }

        public void KeyboardHandler(int key)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_UP:
                    rotationX += 0.5f * cameraVelocity;
                    break;

                case Glut.GLUT_KEY_DOWN:
                    rotationX -= 0.5f * cameraVelocity;
                    break;

                case Glut.GLUT_KEY_LEFT:
                    rotationY -= 0.5f * cameraVelocity;
                    break;

                case Glut.GLUT_KEY_RIGHT:
                    rotationY += 0.5f * cameraVelocity;
                    break;

            }

            Console.WriteLine("X " + rotationX);
            Console.WriteLine("Y " + rotationY);

        }
    }
}
