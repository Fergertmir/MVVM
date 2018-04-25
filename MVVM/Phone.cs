using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class Phone : INotifyPropertyChanged
    {

        private string _title;
        private string _company;
        private int _price;

        public ObservableCollection<TaskItem> _items { get; set; }


        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private RelayCommand removeItemCommand;
        public RelayCommand RemoveItemCommand
        {
            get
            {
                return removeItemCommand ??
                  (removeItemCommand = new RelayCommand(obj =>
                  {
                      TaskItem Item = obj as TaskItem;
                      if (Item != null)
                      {
                          _items.Remove(Item);
                      }
                  },
                 (obj) => _items.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
