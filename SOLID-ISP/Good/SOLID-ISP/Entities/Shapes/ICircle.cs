using System;

namespace SOLID_LSP.Entities.Shapes
{
    public interface ICircle: ICanDraw
    {
      

        int GetRadius();
    }

    public class Circle : ICircle
    {
        public void Draw()
        {
            Console.WriteLine($"{GetType().Name} draw");
        }

        public int GetRadius()
        {
            throw new System.NotImplementedException();
        }
    }
}
