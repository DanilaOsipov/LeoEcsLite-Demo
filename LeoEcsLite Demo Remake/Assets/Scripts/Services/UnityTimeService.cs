using UnityEngine;

namespace Services
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => Time.deltaTime;
        
        public float FixedDeltaTime => Time.fixedDeltaTime;
    }
}