using System;

namespace Ex03.GarageLogic
{
    public class LicenseOptions
    {
        private eLicenseOptions m_License;

        public LicenseOptions(eLicenseOptions i_License)
        {
            m_License = i_License;
        }

        public eLicenseOptions License
        {
            get
            {
                return m_License;
            }
            set
            {
                m_License = value;
            }
        }

        public static LicenseOptions Parse(string i_LicenseOptionsStr)
        {
            LicenseOptions licenseOption;

            switch (i_LicenseOptionsStr)
            {
                case "1":
                    licenseOption = new LicenseOptions(eLicenseOptions.A1);
                    break;
                case "2":
                    licenseOption = new LicenseOptions(eLicenseOptions.A2);
                    break;
                case "3":
                    licenseOption = new LicenseOptions(eLicenseOptions.AB);
                    break;
                case "4":
                    licenseOption = new LicenseOptions(eLicenseOptions.B2);
                    break;
                default:
                    throw new FormatException();
            }

            return licenseOption;
        }

        public override string ToString()
        {
            string licenseOptionStringFormat;

            switch (m_License)
            {
                case eLicenseOptions.A1:
                    licenseOptionStringFormat = "A1";
                    break;
                case eLicenseOptions.A2:
                    licenseOptionStringFormat = "A2";
                    break;
                case eLicenseOptions.AB:
                    licenseOptionStringFormat = "AB";
                    break;
                case eLicenseOptions.B2:
                    licenseOptionStringFormat = "B2";
                    break;
                default:
                    licenseOptionStringFormat = "Missing license type";
                    break;
            }

            return licenseOptionStringFormat;
        }
    }
}
