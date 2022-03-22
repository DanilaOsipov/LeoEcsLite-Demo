using UnityEngine;

namespace Views
{
    public class DeviceView : MonoBehaviour
    {
        [SerializeField] private int _id;

        public int Id => _id;
    }
}