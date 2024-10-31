namespace UserInfoApp.Model
{
    public class FilterViewModel
    {
        public string SelectedName { get; } 

        public FilterViewModel( string name)
        {
            SelectedName = name;
        }
    }
}