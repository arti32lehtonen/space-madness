using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceMadness.UI
{
    public class SelectOnPointerOver : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            SelectManager.Instance.SelectGameObject(gameObject);
        }
    }
}