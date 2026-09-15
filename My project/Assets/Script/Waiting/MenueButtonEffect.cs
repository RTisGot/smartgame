using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


    public class MenuButtonEffect :
        MonoBehaviour,
        IPointerDownHandler,
        IPointerUpHandler
    {
        [SerializeField] private float pressedScale = 1.15f;
        private Vector3 normalScale;//通常のスケール

        void Awake()
        {
            normalScale = transform.localScale;
            Debug.Log("MenuButtonEffect 起動");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Button Down");
            transform.localScale = normalScale * pressedScale;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("Button Up");
            transform.localScale = normalScale;
        }
    }

