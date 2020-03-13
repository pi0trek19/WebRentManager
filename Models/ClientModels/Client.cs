using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    /// <summary>
    /// Klasa reprezentująca klienta
    /// </summary>
    public class Client
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Typ klienta - Firma, działalność lub osoba prywatna
        /// </summary>
        public ClientType ClientType { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        /// <summary>
        /// NIP dla firmy i działalności, PESEL dla prywatnego
        /// </summary>
        public string IdNumber1 { get; set; }
        /// <summary>
        /// KRS dla Firmy i działalności, nr dowodu dla prywatnego
        /// </summary>
        public string IdNumber2 { get; set; }
        /// <summary>
        /// Tylko REGON dla firmy
        /// </summary>
        public string IdNumber3 { get; set; }
        public string RepName { get; set; }
        public string RepMail { get; set; }
        public string RepPhone { get; set; }
        public List<ClientFile> ClientFiles { get; set; }
    }
}
