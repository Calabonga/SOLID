using SOLID_OCP.Demo.Helpers;

namespace SOLID_LSP.Entities.Birds
{
    /// <summary>
    /// Eagle is the bird who can fly
    /// </summary>
    public class Eagle : FlyingBird
    {
        /// <inheritdoc />
        public override void Fly()
        {
            Logger.LogInfo("I'm flying!");
        }
    }
}