using System;

namespace SOLID_LSP.Entities.Shapes
{
    public interface ISquare:ICanDraw
    {
    }

    public class Square : ISquare
    {
        public void Draw()
        {
            Console.WriteLine($"{GetType().Name} draw");
        }
    }
}
