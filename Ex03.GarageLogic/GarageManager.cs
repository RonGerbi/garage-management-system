using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicle> r_RegisteredVehicles;
        private readonly Dictionary<string, GarageVehicle> r_PendingVehicles;

        public GarageManager()
        {
            r_RegisteredVehicles = new Dictionary<string, GarageVehicle>();
            r_PendingVehicles = new Dictionary<string, GarageVehicle>();
        }

        public Dictionary<string, Type> GetInformationToFill(string i_LicenseNumber)
        {
            Dictionary<string, Type> missingInformation;

            if (isVehiclePending(i_LicenseNumber))
            {
                missingInformation = r_PendingVehicles[i_LicenseNumber].VehicleObject.GetMissingInformation();
                r_PendingVehicles[i_LicenseNumber].AddMissingGarageVehicleInformation(missingInformation);
            }
            else if (IsVehicleInGarage(i_LicenseNumber))
            {
                missingInformation = r_RegisteredVehicles[i_LicenseNumber].VehicleObject.GetMissingInformation();
                r_RegisteredVehicles[i_LicenseNumber].AddMissingGarageVehicleInformation(missingInformation);
            }
            else
            {
                throw new ArgumentException();
            }

            return missingInformation;
        }

        public bool SendInformationRequiredAndInsertVehicle(string i_LicenseNumber, Dictionary<string, string> i_Information)
        {
            bool vehicleRegistered = false;

            if (isVehiclePending(i_LicenseNumber))
            {
                fillVehicleRequiredInformation(r_PendingVehicles[i_LicenseNumber], i_Information);
                vehicleRegistered = registerVehicle(i_LicenseNumber);
            }
            else if (IsVehicleInGarage(i_LicenseNumber))
            {
                fillVehicleRequiredInformation(r_RegisteredVehicles[i_LicenseNumber], i_Information);
            }
            else
            {
                throw new ArgumentException();
            }

            return vehicleRegistered;
        }

        public StringBuilder GetVehicleInformation(string i_LicenseNumber)
        {
            StringBuilder vehicleInformation = new StringBuilder();

            if (IsVehicleInGarage(i_LicenseNumber))
            {
                vehicleInformation.AppendFormat("Vehicle's license number: {0}", i_LicenseNumber);
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's model name: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleObject.ModelName);
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's owner name: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleForm.OwnerName);
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's owner phone number: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleForm.OwnerPhoneNumber);
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's state in the garage: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleForm.VehicleState.ToString());
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's wheels information: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleObject.Wheels[0].ToString());
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's energy source information: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleObject.EnergySource.ToString());
                vehicleInformation.AppendLine();
                vehicleInformation.AppendFormat("Vehicle's extra information: {0}", r_RegisteredVehicles[i_LicenseNumber].VehicleObject.ToString());
                vehicleInformation.AppendLine();
            }
            else
            {
                throw new ArgumentException();
            }

            return vehicleInformation;
        }

        public void SetVehicleState(string i_LicenseNumber, VehicleStates i_VehicleStateToSet)
        {
            if (IsVehicleInGarage(i_LicenseNumber))
            {
                VehicleForm vehicleForm = r_RegisteredVehicles[i_LicenseNumber].VehicleForm;
                vehicleForm.VehicleState = i_VehicleStateToSet;
                r_RegisteredVehicles[i_LicenseNumber].VehicleForm = vehicleForm;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_RegisteredVehicles.ContainsKey(i_LicenseNumber);
        }

        public void StartVehicleInsertionProcess(VehicleTypes i_VehicleType, string i_LicenseNumber)
        {
            Vehicle newVehicle = VehicleManufacturingPlant.ManufactureVehicle(i_VehicleType);
            prepareVehicle(i_LicenseNumber, newVehicle);
        }

        public void FuelVehicle(string i_LicenseNumber, FuelTypes i_FuelType, float i_AmountToFill)
        {
            if (IsVehicleInGarage(i_LicenseNumber))
            {
                FuelEnergySource fueledEnergySource = r_RegisteredVehicles[i_LicenseNumber].VehicleObject.EnergySource as FuelEnergySource;

                if (fueledEnergySource != null)
                {
                    fueledEnergySource.Fuel(i_AmountToFill, i_FuelType);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_MinutesToCharge)
        {
            if (IsVehicleInGarage(i_LicenseNumber))
            {
                const float k_MinutesInAnHour = 60f;

                ElectricEnergySource electricEnergySource = r_RegisteredVehicles[i_LicenseNumber].VehicleObject.EnergySource as ElectricEnergySource;

                if (electricEnergySource != null)
                {
                    electricEnergySource.ChargeBattery(i_MinutesToCharge / k_MinutesInAnHour);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void InflateWheelsFully(string i_LicenseNumber)
        {
            if (IsVehicleInGarage(i_LicenseNumber))
            {
                r_RegisteredVehicles[i_LicenseNumber].VehicleObject.InflateWheels();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<string> GetListOfFilteredLicenseNumbers(VehicleStates i_FilterState)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (KeyValuePair<string, GarageVehicle> registeredVehicle in r_RegisteredVehicles)
            {

                if (i_FilterState == null || (i_FilterState != null && i_FilterState.State == registeredVehicle.Value.VehicleForm.VehicleState.State))
                {
                    licenseNumbers.Add(registeredVehicle.Key);
                }
            }

            return licenseNumbers;
        }

        private void fillVehicleRequiredInformation(GarageVehicle i_GarageVehicleToFill, Dictionary<string, string> i_Information)
        {
            foreach (KeyValuePair<string, string> informationPiece in i_Information)
            {
                if (!i_GarageVehicleToFill.VehicleObject.FillInformationPiece(informationPiece))
                {
                    i_GarageVehicleToFill.FillInformationPiece(informationPiece);
                }
            }

            VehicleForm vehicleForm = i_GarageVehicleToFill.VehicleForm;

            vehicleForm.VehicleState = new VehicleStates(eVehicleStates.UnderRepair);
            i_GarageVehicleToFill.VehicleForm = vehicleForm;
        }

        private bool isVehiclePending(string i_LicenseNumber)
        {
            return r_PendingVehicles.ContainsKey(i_LicenseNumber);
        }

        private void prepareVehicle(string i_LicenseNumber, Vehicle newVehicle)
        {
            VehicleForm vehicleForm = new VehicleForm();
            GarageVehicle garageVehicle = new GarageVehicle(newVehicle, vehicleForm);
            r_PendingVehicles.Add(i_LicenseNumber, garageVehicle);
        }

        private bool registerVehicle(string i_LicenseNumber)
        {
            bool isRegisteredAlready = false;

            if (r_RegisteredVehicles.ContainsKey(i_LicenseNumber))
            {
                isRegisteredAlready = true;
            }
            else
            {
                r_RegisteredVehicles.Add(i_LicenseNumber, r_PendingVehicles[i_LicenseNumber]);
                r_PendingVehicles.Remove(i_LicenseNumber);
            }

            return !isRegisteredAlready;
        }
    }
}
