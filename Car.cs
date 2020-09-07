using System;

namespace SerializationDEMO
{
    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();

        public bool IsHatchBack;
    }
}
