using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Car : Vehicle
    {
        private ColorOptions m_Color;
        private NumberOfDoors m_NumberOfDoors;
        private const int k_NumberOfWheels = 5;
        private const float k_StandardMaxAirPressure = 30f;
        protected const string k_ColorMessage = "What is the color of the car?";
        protected const string k_NumberOfDoorsMessage = "How many doors does the car have?";

        public Car() : base()
        {
            addCarWheels();
        }

        internal ColorOptions Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        internal NumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        private void addCarWheels()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel carWheel = new Wheel();
                carWheel.MaxAirPressure = k_StandardMaxAirPressure;
                AddWheel(carWheel);
            }
        }

        public override string ToString()
        {
            string color;
            string numberOfDoors;

            if (m_Color != null)
            {
                color = m_Color.ToString();
            }
            else
            {
                color = "not chosen";
            }

            if (m_NumberOfDoors != null)
            {
                numberOfDoors = m_NumberOfDoors.ToString();
            }
            else
            {
                numberOfDoors = "unknown";
            }

            string carInformation = string.Format(@"Car color: {0},
number of doors: {1},
has {2} wheels",
                color,
                numberOfDoors,
                m_Wheels.Count.ToString());

            return carInformation;
        }

        public override Dictionary<string, Type> GetMissingInformation()
        {
            Dictionary<string, Type> missingInformation = base.GetMissingInformation();

            m_Wheels[0].AddMissingInformation(missingInformation);
            missingInformation.Add(k_ColorMessage, typeof(ColorOptions));
            missingInformation.Add(k_NumberOfDoorsMessage, typeof(NumberOfDoors));

            return missingInformation;
        }
    }
}
