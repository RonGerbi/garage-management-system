using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private VehicleForm m_VehicleForm;
        private const string k_OwnerNameMessage = "What is the name of the owner of this vehicle?";
        private const string k_OwnerPhoneNumberMessage = "What is the phone number of the owner of this vehicle?";

        public GarageVehicle(Vehicle i_Vehicle, VehicleForm i_VehicleForm)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleForm = i_VehicleForm;
        }

        internal Vehicle VehicleObject
        {
            get
            {
                return m_Vehicle;
            }
        }

        internal VehicleForm VehicleForm
        {
            get
            {
                return m_VehicleForm;
            }
            set
            {
                m_VehicleForm = value;
            }
        }

        public void AddMissingGarageVehicleInformation(Dictionary<string, Type> io_MissingInformation)
        {
            io_MissingInformation.Add(k_OwnerNameMessage, typeof(string));
            io_MissingInformation.Add(k_OwnerPhoneNumberMessage, typeof(string));
        }

        public virtual bool FillInformationPiece(KeyValuePair<string, string> i_InformationPiece)
        {
            bool hasFilledInformationPiece = true;

            if (i_InformationPiece.Key == k_OwnerNameMessage)
            {
                m_VehicleForm.OwnerName = i_InformationPiece.Value;
            }
            else if (i_InformationPiece.Key == k_OwnerPhoneNumberMessage)
            {
                m_VehicleForm.OwnerPhoneNumber = i_InformationPiece.Value;
            }
            else
            {
                hasFilledInformationPiece = false;
            }

            return hasFilledInformationPiece;
        }
    }
}
