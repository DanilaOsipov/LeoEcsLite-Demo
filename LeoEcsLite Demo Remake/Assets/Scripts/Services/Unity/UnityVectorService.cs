using Other;
using UnityEngine;

namespace Services.Unity
{
    public class UnityVectorService : IVectorService
    {
        private static readonly UnityVector UnityDownVector = new UnityVector(Vector3.down);

        public IVector DownVector => UnityDownVector;
    }
}