using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DB_Cviceni_2022
{
    public class Clovek
    {
        public int ID { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";

        internal ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] { ID.ToString(), FirstName, LastName, Email, Phone });
        }
    }
}
