using Tao.FreeGlut;
using Tao.OpenGl;

namespace ComputerGraphics
{
    class Program
    {
        static void Render()
        {

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Chao.Render();
            Casa.Render();

            Glut.glutSwapBuffers();

        }

        static void Init()
        {

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(35.0f, 1.0, 0.001, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Glu.gluLookAt(0.0, 4.0, 4.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

        }

        static void Main(string[] args)
        {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutCreateWindow("Computação Gráfica");
            Init();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Glut.glutDisplayFunc(Render);
            Glut.glutSpecialFunc(Casa.KeyboardHandler);
            Glut.glutMainLoop();

        }
    }
}
