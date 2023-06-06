using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace SpaceMadness.UI
{
    public class SelectElementOnEnable : MonoBehaviour
    {
        public void OnEnable()
        {
            SelectManager.Instance.SelectGameObject(gameObject);
        }
    }
}