namespace UserInfoApp.Model
{
    public class FilterViewModel
    {
        public string SelectedValue { get; } 
        public FilterMode FilterModeValue { get; }

        public FilterViewModel(string selectedVal, FilterMode filterMode)
        {
            SelectedValue = selectedVal;
            FilterModeValue = filterMode;
        }
    }
}