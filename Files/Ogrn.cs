using HotChocolate.Language;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yarp.ReverseProxy.Transforms.Builder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Files
{
    public class Ogrn
    {
        private string value;
        public string Value => value;
        public Ogrn(string value)
        {
            if (value.Length == 13)
            {
                if (long.TryParse(value, out long tempOgrn))
                {
                    if ((tempOgrn / 10) % 11 == tempOgrn % 10)
                    {
                        this.value = value;
                        return;
                    }
                }
            }
                throw new Exception("{0} DFFD");
        }

        public override string ToString()
        {
            return this.Value;
        }

        public static implicit operator string(Ogrn x) => x.Value;
        public static implicit operator Ogrn(string x) => new(x);
    }

    public class OgrnType : ScalarType<Ogrn, StringValueNode>
    {
        public OgrnType() : base("OgrnType", BindingBehavior.Implicit)
        {
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            return ParseValue(resultValue);
        }

        protected override Ogrn ParseLiteral(StringValueNode valueSyntax)
        {
            return new Ogrn(valueSyntax.Value);
        }

        protected override StringValueNode ParseValue(Ogrn runtimeValue)
        {
            return new(runtimeValue.Value);
        }
    }

    public class OgrnConverter : ValueConverter<Ogrn, string>
    {
        public OgrnConverter()
        : base(
              x => x.Value,
              x => new Ogrn(x)
              ) { }
    }
}
