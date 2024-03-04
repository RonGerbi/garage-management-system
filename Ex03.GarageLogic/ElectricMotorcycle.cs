using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryTime = 2.8f;

        public ElectricMotorcycle() : base()
        {
            m_EnergySource = new ElectricEnergySource(k_MaxBatteryTime);
        }

        public override Dictionary<string, Type> GetMissingInformation()
        {
            Dictionary<string, Type> missingInformation = base.GetMissingInformation();

            m_EnergySource.AddMissingInformation(missingInformation);

            return missingInformation;
        }

        public override bool FillInformationPiece(KeyValuePair<string, string> i_InformationPiece)
        {
            bool hasFilledInformationPiece = true;

            if (i_InformationPiece.Key == k_ModelNameMessage)
            {
                ModelName = i_InformationPiece.Value;
            }
            else if (i_InformationPiece.Key == k_LicenseTypeMessage)
            {
                LicenseType = LicenseOptions.Parse(i_InformationPiece.Value);
            }
            else if (i_InformationPiece.Key == k_EngineCapacityMessage)
            {
                EngineCapacity = int.Parse(i_InformationPiece.Value);
            }
            else
            {
                hasFilledInformationPiece = TryFillInformationForWheels(i_InformationPiece) || m_EnergySource.FillEnergySourceInformation(i_InformationPiece);
            }

            return hasFilledInformationPiece;
        }
    }
}
