using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SquizzWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "RestService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez RestService.svc ou RestService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class RestService : IRestService
    {
        //IRestService members
        public string JSONData(string id)
        {
            return "La requête JSON donne : " + id;
        }

        public string sayHelloTo(string name)
        {
            return "Hello " + name;
        }

        public string XMLData(string id)
        {
            return "La requête XML donne: " + id;
        }
    }
}
