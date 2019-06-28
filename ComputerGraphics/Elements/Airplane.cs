using ComputerGraphics.UI;
using ShadowEngine.ContentLoading;
using System;
using Tao.OpenGl;

namespace ComputerGraphics.Elements
{
    public class Airplane : Renderable, IKeyboardControl
    {
        const float scale = 0.3f;
        static float airplaneHeight = 3.35f;
        static float wingInclination = 0.0f;
        static float velocity = 1.5f;
        static float movementVelocityZ = -0.01f;
        static float movementVelocityY = -0.01f;
        static float movementVelocityX = -0.1f;

        static float mouseX = 0.0f;
        static float mouseY = 0.0f;

        static float tz = 0.0f;
        static float ty = 0.0f;
        static float tx = 0.0f;

        public void KeyboardHandler(int key)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_F1:
                    wingInclination += 0.5f * velocity;
                    break;

                case Glut.GLUT_KEY_F2:
                    wingInclination -= 0.5f * velocity;
                    break;

                case Glut.GLUT_KEY_F3:
                    airplaneHeight += 0.1f * velocity;
                    break;

                case Glut.GLUT_KEY_F4:
                    airplaneHeight -= 0.1f * velocity;
                    break;
            }

            //Console.WriteLine("Height: " + airplaneHeight);

        }

        public void MouseHandler(int x, int y)
        {
            float scalar = 0.3f;

            mouseX = x * scalar - 150;
            mouseY = y * scalar - 120;

            if (mouseY >= 15) mouseY = 15;
            if (mouseY <= -15) mouseY = -15;

            //if (mouseX >= 20) mouseX = 20;
            //if (mouseX <= -20) mouseX = -20;

            //Console.WriteLine(mouseX);

            Glut.glutPostRedisplay();
                
            //Console.WriteLine("X: " + mouseX + "Y: " + mouseY);
        }

        public void Timer(int value)
        {
            // Muda a direção quando chega na borda esquerda ou direita
            if (tz < -30.7) tz = 13;

            // Muda a direção quando chega na borda superior ou inferior
            if (ty > 3.7 || ty < 0) movementVelocityY = -movementVelocityY;

            // Move o quadrado
            tz += movementVelocityZ;
            ty += movementVelocityY;
            tx += movementVelocityX;

            //Console.WriteLine("TZ: " + tz + " TY: " + ty + " TX: " + tx);

            // Redesenha o quadrado com as novas coordenadas
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(1, Timer, 1);
        }
        public override void Render(ModelContainer _3dsModel)
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0f, tz);

            Gl.glPushMatrix();


            float[] qaRed = { 0.156863f, 0.156863f, 0.156863f, 1f };
            float[] qaBlack = { 0f, 0f, 0f, 0.5f };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, qaBlack);



            Gl.glScalef(scale, scale, scale);
            Gl.glPushMatrix();
            Gl.glRotatef(mouseY, 1f, 0f, 0f);
            Gl.glRotatef(mouseX, 0f, 1f, 0f);
            Gl.glRotatef(wingInclination, 0f, 0f, 1f);
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, airplaneHeight, 0.0f);
            _3dsModel.Draw();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }
    }
}
