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
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Phone phone = new Phone();
                      Phones.Insert(0, phone);
                      SelectedPhone = phone;
                  }));
            }
        }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Phone phone = obj as Phone;
                      if (phone != null)
                      {
                          Phones.Remove(phone);
                      }
                  },
                 (obj) => Phones.Count > 0));
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
                          //Phones.Remove(phone);
                      }
                  },
                 (obj) => Phones.Count > 0));
            }
        }

        private RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                    (doubleCommand = new RelayCommand(obj =>
                    {
                        Phone phone = obj as Phone;
                        if (phone != null)
                        {
                            Phone phoneCopy = new Phone
                            {
                                Company = phone.Company,
                                Price = phone.Price,
                                Title = phone.Title
                            };
                            Phones.Insert(0, phoneCopy);
                        }
                    }));
            }
        }

        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 7", Company="Apple", Price=56000,
                    _items = new ObservableCollection<TaskItem>
                    {
                        new TaskItem { Id = 1, Text = "iPhone 7 Some text 1" },
                        new TaskItem { Id = 2, Text = "iPhone 7 Some text 2" },
                        new TaskItem { Id = 3, Text = "iPhone 7 Some text 3" },
                        new TaskItem { Id = 4, Text = "iPhone 7 Some text 4" }
                    } },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000,
                    _items = new ObservableCollection<TaskItem>
                    {
                        new TaskItem { Id = 1, Text = "Galaxy S7 Edge Some text 1" },
                        new TaskItem { Id = 2, Text = "Galaxy S7 Edge Some text 2" },
                        new TaskItem { Id = 3, Text = "Galaxy S7 Edge Some text 3" },
                        new TaskItem { Id = 4, Text = "Galaxy S7 Edge Some text 4" }
                    } },
                new Phone {Title="Elite x3", Company="HP", Price=56000,
                    _items = new ObservableCollection<TaskItem>
                    {
                        new TaskItem { Id = 1, Text = "Elite x3 Some text 1" },
                        new TaskItem { Id = 2, Text = "Elite x3 Some text 2" },
                        new TaskItem { Id = 3, Text = "Elite x3 Some text 3" },
                        new TaskItem { Id = 4, Text = "Elite x3 Some text 4" }
                    }  },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000,
                    _items = new ObservableCollection<TaskItem>
                    {
                        new TaskItem { Id = 1, Text = "Mi5S Some text 1" },
                        new TaskItem { Id = 2, Text = "Mi5S Some text 2" },
                        new TaskItem { Id = 3, Text = "Mi5S Some text 3" },
                        new TaskItem { Id = 4, Text = "Mi5S Some text 4" }
                    } }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
