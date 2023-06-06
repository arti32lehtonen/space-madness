using System;
using UnityEngine;

namespace SpaceMadness.Structures
{
    public enum SomeEnum
    {
        first = 2,
        second = 0, 
        third = 1,
    }
    
    [Serializable]
    public class A
    {
        public int oneValue;
        public Color otherColor;
        public IMovable action;
    }
    
    public class TestNamedList : MonoBehaviour
    {
        public NamedList<A, SomeEnum> componentValue = new();

        public void Start()
        {
            foreach (var VARIABLE in componentValue)
            {
                Debug.Log(VARIABLE);
            }
            Debug.Log(componentValue.GetByField(SomeEnum.first));
            Debug.Log(componentValue.GetByField(SomeEnum.second));
            Debug.Log(componentValue.GetByField(SomeEnum.third));
        }
    }
}