using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using ConsumableMonitor.App.Views;

namespace ConsumableMonitor.App.ViewModels
{
    internal class AddNewViewModel : ObservableObject
    {
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(ShowAddData));
            }
        }
        public void ShowAddData()
        {
            AddNewProdecer addNewProdecer = new AddNewProdecer();
            addNewProdecer.ShowDialog();
        }

        


    }
}
