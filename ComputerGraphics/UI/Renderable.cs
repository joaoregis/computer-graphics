using ShadowEngine.ContentLoading;

namespace ComputerGraphics.UI
{
    public abstract class Renderable
    {
        public virtual void Render() { }
        public virtual void Render(bool chave) { }
        public virtual void Render(ModelContainer m) { }
    }
}
