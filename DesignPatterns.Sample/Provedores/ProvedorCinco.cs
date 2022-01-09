using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Sample.Provedores
{
    public class ProvedorCinco: IProvedor
    {
        private readonly string _username;
        private readonly string _Password;

        public ProvedorCinco(string userName, string password)
        {
            _username = userName;
            _Password = password;
        }

        public void Publica(string nomeDoImovel, decimal valor, uint quartos)
        {

            var localFile = new NameValueCollection();
            localFile["Nome"] = nomeDoImovel;
            localFile["Valor"] = valor.ToString();
            localFile["Quartos"] = quartos.ToString();
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(_username, _Password);
                client.UploadValues("ftp://host/path.zip", WebRequestMethods.Ftp.UploadFile, localFile);
            }
        }
    }
}
