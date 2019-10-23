using System.Text;

namespace MicroServices.Gateway.App.Builders
{
    public class RequestUrlBuider
    {
        private StringBuilder _builder;

        public RequestUrlBuider(string baseUrl)
        {
            _builder = new StringBuilder(baseUrl);
        }

        public RequestUrlBuider Append(string value)
        {
            _builder.Append("/");
            _builder.Append(value);

            return this;
        }

        public string Build()
        {
            return _builder.ToString();
        }
    }
}
