namespace App.Core.Domain.Entities
{
    public class AppSettings
    {
        public FileUpload FileUpload { get; private set; } = new FileUpload();
    }

    public class FileUpload
    {
        public string DestinationPath { get; set; }
    }
}