using Other;
using UnityEngine;

namespace Services
{
    public class InputService : IInputService
    {
        public ButtonStatus LeftMouseButtonStatus
        {
            get
            {
                if (Input.GetButtonDown("Fire1")) return ButtonStatus.Down;
                if (Input.GetButton("Fire1")) return ButtonStatus.Held;
                if (Input.GetButtonUp("Fire1")) return ButtonStatus.Up;
                return ButtonStatus.None;
            }
        }

        public Vector3 MousePosition => Input.mousePosition;
    }
}