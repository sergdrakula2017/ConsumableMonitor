using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using ConsumableMonitor.App.Views;
using System.Windows.Navigation;

namespace ConsumableMonitor.App.ViewModels
{
    internal class AddDataViewModel : ObservableObject
    {
        private RelayCommand addNewModel_;
        public RelayCommand AddNewProdecer_
        {
            get
            {
                return addNewModel_ ??
                  (addNewModel_ = new RelayCommand(ShowAddNewProdecer));
            }
        }
        public void ShowAddNewProdecer()
        {
            NavigationWindow win = new NavigationWindow();
            win.Content = new AddNewModel();
            win.ShowDialog();
        }
    }
}
