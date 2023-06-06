namespace SpaceMadness.DamageSystem
{
    public interface IShootingAspect
    {
        public bool CheckIfAllowedToShoot();

        public void ExecutePreShootRoutine();

        public void ExecutePostShootRoutine();
    }
}