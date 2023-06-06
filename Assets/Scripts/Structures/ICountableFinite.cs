namespace SpaceMadness.Structures
{
    public interface ICountableFinite
    {
        public int GetCurrentValue();
        public int GetMaxValue();
        public void ChangeCurrentValue(int changeModifier);
    }
}