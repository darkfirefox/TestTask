using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestTask
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string fromLang { get; set; }
        public string toLang { get; set; }
        public string fromText { get; set; }
        public string toText { get; set; }
    }
}
