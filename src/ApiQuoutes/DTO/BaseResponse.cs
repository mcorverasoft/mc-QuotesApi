namespace ApiQuoutes.DTO
{
    public class BaseResponse
    {
        public bool succesfull { get; set; }
        public int Status { get; set; }
        public String? Message { get; set; }
        public Object? Response { get; set; }
    }
}
