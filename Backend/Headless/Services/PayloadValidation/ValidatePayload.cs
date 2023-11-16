using Headless.Models;
using System.Linq;

namespace Headless.Services.PayloadValidation
{
    public class ValidatePayload
    {
        private bool _isValid = true;
        private UserPayload _payload;
        public string _errorMessage;
        public ValidatePayload(UserPayload payload)
        {
            _payload = payload;
        }

        public bool RunChecks()
        {
            if (UserLengthCheck())
            {
                if (UserIntegrityCheck())
                {

                }

            }
            return _isValid;
        }

        private bool UserIntegrityCheck()
        {
            List<string> invalidData = ReadInvalidData("C:\\Users\\micha\\OneDrive\\Desktop\\Michael Development\\ChatSky\\Backend\\Headless\\Services\\PayloadValidation\\InvalidUsername.txt");
            List<string> passwordData = ReadInvalidData("C:\\Users\\micha\\OneDrive\\Desktop\\Michael Development\\ChatSky\\Backend\\Headless\\Services\\PayloadValidation\\InvalidPassword.txt");

            foreach (var data in invalidData)
            {
                if (_payload.Username.Contains(data))
                {
                    _isValid = false;
                    _errorMessage = "Username does not meet requirements";
                    break;
                }
            }

            foreach (var data in passwordData)
            {
                if (_payload.Password.Contains(data))
                {
                    _isValid = false;
                    _errorMessage = "Password does not meet requirements";
                    break;
                }
            }
            
            return _isValid;
        }

        private List<string> ReadInvalidData(string v)
        {
            List<string> data = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(v);

                data.AddRange(lines);
            }catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
            return data;

        }

        private bool UserLengthCheck()
        {

            if (!(_payload.Username.Length >= 5) || !(_payload.Username.Length <= 15))
            {
                _isValid = false;
            }
            if (!(_payload.Password.Length >= 5) || !(_payload.Password.Length <= 15))
            {
                _isValid = false;
            }
            return _isValid;
        }
    }
}
