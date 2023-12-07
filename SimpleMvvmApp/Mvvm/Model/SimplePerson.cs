namespace SimpleMvvmApp.Mvvm.Model
{
    public class SimplePerson : ObservableObject
    {
        private string lastName = string.Empty;
        private string firstName = string.Empty;
        private ObservableCollection<string> children = new ObservableCollection<string>();
    
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
 
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
    
        public ObservableCollection<string> Children
        {
            get => children;
            set => SetProperty(ref children, value);
        }
    }
}