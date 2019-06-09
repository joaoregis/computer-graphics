using ComputerGraphics.UI;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class Tree : Renderable
    {
        void Cor(float r, float g, float b)
        {
            float[] qaRed = { r, g, b, 1f };
            float[] qaBlack = { 0f, 0f, 0f, 0.5f };
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, qaRed);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, qaBlack);
        }

        public override void Render()
        {
            Gl.glPushMatrix();

            Gl.glRotatef(-90, 1.0f, 0.0f, 0.0f);

            Gl.glPushMatrix();

            Gl.glPushMatrix();
            Cor(0.647059f, 0.164706f, 0.164706f);
            Gl.glTranslatef(0, 0, -.1f);
            Glut.glutSolidCube(0.1f);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Cor(0.647059f, 0.164706f, 0.164706f);
            Gl.glTranslatef(0, 0, 0);
            Glut.glutSolidCube(0.1f);
            Gl.glPopMatrix();

            Cor(0.678431f, 1, 0.184314f);
            Glut.glutSolidCone(0.2f, 0.5, 10, 10);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }
    }
}
