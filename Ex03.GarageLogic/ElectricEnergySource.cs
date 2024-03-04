using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class ElectricEnergySource : EnergySource
    {
        private float m_ChargeLeftInHours;
        private const string k_ChargeLeftInHoursMessage = "How many hours are left in the battery?";

        public ElectricEnergySource(float i_MaxBatteryTime) : base(i_MaxBatteryTime)
        {
        }

        internal float ChargeLeftInHours
        {
            get
            {
                return m_ChargeLeftInHours;
            }
            set
            {
                if (isValidChargeAmount(value))
                {
                    m_ChargeLeftInHours = value;
                    CalculateEnergyPercentageLeft(m_ChargeLeftInHours);
                }
                else
                {
                    throw new ValueOutOfRangeException(0, getMissingElectricEnergy());
                }
            }
        }

        internal void ChargeBattery(float i_HoursToCharge)
        {
            ChargeLeftInHours += i_HoursToCharge;
        }

        private float getMissingElectricEnergy()
        {
            return m_MaxEnergy - m_ChargeLeftInHours;
        }

        private bool isValidChargeAmount(float i_ChargeInHours)
        {
            bool validChargeTime = false;

            if (i_ChargeInHours >= 0 && i_ChargeInHours <= m_MaxEnergy)
            {
                validChargeTime = true;
            }

            return validChargeTime;
        }

        public override string ToString()
        {
            string electricEnergySourceInformation = String.Format("Battery state (Charge in hours left / Max charge in hours): {0} / {1} - {2}% full",
                m_ChargeLeftInHours,
                MaxEnergy.ToString(),
                m_EnergyPercentageLeft.ToString());

            return electricEnergySourceInformation;
        }

        public override void AddMissingInformation(Dictionary<string, Type> io_MissingInformation)
        {
            io_MissingInformation.Add(k_ChargeLeftInHoursMessage, typeof(float));
        }

        public override bool FillEnergySourceInformation(KeyValuePair<string, string> i_InformationPiece)
        {
            bool filledEnergySourceInformation;

            if (i_InformationPiece.Key == k_ChargeLeftInHoursMessage)
            {
                float chargeLeft;

                filledEnergySourceInformation = float.TryParse(i_InformationPiece.Value, out chargeLeft);

                if (filledEnergySourceInformation)
                {
                    ChargeLeftInHours = chargeLeft;
                }
                else
                {
                    filledEnergySourceInformation = false;
                    throw new FormatException();
                }
            }
            else
            {
                filledEnergySourceInformation = false;
            }

            return filledEnergySourceInformation;
        }
    }
}
