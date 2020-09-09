using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Mvvm.Model
{
    public class MembershipList : ObservableObject
    {
        public event ChangeHandler Changed;
        private int propertyCount;
        private ObservableCollection<Member> members;
        public MembershipList()
        {
            members = new ObservableCollection<Member>();
            propertyCount = 0;
        }
        public int PropertyCount
        {
            get
            {
                return propertyCount;
            }

            set
            {
                Set<int>(() => this.PropertyCount, ref propertyCount, value);
            }
        }
        public void Add(Member m)
        {
            members.Add(m);
            propertyCount++;
            OnChange(EventArgs.Empty);

        }

        public void Remove(Member m)
        {
            members.Remove(m);
            propertyCount--;
            OnChange(EventArgs.Empty);

        }
        public void Update(Member m, Member updatedInfo)
        {
            int index = members.IndexOf(m);
            members[index] = updatedInfo;
            OnChange(EventArgs.Empty);

        }
        public void Write()
        {
            MembershipData data = new MembershipData();
            ObservableCollection<Member> tempM = data.GetMemberships();
            if (tempM != null)
            {
                foreach (Member m in tempM)
                {
                    members.Add(m);
                }
            }
        }

        public void Save()
        {
            MembershipData data = new MembershipData();
            data.SaveMemberships(members);
        }
        public ObservableCollection<Member> Members
        {
            get
            {
                return members;
            }
            set
            {
                Set<ObservableCollection<Member>>(() => this.Members, ref members, value);
            }
        }
        public Member this[int i]
        {
            get
            {
                return members[i];
            }
            set
            {
                var m = members.ElementAt(i);
                Set(() => Members[i], ref m, value);
                members[i] = m;
            }
        }

        protected virtual void OnChange(EventArgs e)
        {
            Changed?.Invoke(this);
        }
        public delegate void ChangeHandler(MembershipList m);


    }


}
