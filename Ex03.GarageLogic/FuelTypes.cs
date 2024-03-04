using System;

namespace Ex03.GarageLogic
{
    public class FuelTypes
    {
        private eFuelTypes m_Type;

        public FuelTypes(eFuelTypes i_Type)
        {
            m_Type = i_Type;
        }

        public eFuelTypes Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        public static FuelTypes Parse(string i_FuelTypeStr)
        {
            FuelTypes fuelType;

            switch (i_FuelTypeStr)
            {
                case "1":
                    fuelType = new FuelTypes(eFuelTypes.Soler);
                    break;
                case "2":
                    fuelType = new FuelTypes(eFuelTypes.Octan95);
                    break;
                case "3":
                    fuelType = new FuelTypes(eFuelTypes.Octan96);
                    break;
                case "4":
                    fuelType = new FuelTypes(eFuelTypes.Octan98);
                    break;
                default:
                    throw new FormatException();
            }

            return fuelType;
        }

        public override string ToString()
        {
            string fuelTypeStringFormat;

            switch (m_Type)
            {
                case eFuelTypes.Soler:
                    fuelTypeStringFormat = "Soler";
                    break;
                case eFuelTypes.Octan95:
                    fuelTypeStringFormat = "Octan95";
                    break;
                case eFuelTypes.Octan96:
                    fuelTypeStringFormat = "Octan96";
                    break;
                case eFuelTypes.Octan98:
                    fuelTypeStringFormat = "Octan98";
                    break;
                default:
                    fuelTypeStringFormat = "Missing fuel type";
                    break;
            }

            return fuelTypeStringFormat;
        }
    }
}
