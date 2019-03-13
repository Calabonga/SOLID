using System;

namespace SOLID_LSP.Entities.Shapes
{
    public interface ITriangle: ICanDraw
    {
    }

    public class Triangle : ITriangle
    {
        public void Draw()
        {
            Console.WriteLine($"{GetType().Name} draw");
        }
    }
}
