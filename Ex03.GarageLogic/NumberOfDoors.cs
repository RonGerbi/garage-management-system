using System;

namespace Ex03.GarageLogic
{
    public class NumberOfDoors
    {
        private eNumberOfDoors m_NumberOfDoors;

        public NumberOfDoors(eNumberOfDoors i_NumberOfDoors)
        {
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public eNumberOfDoors Number
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public static NumberOfDoors Parse(string i_NumberOfDoorsStr)
        {
            NumberOfDoors numberOfDoors;

            switch (i_NumberOfDoorsStr)
            {
                case "2":
                    numberOfDoors = new NumberOfDoors(eNumberOfDoors.Two);
                    break;
                case "3":
                    numberOfDoors = new NumberOfDoors(eNumberOfDoors.Three);
                    break;
                case "4":
                    numberOfDoors = new NumberOfDoors(eNumberOfDoors.Four);
                    break;
                case "5":
                    numberOfDoors = new NumberOfDoors(eNumberOfDoors.Five);
                    break;
                default:
                    throw new FormatException();
            }

            return numberOfDoors;
        }

        public override string ToString()
        {
            string numberOfDoorsStringFormat;

            switch (m_NumberOfDoors)
            {
                case eNumberOfDoors.Two:
                    numberOfDoorsStringFormat = "Two";
                    break;
                case eNumberOfDoors.Three:
                    numberOfDoorsStringFormat = "Three";
                    break;
                case eNumberOfDoors.Four:
                    numberOfDoorsStringFormat = "Four";
                    break;
                case eNumberOfDoors.Five:
                    numberOfDoorsStringFormat = "Five";
                    break;
                default:
                    numberOfDoorsStringFormat = "Missing number of doors";
                    break;
            }

            return numberOfDoorsStringFormat;
        }
    }
}
