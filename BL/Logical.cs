using Domain;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using BL.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace BL
{
    public class topDLS
    {
        public string DLSName { get; set; }
        public int CountOfUsing { get; set; }
        public override string ToString()
        {
            return DLSName + " - " + CountOfUsing.ToString();
        }
    }
    public class Logical : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private List<topDLS> _topDLS;
        public List<topDLS> topDLS 
        {
            get { return _topDLS; }
            set { _topDLS = value; OnPropertyChanged("topDLS"); }
        }
        public Logical()
        {
            AddCommand = new RelayCommand(add, true);
            ShowTopDLS = new RelayCommand(showtop, true);
        }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand ShowTopDLS { get; set; }
        public ObservableCollection<Teacher>
        Teachers
        { get; set; } = new ObservableCollection<Teacher> { new Teacher("Иванов И. И.", "ИКИТ", "Zoom"), new Teacher("Петров П. П.", "ИКИТ", "Skype"), new Teacher("Алексеев А. А.", "ИКИТ", "Discord") };
        public Teacher NewTeacher { get; set; } = new Teacher(null, null, null);
        delegate bool ICanAddTeacher(string name);
        public void showtop()
        {
            topDLS = new List<topDLS>(
                Teachers.GroupBy(t => t.DistantLearningService).
                Select(g => new topDLS
                { DLSName = g.Key, CountOfUsing = g.Count() }).OrderByDescending(g => g.CountOfUsing).ToList());
        }
        public void add()
        {
            NewTeacher.Name = NewTeacher.Name.GetShortName();
            ICanAddTeacher IsUniqueTeacherName = _ => (Teachers.Select(g => g.Name)).Contains(_);
            if (IsUniqueTeacherName(NewTeacher.Name) == false)
            {
                Teachers.Add(new Teacher(NewTeacher.Name, NewTeacher.Institute, NewTeacher.DistantLearningService));
            }
        }
    }
}
