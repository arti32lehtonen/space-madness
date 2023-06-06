using SpaceMadness.Structures;

namespace SpaceMadness.DamageSystem
{
    public interface IDamageable : ICountableFinite
    {
        /// <summary>
        /// Apply damage to an object.
        /// </summary>
        /// <param name="damageAmount">Amount of received damage</param>
        /// <returns>true if object is still alive and false otherwise</returns>
        public bool GetDamage(int damageAmount);
        public bool CheckIfDestroyed();
        
    }
}