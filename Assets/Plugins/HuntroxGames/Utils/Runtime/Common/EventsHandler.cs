using UnityEngine.EventSystems;
using UnityEngine;

namespace HuntroxGames.Utils
{
    public abstract class EventsHandler : MonoBehaviour,IPointerDownHandler,IPointerExitHandler,IPointerUpHandler,IPointerEnterHandler
    {

        [SerializeField] public TriggerEvent triggerEvent;
        [SerializeField] private new string tag = "Untagged";
        [SerializeField] public bool usedByEventsManager = false;




		#region MonoBehavior
		void Start()
        {
            EventHandler(TriggerEvent.OnStart);
        }

        private void OnEnable()
        {
            EventHandler(TriggerEvent.OnEnable);

        }

        private void OnDisable()
        {
            EventHandler(TriggerEvent.OnDisable);
 
        }
        private void OnDestroy()
        {
            EventHandler(TriggerEvent.OnDestroy);

        }
        #endregion
        #region Pointer

        public void OnPointerDown(PointerEventData eventData)
        {
            EventHandler(TriggerEvent.OnPointerDown);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            EventHandler(TriggerEvent.OnPointerEnter);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            EventHandler(TriggerEvent.OnPointerExit);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            EventHandler(TriggerEvent.OnPointerUp);
        }
        #endregion
        #region OnMouse

        public void OnMouseDown()
        {
            EventHandler(TriggerEvent.OnPointerDown);
        }

        public void OnMouseEnter()
        {
            EventHandler(TriggerEvent.OnPointerEnter);

        }

        public void OnMouseExit()
        {
            EventHandler(TriggerEvent.OnPointerExit);
        }

        public void OnMouseUp()
        {
            EventHandler(TriggerEvent.OnPointerUp);
                
        }
        #endregion
        #region Collision
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnCollisionEnter);

            }
        }
        private void OnCollisionExit(Collision collision)
        {

            if (collision.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnCollisionExit);

            }

        }
        #endregion
        #region Collision2D
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnCollisionEnter2D);
            }

        }

        private void OnCollisionExit2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnCollisionExit2D);
            }

        }
        #endregion
        #region Trigger
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnTriggerEnter);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnTriggerExit);
            }

        }
        #endregion
        #region Trigger2D
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnTriggerEnter2D);
            }

        }
        private void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag(tag))
            {
                EventHandler(TriggerEvent.OnTriggerExit2D);
            }

        }
        #endregion





        protected abstract void EventHandler(TriggerEvent t_event);

    }
    public enum TriggerEvent
    {
        None, OnStart, OnDestroy, OnEnable, OnDisable,
        OnTriggerEnter, OnTriggerExit,
        OnTriggerEnter2D, OnTriggerExit2D,
        OnCollisionEnter, OnCollisionExit
        , OnCollisionEnter2D, OnCollisionExit2D,
         OnPointerDown, OnPointerUp, OnPointerEnter, OnPointerExit
    }
}