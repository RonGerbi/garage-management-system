using System;

namespace Ex03.GarageLogic
{
    public class ColorOptions
    {
        private eColorOptions m_Color;

        public ColorOptions(eColorOptions i_Color)
        {
            m_Color = i_Color;
        }

        public eColorOptions Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public static ColorOptions Parse(string i_ColorOptionsStr)
        {
            ColorOptions colorOption;

            switch (i_ColorOptionsStr)
            {
                case "1":
                    colorOption = new ColorOptions(eColorOptions.Blue);
                    break;
                case "2":
                    colorOption = new ColorOptions(eColorOptions.Red);
                    break;
                case "3":
                    colorOption = new ColorOptions(eColorOptions.White);
                    break;
                case "4":
                    colorOption = new ColorOptions(eColorOptions.Yellow);
                    break;
                default:
                    throw new FormatException();
            }

            return colorOption;
        }

        public override string ToString()
        {
            string colorOptionStringFormat;

            switch (m_Color)
            {
                case eColorOptions.Blue:
                    colorOptionStringFormat = "Blue";
                    break;
                case eColorOptions.White:
                    colorOptionStringFormat = "White";
                    break;
                case eColorOptions.Red:
                    colorOptionStringFormat = "Red";
                    break;
                case eColorOptions.Yellow:
                    colorOptionStringFormat = "Yellow";
                    break;
                default:
                    colorOptionStringFormat = "Missing color";
                    break;
            }

            return colorOptionStringFormat;
        }
    }
}
