using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
        private readonly FuelTypes r_StandardFuelType = new FuelTypes(eFuelTypes.Octan95);
        private const float k_StandardMaxFuelInLitres = 58f;

        public FueledCar() : base()
        {
            EnergySource = new FuelEnergySource(r_StandardFuelType, k_StandardMaxFuelInLitres);
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
            else if (i_InformationPiece.Key == k_ColorMessage)
            {
                Color = ColorOptions.Parse(i_InformationPiece.Value);
            }
            else if (i_InformationPiece.Key == k_NumberOfDoorsMessage)
            {
                NumberOfDoors = NumberOfDoors.Parse(i_InformationPiece.Value);
            }
            else
            {
                hasFilledInformationPiece = TryFillInformationForWheels(i_InformationPiece) || m_EnergySource.FillEnergySourceInformation(i_InformationPiece);
            }

            return hasFilledInformationPiece;
        }
    }
}
