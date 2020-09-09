using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Lab3Mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Lab3Mvvm.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public ICommand SaveCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

        private string enteredFName;
        private string enteredLName;
        private string enteredEmail;

        public string EnteredFName
        {
            get
            {
                return enteredFName;
            }
            set
            {
                enteredFName = value;
                RaisePropertyChanged("EnteredFName");
            }
        }
        public string EnteredLName
        {
            get
            {
                return enteredLName;
            }
            set
            {
                enteredLName = value;
                RaisePropertyChanged("EnteredLName");
            }
        }
        public string EnteredEmail
        {
            get
            {
                return enteredEmail;
            }
            set
            {
                enteredEmail = value;
                RaisePropertyChanged("EnteredEmail");
            }
        }
        public AddViewModel()
        {
            SaveCommand = new RelayCommand<IClosable>(SaveMethod);
            CloseCommand = new RelayCommand<IClosable>(CloseMethod);
        }
        public void SaveMethod(IClosable window)
        {
            
              //An object MessageMember and a string “Add” are sending to
               //another view model. In this case, the view model is the main
               //view folder.
               if(Validator.isPresent(enteredLName)&& Validator.isPresent(enteredFName) && 
                    Validator.isPresent(enteredEmail) && Validator.IsValidEmail(enteredEmail) &&
                    Validator.IsWithinRange(enteredFName, 1, 25) && Validator.IsWithinRange(enteredLName, 1, 25) &&
                    Validator.IsWithinRange(enteredEmail, 1, 25))
                {
                  
                    Messenger.Default.Send(new MessageMember(enteredFName, enteredLName, enteredEmail, "Add"));
                enteredFName = null;
                enteredLName = null;
                enteredEmail = null;
            }

               
            


        }
        public void CloseMethod(IClosable window)
        {
            Messenger.Default.Send(new MessageMember(null, null, null, "Close"));

        }
    }
}
