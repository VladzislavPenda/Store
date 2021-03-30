namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string Fields { get; set; }

        public string OrderBy { get; set; }
    }

    public class ModelsParameters : RequestParameters
    {
        public ModelsParameters()
        {
            OrderBy = "name";
        }

        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = uint.MaxValue;
        public bool ValidRange => MaxPrice > MinPrice;
        public string SearchTerm { get; set; }
    }
}
