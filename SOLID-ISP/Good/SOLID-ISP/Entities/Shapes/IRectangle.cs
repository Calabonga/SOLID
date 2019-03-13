using System;

namespace SOLID_LSP.Entities.Shapes
{
    public interface IRectangle: ICanDraw
    {
    }

    public class Rectangle : IRectangle
    {
        public void Draw()
        {
            Console.WriteLine($"{GetType().Name} draw");
        }
    }
}
