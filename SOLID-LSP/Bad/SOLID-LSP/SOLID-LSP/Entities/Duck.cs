using System;
using SOLID_OCP.Demo.Helpers;

namespace SOLID_LSP.Entities
{
    /// <summary>
    /// Duck is the bird who can fly
    /// </summary>
    public class Duck : Bird
    {
        /// <inheritdoc />
        public override void Fly()
        {
            Logger.LogInfo("I'm flying!");
        }
    }
}