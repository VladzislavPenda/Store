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

        public bool ValidRange()
        {
            return MaxPrice > MinPrice && MaxHorsePower > MinHorsePower && MaxMileAge > MinMileAge && MaxYear > MinYear;
        }

        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = uint.MaxValue;

        public uint MinHorsePower { get; set; }
        public uint MaxHorsePower { get; set; } = uint.MaxValue;
        public uint MinMileAge { get; set; }
        public uint MaxMileAge { get; set; } = uint.MaxValue;
        public uint MinYear { get; set; }
        public uint MaxYear { get; set; } = uint.MaxValue;
        
        public string SearchTerm { get; set; }
        public string Country { get; set; }
        public string MarkName { get; set; }
        public string EngineType { get; set; }
        public string DriveType { get; set; }
        public string CarcaseType { get; set; }
        public string TransmissionType { get; set; }

    }
}
