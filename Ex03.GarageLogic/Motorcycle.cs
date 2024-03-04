using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Motorcycle : Vehicle
    {
        private int m_EngineCapacity;
        private LicenseOptions m_LicenseType;
        private const int k_NumberOfWheels = 2;
        private const float k_StandardMaxAirPressure = 29f;
        protected const string k_EngineCapacityMessage = "What is the engine capacity of this motorcycle?";
        protected const string k_LicenseTypeMessage = "What is the license type required for this motorcycle?";

        public Motorcycle() : base()
        {
            addMotorcycleWheels();
        }

        internal int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                m_EngineCapacity = value;
            }
        }

        internal LicenseOptions LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        private void addMotorcycleWheels()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel motorcycleWheel = new Wheel();
                motorcycleWheel.MaxAirPressure = k_StandardMaxAirPressure;
                AddWheel(motorcycleWheel);
            }
        }

        public override string ToString()
        {
            string licenseType;

            if (m_LicenseType != null)
            {
                licenseType = m_LicenseType.ToString();
            }
            else
            {
                licenseType = "not chosen";
            }

            string motorcycleInformation = string.Format(@"Motorcycle's license: {0},
engine capacity: {1},
has {2} wheels",
                licenseType,
                m_EngineCapacity.ToString(),
                m_Wheels.Count.ToString());

            return motorcycleInformation;
        }

        public override Dictionary<string, Type> GetMissingInformation()
        {
            Dictionary<string, Type> missingInformation = base.GetMissingInformation();

            m_Wheels[0].AddMissingInformation(missingInformation);
            missingInformation.Add(k_EngineCapacityMessage, typeof(int));
            missingInformation.Add(k_LicenseTypeMessage, typeof(LicenseOptions));

            return missingInformation;
        }
    }
}
