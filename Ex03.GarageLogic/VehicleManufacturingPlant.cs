namespace Ex03.GarageLogic
{
    class VehicleManufacturingPlant
    {
        internal static Vehicle ManufactureVehicle(VehicleTypes i_VehicleType)
        {
            Vehicle manufacturedVehicle = null;

            switch (i_VehicleType.Type)
            {
                case eVehicleTypes.FueledMotorcycle:
                    manufacturedVehicle = new FueledMotorcycle();
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    manufacturedVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleTypes.FueledCar:
                    manufacturedVehicle = new FueledCar();
                    break;
                case eVehicleTypes.ElectricCar:
                    manufacturedVehicle = new ElectricCar();
                    break;
                case eVehicleTypes.Truck:
                    manufacturedVehicle = new Truck();
                    break;
            }

            return manufacturedVehicle;
        }
    }
}
