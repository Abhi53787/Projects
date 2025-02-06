//using System.Runtime.Intrinsics.Arm;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace TaskUser.Pages.Account
//{
//    [AllowAnonymous]
//    [BindProperties]
//    public class LoginModel : PageModel
//    {

//        public string Email { get; set; }
//        public string Password { get; set; }
//        public void OnGet()
//        {
//        }
//        public async Task <IActionResult> OnPost(string ReturnUrl="")
//        {
//            bool validatesUser = false;
//            if(Email=="admin" && Password == "admin")
//            {
//                validatesUser = true;
//            }
//            Console.WriteLine(Password);


//            if (validatesUser)
//            {
//                List<Claim> claims = new List<Claim>();
//                Claim claim = new Claim(ClaimTypes.Email, Email);


//                //adding Email to claim claimtypes.Email is enum we are adding emailfor that
//                claims.Add(claim);
//                ClaimsIdentity identity= new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

//                await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
//                return Redirect(ReturnUrl);
//            }
//            ViewData["error-msg"] = "Invalid credential";
//            return Page();

//        }
//        public static byte[] GenerateKey()
//        {
//            using(Aes aes = Aes.Create())
//            {
//                aes.GenerateKey();
//                return aes.Key;
//            }
//        }
//    }
//}
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaskUser.Pages.Account
{
    [AllowAnonymous]
    [BindProperties]
    public class LoginModel : PageModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string ReturnUrl = "")
        {
            bool validatesUser = false;

            // Encrypt the password before printing it
            byte[] key = GenerateKey();
            byte[] iv = GenerateIV();
          
            if (Email == "admin" && Password == "admin")
            {
                validatesUser = true;
            }

            string encryptedPassword = EncryptPassword(Password, key, iv);
            Console.WriteLine($"Encrypted Password: {encryptedPassword}");


            if (validatesUser)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, Email)
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return Redirect(ReturnUrl);
            }

            ViewData["error-msg"] = "Invalid credential";
            return Page();
        }

        // ✅ Generate a random Key
        public static byte[] GenerateKey()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        // ✅ Generate a random IV
        public static byte[] GenerateIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        // ✅ Encrypt the password using AES
        public static string EncryptPassword(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
