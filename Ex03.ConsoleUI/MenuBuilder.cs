using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class MenuBuilder
    {
        private StringBuilder m_Menu;

        public MenuBuilder(List<string> i_MenuItems, int i_StartingIndex)
        {
            m_Menu = new StringBuilder();

            foreach (string menuItem in i_MenuItems)
            {
                m_Menu.AppendFormat("{0}. {1}", i_StartingIndex.ToString(), menuItem);
                m_Menu.AppendLine();
                i_StartingIndex++;
            }
        }

        public StringBuilder Menu
        {
            get
            {
                return m_Menu;
            }
            set
            {
                m_Menu = value;
            }
        }

        public override string ToString()
        {
            return m_Menu.ToString();
        }
    }
}
