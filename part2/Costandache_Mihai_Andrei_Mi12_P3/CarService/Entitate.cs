using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace CarService
{
    /// <summary>
    /// Clasa de baza a entitatilor care apar in context.
    /// </summary>
    [DataContract(IsReference = true)]
    public class Entitate
    {
        /// <summary>
        /// Returneaza informatii de baza despre entitate, nu si entitatile asociate sau cheile straine.
        /// </summary>
        /// <returns>Informatii.</returns>
        public string GetInfo()
        {
            var typeName = GetType().Name.Split('_')[0];
            StringBuilder text = new StringBuilder(typeName+": ");
            foreach(var prop in GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                if (!prop.PropertyType.IsGenericType && !prop.PropertyType.IsSubclassOf(typeof(Entitate)) && !(prop.Name.EndsWith("Id") && prop.Name!=typeName+"Id"))
                    text.AppendFormat("{0}={1} ", prop.Name, prop.GetValue(this, null));
            return text.ToString();
        }
    }
}
