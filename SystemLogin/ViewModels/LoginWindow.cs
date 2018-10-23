
namespace SystemLogin.ViewModels
{
using ReactiveUI;
    using System;
    using System.Threading;
  
    public class LoginWindow : ReactiveObject
    {
        private readonly Model.DataHandling _login;
        private string _username;
        private string _password;
        private int _maxAllowedLoginAttempts = 2;
        private int _loginAttempts;
        private string _errorMessage;
        private ReactiveCommand TryLogin;
        private string _messageColor;

        public string UserName
        {
            get =>  _username; 
            set =>  this.RaiseAndSetIfChanged(ref _username, value); 
        }

        public string Password
        {
            get =>  _password; 
            set =>  this.RaiseAndSetIfChanged(ref _password, value); 
        }

        public LoginWindow(Model.DataHandling login)
        {
            _login = login;

            this.WhenAnyValue(x => x.UserName).Subscribe(n => _login.UserName = n);
            this.WhenAnyValue(x => x.Password).Subscribe(p => _login.Password = p);

            TryLogin = ReactiveCommand.Create(() =>
            {
                if (LoginAttempts >= MaxAllowedLoginAttempts)
                {
                    ErrorMessage = "You have exceeded the \nmax allowed number of \nlogin attempts";
                    Timer t = new Timer(closeProgram, null, 2000, 2000);
                }
                else if (!_login.checkLogin())
                {
                    ErrorMessage = "Username and/or password \nincorrect";
                    MessageColor = "Red";
                }
                else
                {
                    ErrorMessage = "Login Successful";
                    MessageColor = "Green";
                }
                LoginAttempts++;
            });
        }

        private void closeProgram(object state)
        {
            Environment.Exit(0);
        }

        public int LoginAttempts
        {
            get => _loginAttempts;
            set => this.RaiseAndSetIfChanged(ref _loginAttempts, value);
        }

        public int MaxAllowedLoginAttempts
        {
            get => _maxAllowedLoginAttempts;
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public string MessageColor
        {
            get => _messageColor;
            set => this.RaiseAndSetIfChanged(ref _messageColor, value);
        }

        public ReactiveCommand LoginButton => TryLogin;
    }
}
