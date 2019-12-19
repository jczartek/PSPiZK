using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad.Model
{
    class Text : ICloneable
    {
        private StringBuilder sbuilder = new StringBuilder();

        public string Content
        {
            get
            {
                return sbuilder.ToString();
            }

            set
            {
                sbuilder.Append(value);
            }
        }


        public void Clear()
        {
            sbuilder.Clear();
        }

        public object Clone()
        {
            Text text = new Text
            {
                Content = ToString()
            };
            return text;
        }

        public override string ToString()
        {
            return sbuilder.ToString();
        }
    }
}
