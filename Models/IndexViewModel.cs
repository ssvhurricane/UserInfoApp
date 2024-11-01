namespace UserInfoApp.Model
{
     public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; }
        public IndexViewModel(IEnumerable<User> users, PageViewModel pageViewModel, 
            FilterViewModel filterViewModel, SortViewModel sortViewModel)
        {
            Users = users;

            PageViewModel = pageViewModel;

            FilterViewModel = filterViewModel;
            
            SortViewModel = sortViewModel;
        }
    }
}