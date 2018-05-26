namespace NDC.SOAP.Services
{
    public interface IConfiguration
    {
        int AttachmentSize { get; set; }
        string TemplatePath { get; set; }
        string FromEmail { get; set; }
        string EmailProviderKey { get; set; }
    }
}