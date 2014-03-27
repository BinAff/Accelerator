using System.Collections.Generic;
using System.Windows.Forms;

namespace BinAff.Presentation.Library.Extension
{

    public static class ListBoxExtender
    {

        public static void Bind<T>(this ListBox control, List<T> list)
        {
            control.Items.Clear();
            if (list != null)
            {
                foreach (T t in list)
                {
                    control.Items.Add(t);
                }
            }
        }

        public static List<T> DataSource<T>(this ListBox control)
        {
            List<T> dataSource = new List<T>();
            foreach (T t in control.Items)
            {
                dataSource.Add(t);
            }
            return dataSource;
        }

    }

    public static class ComboBoxExtender
    {

        public static void Bind<T>(this ComboBox control, List<T> list)
        {
            control.Items.Clear();
            if (list != null)
            {
                foreach (T t in list)
                {
                    control.Items.Add(t);
                }
            }
        }

        public static List<T> DataSource<T>(this ComboBox control)
        {
            List<T> dataSource = new List<T>();
            foreach (T t in control.Items)
            {
                dataSource.Add(t);
            }
            return dataSource;
        }

    }

}
