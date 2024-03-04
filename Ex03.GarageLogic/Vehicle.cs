using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected EnergySource m_EnergySource;
        protected readonly List<Wheel> m_Wheels;
        protected const string k_ModelNameMessage = "What is the vehicle's model name?";

        public Vehicle()
        {
            m_Wheels = new List<Wheel>();
        }

        protected bool TryFillInformationForWheels(KeyValuePair<string, string> i_InformationPiece)
        {
            bool hasFilledAllWheels = true;

            foreach (Wheel wheel in m_Wheels)
            {
                if (!wheel.FillWheelInformation(i_InformationPiece))
                {
                    hasFilledAllWheels = false;
                }
            }

            return hasFilledAllWheels;
        }

        internal string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }

        internal EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
            set
            {
                m_EnergySource = value;
            }
        }

        internal List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        internal void AddWheel(Wheel i_Wheel)
        {
            m_Wheels.Add(i_Wheel);
        }

        internal void InflateWheels()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateFully();
            }
        }

        public static bool operator==(Vehicle i_FirstVehicle, Vehicle i_SecondVehicle)
        {
            return i_FirstVehicle.m_LicenseNumber == i_SecondVehicle.m_LicenseNumber;
        }

        public static bool operator!=(Vehicle i_FirstVehicle, Vehicle i_SecondVehicle)
        {
            return i_FirstVehicle.m_LicenseNumber != i_SecondVehicle.m_LicenseNumber;
        }

        public override int GetHashCode()
        {
            return m_LicenseNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool equals = false;

            Vehicle toCompareTo = obj as Vehicle;

            if(toCompareTo != null)
            {
                equals = this == toCompareTo;
            }

            return equals;
        }

        public virtual Dictionary<string, Type> GetMissingInformation()
        {
            Dictionary<string, Type> missingInformation = new Dictionary<string, Type>();

            missingInformation.Add(k_ModelNameMessage, typeof(string));

            return missingInformation;
        }

        public abstract bool FillInformationPiece(KeyValuePair<string, string> i_InformationPiece);
    }
}
