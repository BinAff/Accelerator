using System;
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

        public static void Bind<T>(this ListBox control, List<T> list, String displayMember)
        {
            control.Items.Clear();
            if (list != null)
            {
                foreach (T t in list)
                {
                    control.Items.Add(t);
                }
            }
            control.DisplayMember = displayMember;
            control.SelectedIndex = -1;
        }

        public static List<T> RetrieveItems<T>(this ListBox control)
        {
            if (control.Items.Count > 0)
            {
                List<T> ret = new List<T>();
                foreach (T item in control.Items)
                {
                    ret.Add(item);
                }
                return ret;
            }
            return null;
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

        public static void Bind<T>(this ComboBox control, List<T> list, String displayMember)
        {
            control.Items.Clear();
            if (list != null)
            {
                foreach (T t in list)
                {
                    control.Items.Add(t);
                }
            }
            control.DisplayMember = displayMember;
            control.SelectedIndex = -1;
        }

        public static List<T> RetrieveItems<T>(this ComboBox control)
        {
            if (control.Items.Count > 0)
            {
                List<T> ret = new List<T>();
                foreach (T item in control.Items)
                {
                    ret.Add(item);
                }
                return ret;
            }
            return null;
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

    public static class ListControlExtender
    {

    }

}
