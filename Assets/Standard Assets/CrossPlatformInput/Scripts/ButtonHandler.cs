using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour , IPointerExitHandler
    {
        public bool CanClick { get; set; } = true;
        public bool CanControl { get; set; } = true;
        public string Name;
        public UnityEvent OnButtonClick;
        public static Action<bool> DisableButton;
        private void Start()
        {
            DisableButton += DisableButtonClick;
        }
        private void OnDestroy()
        {
            DisableButton -= DisableButtonClick;
        }

        public void SetDownState()
        {
            if (!CanControl)
                return;
            CrossPlatformInputManager.SetButtonDown(Name);
            OnButtonClick?.Invoke();

        }

        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Action()
        {
            if (CanClick)
            {
                CanClick = false;
                //CrossPlatformInputManager.SetButtonDown(Name);
                OnButtonClick?.Invoke();
            }
        }    

        public void OnPointerExit(PointerEventData eventData)
        {
            CrossPlatformInputManager.SetButtonUp(Name);
        }
        public void DisableButtonClick(bool disable)
        {
            if (disable)
            {
                CanClick = false;
            }
            else
            {
                CanClick = true;
            }
        }
    }
}
