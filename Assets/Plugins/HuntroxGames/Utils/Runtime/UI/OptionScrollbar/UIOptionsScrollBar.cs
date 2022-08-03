using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

namespace HuntroxGames.Utils.UI
{
    [AddComponentMenu("UI/Options Scrollbar", 35)]
    [RequireComponent(typeof(RectTransform))]
    public class UIOptionsScrollBar : MonoBehaviour, IPointerClickHandler, ISubmitHandler, ICancelHandler
    {

        [Serializable]
        /// <summary>
        /// UnityEvent callback for when current option is changed.
        /// </summary>
        public class UIOptionsListEvent : UnityEvent<int> { }



        [Serializable]
        /// <summary>
        /// Class to store the text of a single option in the  list.
        /// </summary>
        public class Options
        {

            [SerializeField] private string m_Text;
            /// <summary>
            /// The text associated with the option.
            /// </summary>
            public string text { get { return m_Text; } set { m_Text = value; } }
            public Options() { }

            public Options(string text)
            {
                this.text = text;
            }
        }


        [SerializeField] private UIOptionsListEvent m_OnValueChanged = new UIOptionsListEvent();
        public UIOptionsListEvent onValueChanged { get { return m_OnValueChanged; } set { m_OnValueChanged = value; } }


        public bool loop = true;

        [Serializable]
        public class OptionDataList
        {
            [SerializeField]
            private List<Options> m_Options;

            /// <summary>
            /// The list of options for the dropdown list.
            /// </summary>
            public List<Options> options { get { return m_Options; } set { m_Options = value; } }


            public OptionDataList()
            {
                options = new List<Options>();
            }
        }

        [SerializeField] private OptionDataList m_Options = new OptionDataList();


        public List<Options> options
        {
            get { return m_Options.options; }
            set { m_Options.options = value; RefreshShownValue(); }
        }
        private static Options s_NoOptionData = new Options();


        [SerializeField]
        private TMP_Text m_CaptionText;

        /// <summary>
        /// The Text component to hold the text of the currently selected option.
        /// </summary>
        public TMP_Text captionText { get { return m_CaptionText; } set { m_CaptionText = value; RefreshShownValue(); } }


        [SerializeField]
        private int m_Value;

        public int Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                SetValue(value);
            }
        }



       [SerializeField] private Button m_Next;
       [SerializeField] private Button m_Previous;

        public void AddOptions(List<string> options)
        {
            for (int i = 0; i < options.Count; i++)
                this.options.Add(new Options(options[i]));

            RefreshShownValue();
        }
        public void AddOptions(List<Options> options)
        {
            this.options.AddRange(options);
            RefreshShownValue();
        }

        public void ClearOptions()
        {
            options.Clear();
            m_Value = 0;
            RefreshShownValue();
        }





        public void RefreshShownValue()
        {
            Options data = s_NoOptionData;

            if (options.Count > 0 && m_Value >= 0)
                data = options[Mathf.Clamp(m_Value, 0, options.Count - 1)];

            if (m_CaptionText)
            {
                if (data != null && data.text != null)
                    m_CaptionText.text = data.text;
                else
                    m_CaptionText.text = "";
            }
            if (!loop)
            {
                m_Previous.interactable = m_Value > 0;
                m_Next.interactable = m_Value < options.Count - 1;
            }
            else
            {
                m_Previous.interactable = true;
                m_Next.interactable = true;
            }
        }



        public void SetValue(int value, bool sendCallback = true)
        {
            if (Application.isPlaying && (value == m_Value || options.Count == 0))
                return;

            m_Value = Mathf.Clamp(value,0, options.Count - 1);
            RefreshShownValue();

            if (sendCallback)
            {
                // Notify all listeners
                UISystemProfilerApi.AddMarker("OptionsScrollbar.value", this);
                m_OnValueChanged.Invoke(m_Value);
            }
        }



        void OnNextButton()
        {

            Value = (m_Value + 1) % m_Options.options.Count;
            RefreshShownValue();
        }
        void OnPreviousButton()
        {
            Value = ((m_Value - 1) < 0 ? m_Options.options.Count - 1 : (m_Value - 1));
            RefreshShownValue();
        }


        private void Awake()
        {
            
        }
        private void Start()
        {
            if (m_Next)
                m_Next.onClick.AddListener(OnNextButton);
            if (m_Previous)
                m_Previous.onClick.AddListener(OnPreviousButton);
            RefreshShownValue();
        }

        private void OnDestroy()
        {
            m_Next.onClick.RemoveAllListeners();
            m_Previous.onClick.RemoveAllListeners();
        }

        public void OnCancel(BaseEventData eventData)
        {
            //throw new NotImplementedException();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //throw new NotImplementedException();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            //throw new NotImplementedException();
        }
    }
}