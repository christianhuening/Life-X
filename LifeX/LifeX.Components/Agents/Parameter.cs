using System;

namespace LifeX.Runtime
{
    public static class Parameter
    {
        public static T Required<T>(string name) where T : IConvertible
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (value == null)
            {
                throw new MissingParameterException(); // FIXME: add message containing `name`
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }
        
        public static T Optional<T>(string name, T defaultValue) where T : IConvertible
        {
            try
            {
                return Required<T>(name);
            }
            catch (MissingParameterException ex)
            {
                return defaultValue;
            }
        }
    }
}