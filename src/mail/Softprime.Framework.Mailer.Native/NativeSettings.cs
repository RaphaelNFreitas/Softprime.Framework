namespace Softprime.Framework.Mailer.Native
{
    public class NativeSettings
    {
        public string EmailHost { get; set; }
        public string PasswordEmailHost { get; set; }
        public string SmtpEmailHost { get; set; }
        public int SmtpPortHost { get; set; }
        public bool EnableSsl { get; set; }
    }
}