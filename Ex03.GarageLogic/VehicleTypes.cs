using System;

namespace Ex03.GarageLogic
{
    public class VehicleTypes
    {
        private eVehicleTypes m_Type;

        public VehicleTypes(eVehicleTypes i_Type)
        {
            m_Type = i_Type;
        }

        public eVehicleTypes Type
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

        public static VehicleTypes Parse(string i_TypeStr)
        {
            VehicleTypes vehicleType;

            switch (i_TypeStr)
            {
                case "1":
                    vehicleType = new VehicleTypes(eVehicleTypes.FueledMotorcycle);
                    break;
                case "2":
                    vehicleType = new VehicleTypes(eVehicleTypes.ElectricMotorcycle);
                    break;
                case "3":
                    vehicleType = new VehicleTypes(eVehicleTypes.FueledCar);
                    break;
                case "4":
                    vehicleType = new VehicleTypes(eVehicleTypes.ElectricCar);
                    break;
                case "5":
                    vehicleType = new VehicleTypes(eVehicleTypes.Truck);
                    break;
                default:
                    throw new FormatException();
            }

            return vehicleType;
        }
    }
}
