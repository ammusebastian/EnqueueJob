using System;

namespace EnqueueJob.Services
{
    public class JobService : IJobService
    {
        public int[] SortArray(int[] intArray)
        {
            Array.Sort(intArray);
            return intArray;
        }
    }
}
