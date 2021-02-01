using AUPS.Commands;
using ChatApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AUPS.ViewModels.Dialogs
{
    public class ErrorDialogViewModel : BaseViewModel 
    {
        private string _errorMessage;
        private ICommand _okBtnCmd;

        public ICommand OkBtnCmd
        {
            get
            {
                if (_okBtnCmd == null)
                {
                    this._okBtnCmd = new RelayCommand(
                        param => OkButtonCommandExecute(param));
                }

                return _okBtnCmd;
            }
        }

        private void OkButtonCommandExecute(object param)
        {
            
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

    }
}
