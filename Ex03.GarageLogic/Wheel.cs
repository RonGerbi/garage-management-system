using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        private const string k_ManufacturerNameMessage = "What is the name of the manufacturer of the wheels?";
        private const string k_CurrentAirPressureMessage = "How much air pressure is in each of the wheels?";

        public Wheel()
        {
        }

        internal string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        internal float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (isValidAirAmount(value))
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, getMissingAirPressureInWheel());
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }

        public void InflateFully()
        {
            CurrentAirPressure += getMissingAirPressureInWheel();
        }

        private float getMissingAirPressureInWheel()
        {
            return m_MaxAirPressure - m_CurrentAirPressure;
        }

        private bool isValidAirAmount(float i_AirAmountToAdd)
        {
            return i_AirAmountToAdd >= 0 && i_AirAmountToAdd <= m_MaxAirPressure;
        }

        public override string ToString()
        {
            string wheelDescription = String.Format("Air pressure: {0} / {1}, Manufacturer: {2}", m_CurrentAirPressure,  m_MaxAirPressure, m_ManufacturerName);

            return wheelDescription;
        }

        internal virtual void AddMissingInformation(Dictionary<string, Type> io_MissingInformation)
        {
            io_MissingInformation.Add(k_ManufacturerNameMessage, typeof(string));
            io_MissingInformation.Add(k_CurrentAirPressureMessage, typeof(float));
        }

        internal virtual bool FillWheelInformation(KeyValuePair<string, string> i_InformationPiece)
        {
            bool hasFilledInformationPiece = true;

            if (i_InformationPiece.Key == k_ManufacturerNameMessage)
            {
                ManufacturerName = i_InformationPiece.Value;
            }
            else if (i_InformationPiece.Key == k_CurrentAirPressureMessage)
            {
                float airPressure;

                hasFilledInformationPiece = float.TryParse(i_InformationPiece.Value, out airPressure);

                if (hasFilledInformationPiece)
                {
                    CurrentAirPressure = airPressure;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                hasFilledInformationPiece = false;
            }

            return hasFilledInformationPiece;
        }
    }
}
