using System;

namespace SOLID_LSP.Entities.Birds
{
    /// <summary>
    /// Ostrich is the bird who can't fly
    /// </summary>
    public class Ostrich : Bird
    {
        /// <inheritdoc />
        public override void Fly()
        {
            // I cannot fly
            throw new NotImplementedException();
        }
    }
}