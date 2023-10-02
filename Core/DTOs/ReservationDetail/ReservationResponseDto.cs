namespace Core.DTOs.ReservationDetail
{
    public class ReservationResponseDto
    {
        public bool IsMakeReservation { get; set; }
        public List<ReservationDetailDto> DetailResidential { get; set; }
    }
}
