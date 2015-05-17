using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using System.Web;
using System.Collections;

namespace iuguapi
{
    public class APIBase
    {
        #region instancies
        protected Dictionary<string, string> Headers = new Dictionary<string, string>();

        private string _version;
        private string _endpoint;
        private string _apiVersion;
        private string _apiKey;
        private string _baseURI; 
        #endregion

        #region properties
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string Endpoint
        {
            get { return _endpoint; }
            set { _endpoint = value; }
        }
        public string ApiVersion
        {
            get { return _apiVersion; }
            set { _apiVersion = value; }
        }
        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; }
        }
        public string BaseURI
        {
            get { return _baseURI; }
            set { _baseURI = value; }
        } 
        #endregion

        #region constructor
        public APIBase()
        {
            _version = "1.0.5";
            _apiVersion = "v1";
            _endpoint = "https://api.iugu.com";

            if (System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"] != null
                || string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"]))
            {
                _apiKey = System.Configuration.ConfigurationManager.AppSettings["iuguApiKey"];
            }
            else
            {
                throw new MissingFieldException("Chave de API não configurada. Verifique a chave iuguApiKey em AppSettings de seu arquivo .config");
            }

            _baseURI = Endpoint + "/" + ApiVersion;

            Headers.Add("Accept", "application/json");
            Headers.Add("Accept-Charset", "utf-8");
            Headers.Add("User-Agent", "Iugu DOTNETLibrary");
            Headers.Add("Accept-Language", "pt-br;q=0.9,pt-BR");
            Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(ApiKey)));
        } 
        #endregion

        #region helper
        private string GetQueryString(object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            // Get all properties on the object
            var properties = request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        }
        #endregion

        #region transaction methods
        protected async Task<TResult> GetAsync<TResult>() where TResult : ITransation
        {
            try
            {
                return await (BaseURI)
                        .WithHeaders(Headers)
                        .GetJsonAsync<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> GetAsync<TResult>(string uid) where TResult : ITransation
        {
            try
            {
                return await (BaseURI + "/" + uid)
                        .WithHeaders(Headers)
                        .GetJsonAsync<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> GetAsync<TResult>(object data) where TResult : ITransation
        {
            try
            {
                var sBase = (BaseURI + "?" + GetQueryString(data));

                return await sBase
                        .WithHeaders(Headers)
                        .GetJsonAsync<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> GetListAsync<TResult>(object data) where TResult : ITransation
        {
            try
            {
                var sBase = (BaseURI + "?" + GetQueryString(data));

                return (TResult)await sBase
                        .WithHeaders(Headers)
                        .GetJsonListAsync();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> PostAsync<TResult>(object data) where TResult : ITransation
        {
            try
            {
                return await BaseURI
                        .WithHeaders(Headers)
                        .PostJsonAsync(data)
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> PostAsync<TResult>() where TResult : ITransation
        {
            try
            {
                return await BaseURI
                        .WithHeaders(Headers)
                        .PostAsync()
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> PostAsync<TResult>(string uid) where TResult : ITransation
        {
            try
            {
                return await (BaseURI + "/" + uid)
                        .WithHeaders(Headers)
                        .PostAsync()
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> PostWithoutApiKeyAsync<TResult>(object data) where TResult : ITransation
        {
            try
            {
                return await BaseURI
                        .WithHeaders(Headers)
                        .PostJsonAsync(data)
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> PutAsync<TResult>(string uid, object data) where TResult : ITransation
        {
            try
            {
                return await (BaseURI + "/" + uid)
                        .WithHeaders(Headers)
                        .PutJsonAsync(data)
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> PutAsync<TResult>(string uid) where TResult : ITransation
        {
            try
            {
                return await (BaseURI + "/" + uid)
                        .WithHeaders(Headers)
                        .PutAsync()
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        }

        protected async Task<TResult> DeleteAsync<TResult>(string uid) where TResult : ITransation
        {
            try
            {
                return await (BaseURI + "/" + uid)
                        .WithHeaders(Headers)
                        .DeleteAsync()
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();
                result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                result.success = false;
                return result;
            }
        } 
        #endregion
    }
}
