using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test2
{
    public class SendMail
    {
        public void Register(UserModel user)
        {
            var _userService = new UserService();
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(user.Email);
                message.Subject = "Register";
                message.From = new System.Net.Mail.MailAddress("admin@hotmail.com");
                message.Body = "Thank you for your register";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Send(message);

            }
            catch (Exception)
            {
            }

            bool validate = true;
            string errorMessage = "";
            if (String.IsNullOrEmpty(user.UserName))
            {
                errorMessage += "You must specify a username.";

                validate = false;
            }

            if (String.IsNullOrEmpty(user.Email))
            {
                errorMessage += "You must specify an email address.";
                validate = false;
            }

            else if (!Regex.IsMatch(user.Email, "^[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,6}$.", RegexOptions.IgnoreCase))
            {
                errorMessage += "You must specify a valid email address.";
                validate = false;
            }

            bool isExisted = false;
            var existedUser = _userService.GetUserByUsername(user.UserName);

            if (existedUser != null)
            {
                isExisted = true;
            }
            else
            {
                isExisted = false;
            }

            if (isExisted)
            {
                errorMessage += "User with that username and/or email already exists.";
            }

            if (user.Password == null || user.Password.Length < 6)
            {
                errorMessage += string.Format("You must specify a password of {0} or more characters.", 6);
            }

            if (!String.Equals(user.Password, user.ConfirmPassword, StringComparison.Ordinal))
            {
                errorMessage += "The new password and confirmation password do not match.";
            }

            if (validate)
            {
                Regex RgxUrl = new Regex("[^a-z0-9]");
                var isContainsSpecialCharacters = RgxUrl.IsMatch(user.UserName);
                if (!isContainsSpecialCharacters)
                {
                    _userService.SaveUser(user);
                }
            }

        }
    }
}
