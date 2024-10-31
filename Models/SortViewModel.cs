namespace UserInfoApp.Model
{
    public class SortViewModel
    {
        public SortState FirstNameSort { get; set; } 
        public SortState LastNameSort { get; set; } 
        public SortState Current { get; set; }   
 
        public SortViewModel(SortState sortOrder)
        {
            FirstNameSort = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;
            LastNameSort = sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;
            
            Current = sortOrder;
        }
    }
}