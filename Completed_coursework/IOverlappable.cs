using System;
namespace Completed_coursework
{
    public interface IOverlappable
    {
        // Method assess if a schedule entered by the user matches a reservation on the reservation_list

        public bool Does_Overlap_V2(Schedule other);
    }
}

