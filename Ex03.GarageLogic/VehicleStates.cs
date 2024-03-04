using System;

namespace Ex03.GarageLogic
{
    public class VehicleStates
    {
        private eVehicleStates m_State;

        public VehicleStates(eVehicleStates i_State)
        {
            m_State = i_State;
        }

        public eVehicleStates State
        {
            get
            {
                return m_State;
            }
            set
            {
                m_State = value;
            }
        }

        public static VehicleStates Parse(string i_VehicleStateStr)
        {
            VehicleStates vehicleState;

            switch (i_VehicleStateStr)
            {
                case "1":
                    vehicleState = new VehicleStates(eVehicleStates.UnderRepair);
                    break;
                case "2":
                    vehicleState = new VehicleStates(eVehicleStates.Repaired);
                    break;
                case "3":
                    vehicleState = new VehicleStates(eVehicleStates.Paid);
                    break;
                default:
                    throw new FormatException();
            }

            return vehicleState;
        }

        public override string ToString()
        {
            string licenseOptionStringFormat;

            switch (m_State)
            {
                case eVehicleStates.UnderRepair:
                    licenseOptionStringFormat = "Under repair";
                    break;
                case eVehicleStates.Repaired:
                    licenseOptionStringFormat = "Repaired";
                    break;
                case eVehicleStates.Paid:
                    licenseOptionStringFormat = "Paid";
                    break;
                default:
                    licenseOptionStringFormat = "Missing license type";
                    break;
            }

            return licenseOptionStringFormat;
        }
    }
}
