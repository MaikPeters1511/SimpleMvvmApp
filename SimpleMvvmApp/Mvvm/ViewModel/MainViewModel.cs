using System.Collections;
using SimpleMvvmApp.Mvvm.Model;

namespace SimpleMvvmApp.Mvvm.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        private SimplePerson person;
    
        public SimplePerson Person
        {
            get => person;
            set => SetProperty(ref person, value);
        }
    
        public ICommand ClearName { get; }
        public ICommand DeleteName { get; }
        public ICommand ResetData { get; }

        public MainViewModel()
        {
            person = new SimplePerson();
            ClearName = new RelayCommand(() => ClearNameOfPerson());
            DeleteName = new RelayCommand<IList>(list => DeleteChildFromList(list));
            ResetData = new RelayCommand(() => GenerateSampleData());

            GenerateSampleData();
        }

        private void GenerateSampleData()
        {
            Person.LastName = "Bismark";
            Person.FirstName = "Otto";
            Person.Children = new ObservableCollection<string>(new List<string> { "Wilhelm", "Marie", "Herbert" });
        }
        
        private void DeleteChildFromList(IList? obj)
        {
            // Check if children is nullable or not
            if (obj != null)
            {
                //ist etwas tricky
                var copyOfSelectedItems = ((IList<object>)obj).ToList();

                foreach (string item in copyOfSelectedItems)
                {
                    Person.Children.Remove(item);
                }
            }
        }
    
        private void ClearNameOfPerson()
        {
            Person.LastName = string.Empty;
            Person.FirstName = string.Empty;
        }
    }
}