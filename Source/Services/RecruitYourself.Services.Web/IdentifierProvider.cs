namespace RecruitYourself.Services.Web
{
    using System;
    using System.Text;
    using Common.Constants;
    using Contracts;

    public class IdentifierProvider : IIdentifierProvider
    {
        public int DecodeId(string urlId)
        {
            var base64EncodedBytes = Convert.FromBase64String(urlId);
            var bytesAsString = Encoding.UTF8.GetString(base64EncodedBytes);
            bytesAsString = bytesAsString.Replace(ServiceLayerConstants.Salt, string.Empty);
            return int.Parse(bytesAsString);
        }

        public string EncodeId(int id)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(id + ServiceLayerConstants.Salt);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
