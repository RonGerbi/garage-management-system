using System;

namespace Ex03.ConsoleUI
{
    class MenuOptions
    {
        private eMenuOptions m_Option;

        public MenuOptions(eMenuOptions i_Option)
        {
            m_Option = i_Option;
        }

        public eMenuOptions Option
        {
            get
            {
                return m_Option;
            }
            set
            {
                m_Option = value;
            }
        }

        public static MenuOptions Parse(string i_MenuOptionStr)
        {
            MenuOptions menuOption;

            switch (i_MenuOptionStr)
            {
                case "1":
                    menuOption = new MenuOptions(eMenuOptions.RepairVehicle);
                    break;
                case "2":
                    menuOption = new MenuOptions(eMenuOptions.ListLicenseNumbers);
                    break;
                case "3":
                    menuOption = new MenuOptions(eMenuOptions.ChangeVehicleState);
                    break;
                case "4":
                    menuOption = new MenuOptions(eMenuOptions.FullyInflateWheels);
                    break;
                case "5":
                    menuOption = new MenuOptions(eMenuOptions.RefuelVehicle);
                    break;
                case "6":
                    menuOption = new MenuOptions(eMenuOptions.ChargeBattery);
                    break;
                case "7":
                    menuOption = new MenuOptions(eMenuOptions.ShowVehicleInformation);
                    break;
                case "8":
                    menuOption = new MenuOptions(eMenuOptions.Exit);
                    break;
                default:
                    throw new FormatException();
            }

            return menuOption;
        }
    }
}
