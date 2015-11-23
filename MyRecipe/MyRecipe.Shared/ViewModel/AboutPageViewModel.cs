using GalaSoft.MvvmLight;
using MyRecipe.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Email;

namespace MyRecipe.ViewModel
{
    public class AboutPageViewModel : ViewModelBase
    {
        public DelegateCommand GoLoveCommand { get; set; }
        public DelegateCommand GoMailCommand { get; set; }
        public DelegateCommand GoWeiboCommand { get; set; }

        private List<string> strUpdate;

        public List<string> StrUpdate
        {
            get { return strUpdate; }
            set
            {
                strUpdate = value;
                RaisePropertyChanged("StrUpdate");
            }
        }
        private string version;

        public string Version
        {
            get { return version; }
            set
            {
                version = value;
                RaisePropertyChanged("Version");
            }
        }
        public AboutPageViewModel()
        {
            GoLoveCommand = new DelegateCommand();
            GoLoveCommand.ExecuteAction = new Action<object>(GoLove);
            GoMailCommand = new DelegateCommand();
            GoMailCommand.ExecuteAction = new Action<object>(GoMail);
            GoWeiboCommand = new DelegateCommand();
            GoWeiboCommand.ExecuteAction = new Action<object>(GoWeibo);

            Version = "1.0.0";
            StrUpdate = new List<string>();
            StrUpdate.Add("暂无");
        }

        private async void GoMail(object obj)
        {
            var emailMessage = new EmailMessage();
            string body = "";
            emailMessage.Body = body;
            string emailAddress = "jevons@hotmail.com";
            emailMessage.To.Add(new EmailRecipient(emailAddress));
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        private async void GoWeibo(object obj)
        {
            UriBuilder uriSite = new UriBuilder("http://weibo.com/jevonsflash");
            await Windows.System.Launcher.LaunchUriAsync(uriSite.Uri);
        }

        private async void GoLove(object obj)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp"));
        }
    }
}
