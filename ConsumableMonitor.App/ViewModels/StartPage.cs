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
    internal class StartPage : ObservableObject
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
            AddData addData = new AddData();
            addData.Show();
        }
        //***
       
        //****

    }
}
