namespace ABE_Lojista.Models
{
    public class OrderAcceptanceResponse : BaseResponseDTO
    {
        public int OrderId { get; set; }
        public bool AcceptOrder { get; set; }
    }
}