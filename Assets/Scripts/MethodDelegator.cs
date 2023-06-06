using UnityEngine;
using UnityEngine.Events;

namespace SpaceMadness
{
    public class MethodDelegator : MonoBehaviour
    {
        public UnityEvent delegatedEvents;
 
        public void InvokeDelegateMethod()
        {
            delegatedEvents.Invoke();
        }
    }
}