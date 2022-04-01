using UnityEngine;

namespace Services.Unity
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => Time.deltaTime;
        
        public float FixedDeltaTime => Time.fixedDeltaTime;
    }
}