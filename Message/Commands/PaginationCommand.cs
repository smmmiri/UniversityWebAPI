namespace Message.Commands
{
    public class PaginationCommand
    {
        private int _pageNumber = 1;
        public int PageNumber
        {
            set
            {
                _pageNumber = (value < 1) ? _pageNumber : value;
            }
            get
            {
                return _pageNumber;
            }
        }
        
        private int _pageSize = 10;
        public int PageSize
        {
            set
            {
                _pageSize = (value > 20 || value < 1) ? _pageSize : value;
            }
            get
            {
                return _pageSize;
            }
        }
    }
}
