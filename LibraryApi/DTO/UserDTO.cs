using System.ComponentModel.DataAnnotations;

namespace LibraryApi.DTO
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage = "e-Mail is Required")]
        [EmailAddress(ErrorMessage ="Invalid e-Mail")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "e-Mail is Required")]
        public string password { get; set; }

        [Compare("Password", ErrorMessage = "The Field Password and Confirmation must be equals")]
        public string passwordConfirm { get; set; }
    }

    public class SignInUserDTO
    {
        [Required(ErrorMessage = "e-Mail is Required")]
        [EmailAddress(ErrorMessage = "Invalid e-Mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "e-Mail is Required")]
        public string password { get; set; }

    }

    public class ResponseAuthenticationDTO
    {
        public string JWTValue { get; set; }
        public UserInfoDTO UserInfo { get; set; }
     
    }

    public class UserInfoDTO
    {
        public string EMail { get; set; }
        public IEnumerable<ClaimDTO> Claims { get; set; }
    }

    public class ClaimDTO
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

}
