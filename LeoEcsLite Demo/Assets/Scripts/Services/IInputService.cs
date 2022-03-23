using Other;
using UnityEngine;

namespace Services
{
    public interface IInputService
    {
        ButtonStatus LeftMouseButtonStatus { get; }
        Vector3 MousePosition { get; }
    }
}