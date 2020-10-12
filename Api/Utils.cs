namespace Api
{
    public static class Utils
    {
        public static int PageCount(int total, int pageSize)
        {
            if (total == 0)
                return 1;

            return total % pageSize != 0
                ? total / pageSize + 1
                : total / pageSize;
        }
    }
}
