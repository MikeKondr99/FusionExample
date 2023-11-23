using HotChocolate.Language;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Files
{
    public class UpperCaseString
    {
        private string value;
        public string Value => value;
        public UpperCaseString(string value)
        {
            this.value = value.ToUpper();
        }

        public override string ToString()
        {
            return this.Value;
        }

        public static implicit operator string(UpperCaseString x) => x.Value;
        public static implicit operator UpperCaseString(string x) => new(x);
    }

    public class UpperCaseStringType : ScalarType<UpperCaseString, StringValueNode>
    {

        public UpperCaseStringType() : base("UpperCaseStringType", BindingBehavior.Implicit)
        {
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            return ParseValue(resultValue);
        }

        protected override UpperCaseString ParseLiteral(StringValueNode valueSyntax)
        {
            return new UpperCaseString(valueSyntax.Value);
        }

        protected override StringValueNode ParseValue(UpperCaseString runtimeValue)
        {
            return new(runtimeValue.Value);
        }
    }

    public class UpperCaseStringConverter : ValueConverter<UpperCaseString, string>
    {
        public UpperCaseStringConverter()
        : base(
              x => x.Value,
              x => new UpperCaseString(x)
              ) { }
    }
}
