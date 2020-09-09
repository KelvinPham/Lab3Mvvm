using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Lab3Mvvm.Model;
using Lab3Mvvm.View;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace Lab3Mvvm.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ICommand AddCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }

        private MembershipList members;
        public ICommand DeleteCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public MembershipData database;
        public AddWindow add;
        public UpdateWindow update;

        private Member selected;
        public MainViewModel()
        {
            database = new MembershipData();
            Messenger.Default.Register<MessageMember>(this, ReceiveMember);
            AddCommand = new RelayCommand(AddMethod);
            UpdateCommand = new RelayCommand(UpdateMethod);
            DeleteCommand = new RelayCommand(DeleteMethod);
            ExitCommand = new RelayCommand(ExitMethod);
            members = new MembershipList();
            members.Write();
           

        }
        public void ReceiveMember(MessageMember m)
        {
            if (m.Message == "Add")
            {
                members.Add(new Member(m.FirstName, m.LastName, m.Email));
                add.Close();
                //Add new member and then save it to the data base
                members.Save();
                this.RaisePropertyChanged(() => members.Members);

            }
            else if (m.Message.Equals("Close"))
            {
                if (add != null)
                {
                    add.Close();
                }
                else if(update != null)
                {
                    update.Close();
                }
                
            }
            else if (m.Message.Equals("Update"))
            {
                members.Update(selected, m);
                update.Close();
                members.Save();
                this.RaisePropertyChanged(() => members.Members);
            }


        }
        public ObservableCollection<Member> MemberList
        {
            get
            {
                return members.Members;
            }
        }
        public void AddMethod()
        {
            add = new AddWindow();//open a new window
            add.Show();
        }
        public void DeleteMethod()
        {
            members.Remove(selected);
            members.Save();
            this.RaisePropertyChanged(() => this.MemberList);

        }
        public Member SelectedMember
        {
            get { return selected; }
            set
            {
                selected = value;
                RaisePropertyChanged("SelectedMember");
            }
        }

        public void UpdateMethod()
        {
            if (SelectedMember != null)
            {
                update = new UpdateWindow();
                update.Show();
                Messenger.Default.Send(SelectedMember);
            }
        }
        public void ExitMethod()
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}