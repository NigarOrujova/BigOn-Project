namespace BigOn.Domain.AppCode.Infrastructure
{
    public class PageableModel
    {
        int pageIndex;
        int pageSize;
        public int PageIndex
        {
            get
            {
                if (pageIndex < 1)
                {
                    return 1;
                }

                return pageIndex;
            }
            set
            {
                if (value < 1)
                    pageIndex = 1;
                else
                {
                    pageIndex = value;
                }
            }
        }
        public virtual int PageSize
        {
            get
            {
                if (pageSize <= 2)
                {
                    return 2;
                }

                return pageSize;
            }
            set
            {
                if (value < 2)
                {
                    pageSize = 2;
                }
                else
                {
                    pageSize = value;
                }
            }
        }

        public int SkipSize
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }
    }
}
