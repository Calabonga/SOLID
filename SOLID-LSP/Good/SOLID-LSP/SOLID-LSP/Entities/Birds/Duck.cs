using SOLID_OCP.Demo.Helpers;

namespace SOLID_LSP.Entities.Birds
{
    /// <summary>
    /// Duck is the bird who can fly
    /// </summary>
    public class Duck : FlyingBird
    {
        /// <inheritdoc />
        public override void Fly()
        {
            Logger.LogInfo("I'm flying!");
        }
    }
}