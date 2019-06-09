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
        public static readonly TowersGroup towersGroup = new TowersGroup();
        public static readonly TreesGroup treesGroup = new TreesGroup();
        private static readonly Road road = new Road();
        private static readonly Faixa faixa = new Faixa();

        public override void Render()
        {
            Gl.glPushMatrix();

            Gl.glRotatef(rotationX, 1.0f, 0.0f, 0.0f);

            Gl.glPushMatrix();

            Gl.glRotatef(rotationY, 0.0f, 1.0f, 0.0f);

            ground.Render();
            towersGroup.Render();
            treesGroup.Render();

            Gl.glPushMatrix();
            Gl.glTranslatef(0, -0.7f, 0);
            road.Render();

            Gl.glTranslatef(0, 0.46f, 0);
            faixa.Render();
            Gl.glPopMatrix();

            Gl.glPopMatrix();

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

        }
    }
}
