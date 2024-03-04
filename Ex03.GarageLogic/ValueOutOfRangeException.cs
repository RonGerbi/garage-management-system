using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; }
        public float MaxValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public override string Message
        {
            get
            {
                return String.Format("Value is out of range. Valid range is {0} to {1}", MinValue, MaxValue);
            }
        }
    }
}
