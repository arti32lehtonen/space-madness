namespace SpaceMadness.Bistate
{
    public interface IBistateObject
    {
        public bool GetState();
        public void ChangeState();
        public bool CheckIfAvailableToChange();
    }
}