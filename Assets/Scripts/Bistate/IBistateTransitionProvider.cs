namespace SpaceMadness.Bistate
{
    public interface IBistateTransitionProvider
    {
        public void StartTransition(bool newState);
        public bool CheckIfDuringTransition();
    }
}