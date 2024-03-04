using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_TransportsDangerousMaterials;
        private float m_CargoVolume;
        private readonly FuelTypes r_StandardFuelType = new FuelTypes(eFuelTypes.Soler);
        private const float k_StandardMaxFuelInLitres = 110f;
        private const float k_StandardMaxAirPressure = 28f;
        private const int k_NumberOfWheels = 12;
        private const string k_TransportsDangerousMaterialsMessage = "Does the truck transport dangerous materials (yes/no)?";
        private const string k_CargoVolumeMessage = "What is the cargo's volume?";

        public Truck() : base()
        {
            addTruckWheels();
            m_EnergySource = new FuelEnergySource(r_StandardFuelType, k_StandardMaxFuelInLitres);
        }

        internal float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
            }
        }

        private void addTruckWheels()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheel truckWheel = new Wheel();
                truckWheel.MaxAirPressure = k_StandardMaxAirPressure;
                AddWheel(truckWheel);
            }
        }

        public override string ToString()
        {
            string transportsDangerousMaterialsStringFormat;

            if (m_TransportsDangerousMaterials)
            {
                transportsDangerousMaterialsStringFormat = "transports dangerous material";
            }
            else
            {
                transportsDangerousMaterialsStringFormat = "does not transport dangerous material";
            }

            string truckInformation = string.Format(@"Truck's cargo volume: {0},
{1},
has {2} wheels",
                m_CargoVolume.ToString(),
                transportsDangerousMaterialsStringFormat,
                m_Wheels.Count.ToString());

            return truckInformation;
        }

        public override Dictionary<string, Type> GetMissingInformation()
        {
            Dictionary<string, Type> missingInformation = base.GetMissingInformation();

            m_Wheels[0].AddMissingInformation(missingInformation);
            m_EnergySource.AddMissingInformation(missingInformation);
            missingInformation.Add(k_TransportsDangerousMaterialsMessage, typeof(bool));
            missingInformation.Add(k_CargoVolumeMessage, typeof(float));

            return missingInformation;
        }

        public override bool FillInformationPiece(KeyValuePair<string, string> i_InformationPiece)
        {
            bool hasFilledInformationPiece = true;

            if (i_InformationPiece.Key == k_ModelNameMessage)
            {
                ModelName = i_InformationPiece.Value;
            }
            else if (i_InformationPiece.Key == k_TransportsDangerousMaterialsMessage)
            {
                switch (i_InformationPiece.Value.ToLower())
                {
                    case "yes":
                        m_TransportsDangerousMaterials = true;
                        break;
                    case "no":
                        m_TransportsDangerousMaterials = false;
                        break;
                    default:
                        hasFilledInformationPiece = false;
                        throw new FormatException();
                }
            }
            else if (i_InformationPiece.Key == k_CargoVolumeMessage)
            {
                float cargoVolume;

                hasFilledInformationPiece = float.TryParse(i_InformationPiece.Value, out cargoVolume);

                if (hasFilledInformationPiece)
                {
                    CargoVolume = cargoVolume;
                }
            }
            else
            {
                hasFilledInformationPiece = TryFillInformationForWheels(i_InformationPiece) || m_EnergySource.FillEnergySourceInformation(i_InformationPiece);
            }

            return hasFilledInformationPiece;
        }
    }
}
