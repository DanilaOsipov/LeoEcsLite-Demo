using UnityEngine;

namespace Views
{
    public class DeviceOperatorView : MonoBehaviour
    {
        [SerializeField] private int _id;

        public int Id => _id;
    }
}