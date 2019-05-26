using ComputerGraphics.Scenario;
using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics
{
    class Program
    {
        private static readonly Scene scene = new Scene();

        static void Render()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            scene.Render();

            Glut.glutSwapBuffers();
        }

        static void RegisterFuncs()
        {

            Glut.glutSpecialFunc(scene.KeyboardHandler);

        }

        static void SetupLight()
        {

            // Lightning set up
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            // Set lighting itensity and color
            float[] qaAmbientLight = { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] qaDifuseLight = { 0.8f, 0.8f, 0.8f, 1.0f };
            float[] qaSpecularLight = { 1.0f, 1.0f, 1.0f, 1.0f };            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, qaAmbientLight);            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, qaDifuseLight);            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, qaSpecularLight);

            // Set the light position
            float[] qaLightPosition = { 0.5f, 0.5f, 0f, 1.0f };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, qaLightPosition);

        }

        static void Init()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutCreateWindow("Computação Gráfica");

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            SetupLight();

            Glu.gluPerspective(35.0f, 1.0, 0.001, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Glu.gluLookAt(0.0, 1.0, 8.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(Render);

            RegisterFuncs();

            Glut.glutMainLoop();
        }

        static void Main(string[] args)
        {
            Init();
        }
    }
}
