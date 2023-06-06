namespace SpaceMadness.Bistate
{
    public interface IBistateStateApplier
    {
        public void ApplyBeforeTransition(bool newState);
        public void ApplyAfterTransition(bool newState);
    }
}