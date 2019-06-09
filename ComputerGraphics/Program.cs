using ComputerGraphics.Elements;
using ComputerGraphics.Scenario;
using ShadowEngine;
using ShadowEngine.ContentLoading;
using System;
using Tao.OpenGl;

namespace ComputerGraphics
{
    class Program
    {
        private static readonly Scene scene = new Scene();
        private static readonly Airplane airplane = new Airplane();

        static long initial_time = DateTime.Now.Ticks, frame_count = 0, final_time;
        static double fps = 0;

        static ModelContainer airplaneModel;

        static void Write(string str, float x, float y, int r, int g, int b, float size)
        {

            Gl.glPushMatrix();
            Gl.glColor3f(r, g, b);
            Glut.glutBitmapLength(Glut.GLUT_BITMAP_8_BY_13, str);
            Gl.glRasterPos2f(x, y);

            for (int i = 0; i < str.Length; i++)
            {
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_8_BY_13, str[i]);
            }

            Gl.glPopMatrix();

        }

        static void GetFrameRate()
        {
            frame_count++;
            final_time = DateTime.Now.Ticks;

            if ((final_time - initial_time) / 10000 > 1000)
            {
                fps = frame_count;
                frame_count = 0;
                initial_time = final_time;
            }

        }

        static void Render()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Write(fps + " fps", 2f, 2.3f, 1, 0, 0, 2.5f);

            scene.Render();
            airplane.Render(_3dsModel: airplaneModel);

            Glut.glutSwapBuffers();

            GetFrameRate();
        }

        static void RegisterFuncs()
        {
            int[] sceneKeys = { Glut.GLUT_KEY_UP, Glut.GLUT_KEY_DOWN, Glut.GLUT_KEY_LEFT, Glut.GLUT_KEY_RIGHT };
            int[] airplaneKeys = { Glut.GLUT_KEY_F1, Glut.GLUT_KEY_F2, Glut.GLUT_KEY_F3, Glut.GLUT_KEY_F4 };
            int[] towerskeys = { Glut.GLUT_KEY_F5 };

            KeyboardHandler.RegisterMethod(scene.KeyboardHandler, sceneKeys);
            KeyboardHandler.RegisterMethod(airplane.KeyboardHandler, airplaneKeys);
            KeyboardHandler.RegisterMethod(Scene.towersGroup.KeyboardHandler, towerskeys);

            Glut.glutPassiveMotionFunc(airplane.MouseHandler);

            Glut.glutSpecialFunc(KeyboardHandler.Handler);

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

        static void Load3dsModels() {

            airplaneModel = ContentManager.GetModelByName("airplane.3ds");
            airplaneModel.CreateDisplayList();

        }

        static void Init()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DEPTH | Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(1024, 700);
            //Glut.glutInitWindowPosition(150, 0);
            Glut.glutInitWindowPosition(150, 0);
            Glut.glutCreateWindow("Computação Gráfica");

            ContentManager.SetModelList("modelos\\");
            ContentManager.LoadModels();
            Load3dsModels();

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            SetupLight();

            Glu.gluPerspective(35.0f, 1.0, 0.001, 100.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Glu.gluLookAt(0.0, 1.0, 8.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            Gl.glClearColor(0.498039f, 1, 0.831373f, 0.0f);
            Glut.glutTimerFunc(1, airplane.Timer, 1);

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
