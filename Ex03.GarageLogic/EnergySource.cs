using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class EnergySource
    {
        protected float m_EnergyPercentageLeft;
        protected float m_MaxEnergy;

        public EnergySource(float i_MaxEnergy)
        {
            m_MaxEnergy = i_MaxEnergy;
        }

        protected void CalculateEnergyPercentageLeft(float i_CurrentEnergy)
        {
            m_EnergyPercentageLeft = i_CurrentEnergy / m_MaxEnergy * 100;
        }

        internal float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
            set
            {
                m_MaxEnergy = value;
            }
        }

        internal float EnergyPercentageLeft
        {
            get
            {
                return m_EnergyPercentageLeft;
            }
        }

        public abstract void AddMissingInformation(Dictionary<string, Type> io_MissingInformation);

        public abstract bool FillEnergySourceInformation(KeyValuePair<string, string> i_InformationPiece);
    }
}
