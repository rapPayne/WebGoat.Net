using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Core
{
    public class CreditCard
    {
        #region Public properties
        /// <summary>The XML file in which credit card numbers are stored.</summary>
        public string Filename { get; set; }
        public string Username { get; set; }
        public string Number { get; set; }
        public DateTime Expiry { get; set; }
        public int CVV { get; set; }
        public string Name { get; set; }
        public int ExpiryMonth { get { return Expiry.Month; } }
        public int ExpiryYear { get { return Expiry.Year; } }
        #endregion
        #region Constructor
        public CreditCard()
        {
            Filename = string.Empty;
            Username = string.Empty;
            Number = string.Empty;
        }
        #endregion
        #region Public methods
        public void GetCardForUser()
        {
            XDocument document = ReadCreditCardFile();
            try
            {
                var xElement = document.Descendants("CreditCard").FirstOrDefault(c => c.Element("Username").Value.Equals(Username));
                if (!xElement.HasElements)
                    throw new NullReferenceException(string.Format("No card found for {0}.", Username));
                this.Username = Username;
                this.Expiry = Convert.ToDateTime(xElement.Element("Expiry").Value);
                this.Number = xElement.Element("Number").Value;
            }
            catch (IndexOutOfRangeException)     //File exists but has nothing in in.
            {
                CreateNewCreditCardFile();
            }
            catch (XmlException)     //File is corrupt. Delete and recreate.
            {
                CreateNewCreditCardFile();
            }
            catch (NullReferenceException)   //The row was not found.
            {
                throw new NullReferenceException(string.Format("Credit card for {0} was not found.", Username));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void SaveCardForUser()
        {
            if (CardExistsForUser())
                UpdateCardForUser();
            else
                InsertCardForUser();
        }
        /// <summary>Validates the card</summary>
        /// <returns>True if valid.  False otherwise.</returns>
        /// <remarks>
        /// This only validates according to Luhn's algorithm and date.  In the real world, we'd also
        /// query the credit card company.
        /// </remarks>
        public bool IsValid()
        {
            if (Expiry < DateTime.Today)
                return false;

            // Remove non-digits
            var creditCardNumber = Regex.Replace(this.Number, @"[^\d]", "");
            var number = creditCardNumber.ToCharArray();

            // Validate based on card type, first if tests length, second tests prefix
            // Use Luhn Algorithm to validate
            int sum = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (i % 2 == number.Length % 2)
                {
                    int n = number[i] * 2;
                    sum += (n / 10) + (n % 10);
                }
                else
                    sum += number[i];
            }
            return (sum % 10 == 0);
        }
        public string ChargeCard(decimal ChargeAmount)
        {
            //Here is where we'd actually charge the card if this were real.
            var code = new Random().Next(999999).ToString("000000");
            return code;
        }
        #endregion
        #region Private methods
        private XDocument ReadCreditCardFile()
        {
            var document = new XDocument();
            try
            {
                using (FileStream readStream = File.Open(Filename, FileMode.Open))
                {
                    var xr = new XmlTextReader(readStream);
                    document = XDocument.Load(xr);
                    xr.Close();
                }
            }
            catch (FileNotFoundException)    //File does not exist - Create it.
            {
                CreateNewCreditCardFile();
            }
            catch (IndexOutOfRangeException)     //File exists but has nothing in in.
            {
                CreateNewCreditCardFile();
            }
            catch (XmlException)     //File is corrupt. Delete and recreate.
            {
                CreateNewCreditCardFile();
            }
            catch (NullReferenceException)   //The row was not found.
            {
                throw new NullReferenceException(string.Format("Credit card for {0} was not found.", Username));
            }
            catch (Exception)
            {
                throw;
            }
            return document;
        }
        private void WriteCreditCardFile(XDocument XmlDocument)
        {
            try
            {
                using (var writeStream = File.Open(Filename, FileMode.Create))
                {
                    var writer = new StreamWriter(writeStream);
                    XmlDocument.Save(writer);
                    writer.Close();
                }
            }
            catch (FileNotFoundException)    //File does not exist - Create it.
            {
                CreateNewCreditCardFile();
            }
            catch (IndexOutOfRangeException)     //File exists but has nothing in in.
            {
                CreateNewCreditCardFile();
            }
            catch (XmlException)     //File is corrupt. Delete and recreate.
            {
                CreateNewCreditCardFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool CardExistsForUser()
        {
            var document = this.ReadCreditCardFile();
            try
            {
                var xElement = document.Descendants("CreditCard").FirstOrDefault(c => c.Element("Username").Value.Equals(Username));
                if (!xElement.HasElements)
                    throw new NullReferenceException(string.Format("No card found for {0}.", Username));
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        private void CreateNewCreditCardFile()
        {
            var document = new XDocument();
            document.Add(new XElement("CreditCards"));
            WriteCreditCardFile(document);
        }
        private void UpdateCardForUser()
        {
            XDocument document = this.ReadCreditCardFile();
            try
            {
                var xElement = document.Descendants("CreditCard").FirstOrDefault(c => c.Element("Username").Value.Equals(Username));
                xElement.Element("Expiry").Value = this.Expiry.ToString();
                xElement.Element("Number").Value = this.Number;
                WriteCreditCardFile(document);
            }
            catch (NullReferenceException)   //The row was not found.
            {
                throw new NullReferenceException(string.Format("Credit card for {0} was not found.", Username));
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void InsertCardForUser()
        {
            XDocument document = ReadCreditCardFile();
            try
            {
                var root = document.Root;
                root.Add(new XElement("CreditCard",
                    new XElement("Username", this.Username),
                    new XElement("Number", this.Number),
                    new XElement("Expiry", this.Expiry)
                    ));
                WriteCreditCardFile(document);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
