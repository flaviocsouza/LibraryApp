namespace LibraryApi.RequestParameters
{
    public class LendBookRequest
    {
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
    }
}
