﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace Squizz_Project.SquizzWebService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Question", Namespace="http://schemas.datacontract.org/2004/07/SquizzWebService")]
    public partial class Question : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string NameField;
        
        private string UrlImageField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UrlImage {
            get {
                return this.UrlImageField;
            }
            set {
                if ((object.ReferenceEquals(this.UrlImageField, value) != true)) {
                    this.UrlImageField = value;
                    this.RaisePropertyChanged("UrlImage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Player", Namespace="http://schemas.datacontract.org/2004/07/SquizzWebService")]
    public partial class Player : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string MailField;
        
        private string PasswordField;
        
        private int ScoreField;
        
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mail {
            get {
                return this.MailField;
            }
            set {
                if ((object.ReferenceEquals(this.MailField, value) != true)) {
                    this.MailField = value;
                    this.RaisePropertyChanged("Mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Score {
            get {
                return this.ScoreField;
            }
            set {
                if ((this.ScoreField.Equals(value) != true)) {
                    this.ScoreField = value;
                    this.RaisePropertyChanged("Score");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SquizzWebService.IDataManagement")]
    public interface IDataManagement {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/GetQuestionById", ReplyAction="http://tempuri.org/IDataManagement/GetQuestionByIdResponse")]
        System.Threading.Tasks.Task<Squizz_Project.SquizzWebService.Question> GetQuestionByIdAsync(int idQuestion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/ConnectionCheckPlayer", ReplyAction="http://tempuri.org/IDataManagement/ConnectionCheckPlayerResponse")]
        System.Threading.Tasks.Task<string> ConnectionCheckPlayerAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/UpdateRandomPassword", ReplyAction="http://tempuri.org/IDataManagement/UpdateRandomPasswordResponse")]
        System.Threading.Tasks.Task<string> UpdateRandomPasswordAsync(string mail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/GetPlayerScoreList", ReplyAction="http://tempuri.org/IDataManagement/GetPlayerScoreListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Squizz_Project.SquizzWebService.Player>> GetPlayerScoreListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/GetPlayerById", ReplyAction="http://tempuri.org/IDataManagement/GetPlayerByIdResponse")]
        System.Threading.Tasks.Task<Squizz_Project.SquizzWebService.Player> GetPlayerByIdAsync(int idPlayer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/GetPlayerByUsername", ReplyAction="http://tempuri.org/IDataManagement/GetPlayerByUsernameResponse")]
        System.Threading.Tasks.Task<Squizz_Project.SquizzWebService.Player> GetPlayerByUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/ForgotPassword", ReplyAction="http://tempuri.org/IDataManagement/ForgotPasswordResponse")]
        System.Threading.Tasks.Task<string> ForgotPasswordAsync(string mail, int idPlayer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/IncrementScorePlayer", ReplyAction="http://tempuri.org/IDataManagement/IncrementScorePlayerResponse")]
        System.Threading.Tasks.Task<string> IncrementScorePlayerAsync(int idPlayer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDataManagement/SignupPlayer", ReplyAction="http://tempuri.org/IDataManagement/SignupPlayerResponse")]
        System.Threading.Tasks.Task<string> SignupPlayerAsync(string username, string password, string mail);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataManagementChannel : Squizz_Project.SquizzWebService.IDataManagement, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataManagementClient : System.ServiceModel.ClientBase<Squizz_Project.SquizzWebService.IDataManagement>, Squizz_Project.SquizzWebService.IDataManagement {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DataManagementClient() : 
                base(DataManagementClient.GetDefaultBinding(), DataManagementClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IDataManagement.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataManagementClient(EndpointConfiguration endpointConfiguration) : 
                base(DataManagementClient.GetBindingForEndpoint(endpointConfiguration), DataManagementClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataManagementClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DataManagementClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataManagementClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DataManagementClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DataManagementClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<Squizz_Project.SquizzWebService.Question> GetQuestionByIdAsync(int idQuestion) {
            return base.Channel.GetQuestionByIdAsync(idQuestion);
        }
        
        public System.Threading.Tasks.Task<string> ConnectionCheckPlayerAsync(string username, string password) {
            return base.Channel.ConnectionCheckPlayerAsync(username, password);
        }
        
        public System.Threading.Tasks.Task<string> UpdateRandomPasswordAsync(string mail) {
            return base.Channel.UpdateRandomPasswordAsync(mail);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Squizz_Project.SquizzWebService.Player>> GetPlayerScoreListAsync() {
            return base.Channel.GetPlayerScoreListAsync();
        }
        
        public System.Threading.Tasks.Task<Squizz_Project.SquizzWebService.Player> GetPlayerByIdAsync(int idPlayer) {
            return base.Channel.GetPlayerByIdAsync(idPlayer);
        }
        
        public System.Threading.Tasks.Task<Squizz_Project.SquizzWebService.Player> GetPlayerByUsernameAsync(string username) {
            return base.Channel.GetPlayerByUsernameAsync(username);
        }
        
        public System.Threading.Tasks.Task<string> ForgotPasswordAsync(string mail, int idPlayer) {
            return base.Channel.ForgotPasswordAsync(mail, idPlayer);
        }
        
        public System.Threading.Tasks.Task<string> IncrementScorePlayerAsync(int idPlayer) {
            return base.Channel.IncrementScorePlayerAsync(idPlayer);
        }
        
        public System.Threading.Tasks.Task<string> SignupPlayerAsync(string username, string password, string mail) {
            return base.Channel.SignupPlayerAsync(username, password, mail);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDataManagement)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IDataManagement)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:11969/DataManagement.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return DataManagementClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IDataManagement);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return DataManagementClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IDataManagement);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IDataManagement,
        }
    }
}
