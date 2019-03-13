using System.Collections.Generic;

namespace SOLID_LSP.Entities.Shapes
{
    public class DrawMachine
    {
        private readonly IEnumerable<ICanDraw> _items;

        public DrawMachine(IEnumerable<ICanDraw> items)
        {
            _items = items;
        }


        public void DrawAll()
        {
            foreach (var item in _items)
            {
                item.Draw();
            }
        }
    }
}
