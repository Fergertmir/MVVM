using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class TaskItem
    {
        private int _id;
        private string _text;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}
