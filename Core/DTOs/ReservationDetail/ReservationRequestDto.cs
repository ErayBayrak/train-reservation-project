using Core.DTOs.Train;

namespace Core.DTOs.ReservationDetail
{
    public class ReservationRequestDto
    {
        public TrainDto Train { get; set; }
        public int CountOfPassengerForReservation { get; set; }
        public bool IsPassengersAnotherWagon { get; set; }
    }
}
