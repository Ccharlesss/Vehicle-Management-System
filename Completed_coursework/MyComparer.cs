using System;
namespace Completed_coursework
{
    public class MyComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            return x.Get_Maker().CompareTo(y.Get_Maker());
        }

    }
}

