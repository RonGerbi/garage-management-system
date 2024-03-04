using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class FuelEnergySource : EnergySource
    {
        private FuelTypes m_FuelType;
        private float m_CurrentAmountOfFuelInLitres;
        private const string k_CurrentAmountOfFuelInLitresMessage = "What is the current amount of fuel in the tank (in litres)?";

        public FuelEnergySource(FuelTypes i_FuelType, float i_MaxFuelInLitres) : base(i_MaxFuelInLitres)
        {
            m_FuelType = i_FuelType;
        }

        internal FuelTypes FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        internal float CurrentAmountOfFuelInLitres
        {
            get
            {
                return m_CurrentAmountOfFuelInLitres;
            }
            set
            {
                if (isValidAmount(value))
                {
                    m_CurrentAmountOfFuelInLitres = value;
                    CalculateEnergyPercentageLeft(m_CurrentAmountOfFuelInLitres);
                }
                else
                {
                    throw new ValueOutOfRangeException(0, getMissingAmountOfFuel());
                }
            }
        }

        internal void Fuel(float i_AmountOfLitresToAdd, FuelTypes i_FuelType)
        {
            if (isSameFuelType(m_FuelType, i_FuelType))
            {
                CurrentAmountOfFuelInLitres += i_AmountOfLitresToAdd;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private bool isValidAmount(float i_AmountOfLitres)
        {
            bool validAmount = false;

            if (i_AmountOfLitres >= 0 && i_AmountOfLitres <= m_MaxEnergy)
            {
                validAmount = true;
            }

            return validAmount;
        }

        private float getMissingAmountOfFuel()
        {
            float missingAmountOfFuel = m_MaxEnergy - m_CurrentAmountOfFuelInLitres;

            return missingAmountOfFuel;
        }

        private static bool isSameFuelType(FuelTypes i_FirstFuelType, FuelTypes i_SecondFuelType)
        {
            return i_FirstFuelType.Type == i_SecondFuelType.Type;
        }

        public override string ToString()
        {
            string fuelEnergySourceInformation = String.Format("Fuel type: {0}, Fuel amount (in litres): {1} / {2} - {3}% full",
                m_FuelType.ToString(),
                m_CurrentAmountOfFuelInLitres.ToString(),
                MaxEnergy.ToString(),
                m_EnergyPercentageLeft);

            return fuelEnergySourceInformation;
        }

        public override void AddMissingInformation(Dictionary<string, Type> io_MissingInformation)
        {
            io_MissingInformation.Add(k_CurrentAmountOfFuelInLitresMessage, typeof(float));
        }

        public override bool FillEnergySourceInformation(KeyValuePair<string, string> i_InformationPiece)
        {
            bool filledEnergySourceInformation;

            if (i_InformationPiece.Key == k_CurrentAmountOfFuelInLitresMessage)
            {
                float amountOfFuel;

                filledEnergySourceInformation = float.TryParse(i_InformationPiece.Value, out amountOfFuel);

                if (filledEnergySourceInformation)
                {
                    CurrentAmountOfFuelInLitres = amountOfFuel;
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
