using Org.BouncyCastle.Asn1.Mozilla;

namespace ComputerShopAPI.Models.DTOs
{
    public class UpdateComputerDTO
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Display { get; set; }
        public int Memory { get; set; }
    }
}
