using ComputerGraphics.UI;
using Tao.OpenGl;

namespace ComputerGraphics.Scenario
{
    public class Road : Renderable
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
            Gl.glColor3f(0.0f, 0.0f, 0.0f);

            Gl.glBegin(Gl.GL_QUADS);
            // Face Superior
            Cor(0, 0, 0);
            Gl.glNormal3f(0.0f, 1.0f, 0.0f); // Normal da face
            float scalar = 13.2f;
            Gl.glVertex3f(-0.5f * scalar, 0.5f, -0.5f);
            Gl.glVertex3f(0.5f * scalar, 0.5f, -0.5f);
            Gl.glVertex3f(0.5f * scalar, 0.5f, 0.5f);
            Gl.glVertex3f(-0.5f * scalar, 0.5f, 0.5f);
            Gl.glEnd();

            Gl.glPopMatrix();
        }
    }
}
