using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN_searchBookInfo
{
    public class Title
    {
        private String name;
        private String href;

        public string Name { get => name; set => name = value; }
        public string Href { get => href; set => href = value; }
    }
}
