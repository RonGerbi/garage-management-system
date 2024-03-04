using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    class SystemController
    {
        GarageManager m_GarageManager;

        public SystemController()
        {
            m_GarageManager = new GarageManager();
        }

        public void RunSystem()
        {
            bool exitSystem = false;

            do
            {
                UserInteractions.ClearScreen();

                MenuOptions userChoice = UserInteractions.ShowMenu();

                switch (userChoice.Option)
                {
                    case eMenuOptions.RepairVehicle:
                        repairVehicle(m_GarageManager);
                        break;
                    case eMenuOptions.ListLicenseNumbers:
                        listLicenseNumbers(m_GarageManager);
                        break;
                    case eMenuOptions.ChangeVehicleState:
                        letUserChangeVehicleState(m_GarageManager);
                        break;
                    case eMenuOptions.FullyInflateWheels:
                        letUserFullyInflateVehicleWheels(m_GarageManager);
                        break;
                    case eMenuOptions.RefuelVehicle:
                        letUserFuelVehicle(m_GarageManager);
                        break;
                    case eMenuOptions.ChargeBattery:
                        letUserChargeElectricVehicle(m_GarageManager);
                        break;
                    case eMenuOptions.ShowVehicleInformation:
                        showVehicleInformation(m_GarageManager);
                        break;
                    case eMenuOptions.Exit:
                        exitSystem = true;
                        break;
                    default:
                        throw new FormatException();
                }
            } while (!exitSystem);
        }

        private static void repairVehicle(GarageManager i_GarageManager)
        {
            string licenseNumber = UserInteractions.AskUserForLicenseNumber();

            try
            {
                if (i_GarageManager.IsVehicleInGarage(licenseNumber))
                {
                    VehicleStates vehicleState;

                    UserInteractions.ShowVehicleInGarageMessage(licenseNumber);
                    vehicleState = VehicleStates.Parse(UserInteractions.AskUserForVehicleState());

                    try
                    {
                        i_GarageManager.SetVehicleState(licenseNumber, vehicleState);
                        UserInteractions.AnnounceStateChange(licenseNumber, vehicleState.ToString());
                    }
                    catch (ArgumentException ae)
                    {
                        UserInteractions.PrintArgumentExceptionError(ae);
                        UserInteractions.AnnounceFailedStateChange(licenseNumber);
                    }
                }
                else
                {
                    VehicleTypes vehicleType;

                    vehicleType = VehicleTypes.Parse(UserInteractions.AskUserForVehicleType());

                    try
                    {
                        i_GarageManager.StartVehicleInsertionProcess(vehicleType, licenseNumber);

                        Dictionary<string, Type> informationToFill = i_GarageManager.GetInformationToFill(licenseNumber);
                        Dictionary<string, string> filledInformation = showRelevantMenuForInputRequired(informationToFill);

                        if (i_GarageManager.SendInformationRequiredAndInsertVehicle(licenseNumber, filledInformation))
                        {
                            UserInteractions.AnnounceSuccessfulInsertion(licenseNumber);
                        }
                        else
                        {
                            UserInteractions.ShowVehicleInGarageMessage(licenseNumber);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        UserInteractions.PrintArgumentExceptionError(ae);
                        UserInteractions.VehicleNotFoundMessage(licenseNumber);
                    }
                    catch (ValueOutOfRangeException vorex)
                    {
                        UserInteractions.PrintValueOutOfRangeExceptionError(vorex.Message);
                    }
                }
            }
            catch (FormatException fex)
            {
                UserInteractions.PrintFormatExceptionError(fex);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static void listLicenseNumbers(GarageManager i_GarageManager)
        {
            VehicleStates filterState;
            List<string> licenseNumbers;
            string stateChosen;

            try
            {
                stateChosen = UserInteractions.AskUserForVehicleFilterState();

                if (stateChosen != "4")
                {
                    filterState = VehicleStates.Parse(stateChosen);
                }
                else
                {
                    filterState = null;
                }

                licenseNumbers = i_GarageManager.GetListOfFilteredLicenseNumbers(filterState);
                UserInteractions.PrintListOfLicenseNumbers(licenseNumbers);
            }
            catch (FormatException fex)
            {
                UserInteractions.PrintFormatExceptionError(fex);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static void letUserChangeVehicleState(GarageManager i_GarageManager)
        {
            VehicleStates vehicleState;
            string licenseNumber;

            licenseNumber = UserInteractions.AskUserForLicenseNumber();

            try
            {
                vehicleState = changeVehicleState(i_GarageManager, licenseNumber);
                UserInteractions.AnnounceStateChange(licenseNumber, vehicleState.ToString());
            }
            catch (FormatException fex)
            {
                UserInteractions.PrintFormatExceptionError(fex);
                UserInteractions.AnnounceFailedStateChange(licenseNumber);
            }
            catch (ArgumentException ae)
            {
                UserInteractions.PrintArgumentExceptionError(ae);
                UserInteractions.AnnounceFailedStateChange(licenseNumber);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static void letUserFullyInflateVehicleWheels(GarageManager i_GarageManager)
        {
            string licenseNumber;

            try
            {
                licenseNumber = UserInteractions.AskUserForLicenseNumber();
                i_GarageManager.InflateWheelsFully(licenseNumber);
            }
            catch (ArgumentException ae)
            {
                UserInteractions.PrintArgumentExceptionError(ae);
            }
            catch (ValueOutOfRangeException vorex)
            {
                UserInteractions.PrintValueOutOfRangeExceptionError(vorex.Message);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static void letUserFuelVehicle(GarageManager i_GarageManager)
        {
            float amountOfFuelLitresToFill;
            string licenseNumber;
            FuelTypes fuelType;

            licenseNumber = UserInteractions.AskUserForLicenseNumber();

            try
            {
                fuelType = FuelTypes.Parse(UserInteractions.AskUserForFuelType());
                amountOfFuelLitresToFill = UserInteractions.AskUserForAmountOfFuelLitresToFill();
                i_GarageManager.FuelVehicle(licenseNumber, fuelType, amountOfFuelLitresToFill);
                UserInteractions.AnnounceSuccessfulFuel(licenseNumber);
            }
            catch (FormatException fex)
            {
                UserInteractions.PrintFormatExceptionError(fex);
            }
            catch (ArgumentException ae)
            {
                UserInteractions.PrintArgumentExceptionError(ae);
            }
            catch (ValueOutOfRangeException vorex)
            {
                UserInteractions.PrintValueOutOfRangeExceptionError(vorex.Message);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static void letUserChargeElectricVehicle(GarageManager i_GarageManager)
        {
            string licenseNumber;
            float minutesToCharge;

            licenseNumber = UserInteractions.AskUserForLicenseNumber();
            minutesToCharge = UserInteractions.AskUserForAmountOfMinutesToChargeBattery();

            try
            {
                i_GarageManager.ChargeVehicle(licenseNumber, minutesToCharge);
                UserInteractions.AnnounceSuccessfulCharge(licenseNumber);
            }
            catch (FormatException fex)
            {
                UserInteractions.PrintFormatExceptionError(fex);
            }
            catch (ArgumentException ae)
            {
                UserInteractions.PrintArgumentExceptionError(ae);
            }
            catch (ValueOutOfRangeException vorex)
            {
                UserInteractions.PrintValueOutOfRangeExceptionError(vorex.Message);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static void showVehicleInformation(GarageManager i_GarageManager)
        {
            string licenseNumber;

            licenseNumber = UserInteractions.AskUserForLicenseNumber();

            try
            {
                UserInteractions.ShowVehicleInformation(i_GarageManager.GetVehicleInformation(licenseNumber));
            }
            catch (ArgumentException ae)
            {
                UserInteractions.PrintArgumentExceptionError(ae);
            }
            finally
            {
                UserInteractions.PressEnterToMainMenu();
            }
        }

        private static Dictionary<string, string> showRelevantMenuForInputRequired(Dictionary<string, Type> informationToFill)
        {
            Dictionary<string, string> userInputs = new Dictionary<string, string>();

            foreach (KeyValuePair<string, Type> pieceOfInformationToFill in informationToFill)
            {
                if (pieceOfInformationToFill.Value == typeof(VehicleStates))
                {
                    userInputs.Add(pieceOfInformationToFill.Key, UserInteractions.AskUserForVehicleState());
                }
                else if (pieceOfInformationToFill.Value == typeof(NumberOfDoors))
                {
                    userInputs.Add(pieceOfInformationToFill.Key, UserInteractions.AskUserForNumberOfDoors());
                }
                else if (pieceOfInformationToFill.Value == typeof(LicenseOptions))
                {
                    userInputs.Add(pieceOfInformationToFill.Key, UserInteractions.AskUserForLicenseType());
                }
                else if (pieceOfInformationToFill.Value == typeof(FuelTypes))
                {
                    userInputs.Add(pieceOfInformationToFill.Key, UserInteractions.AskUserForFuelType());
                }
                else if (pieceOfInformationToFill.Value == typeof(ColorOptions))
                {
                    userInputs.Add(pieceOfInformationToFill.Key, UserInteractions.AskUserForColor());
                }
                else
                {
                    userInputs.Add(pieceOfInformationToFill.Key, UserInteractions.AskUserForInformation(pieceOfInformationToFill));
                }
            }

            return userInputs;
        }

        private static VehicleStates changeVehicleState(GarageManager i_GarageManager, string licenseNumber)
        {
            VehicleStates vehicleState;
            string vehicleStateStr;
            
            vehicleStateStr = UserInteractions.AskUserForVehicleState();

            if (vehicleStateStr != "4")
            {
                vehicleState = VehicleStates.Parse(vehicleStateStr);
            }
            else
            {
                throw new FormatException();
            }

            i_GarageManager.SetVehicleState(licenseNumber, vehicleState);

            return vehicleState;
        }
    }
}
