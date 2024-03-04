namespace Ex03.GarageLogic
{
    struct VehicleForm
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private VehicleStates m_VehicleState;

        public VehicleForm(string i_OwnerName, string i_OwnerPhoneNumber, VehicleStates i_VehicleState)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleState = i_VehicleState;
        }

        internal string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }

        internal string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        internal VehicleStates VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }
    }
}
