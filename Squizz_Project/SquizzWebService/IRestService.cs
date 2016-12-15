using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SquizzWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IRestService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IRestService
    {

        //return data to XML format
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{id}")]

        string XMLData(string id);

        //return data to JSON format
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]

        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "hello/{name}")]
        string sayHelloTo(string name);

    }
}
