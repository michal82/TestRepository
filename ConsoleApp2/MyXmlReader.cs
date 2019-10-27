using ConsoleApp2.MappingClasses;
using ConsoleApp2.Validation;
using DataBaseLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    public class MyXmlReader
    {
        private readonly string _xmlSchemaUrl = "./XML/Data.xsd";
        private readonly string _targetNamespace = "http://creditinfo.com/schemas/Sample/Data";
        private readonly Database _database = new Database();

        public async Task ReadXml(Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(Contract), "http://creditinfo.com/schemas/Sample/Data");

            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(this._targetNamespace, this._xmlSchemaUrl);
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += ValidationCallBack;
            settings.Async = true;
            XmlDocument doc = new XmlDocument();

            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (await reader.ReadAsync())
                {
                    if (reader.Name == "Contract")
                    {
                        var contract = (Contract)serializer.Deserialize(reader);
                        var validations = Validate(contract);
                        validations.ForEach(x => x.Start());
                    }
                }
            }
        }

        List<Task> Validate(Contract contract)
        {
            List<Task> listOfTasks = new List<Task>();

            List<IValidationRule<Contract>> contractRules = new List<IValidationRule<Contract>>
            {
                new DateAccountOpenedRule(),
                new DateOfLastPaymentRule(),
                new GuaranteeAmountRule()
            };

            foreach(var rule in contractRules)
            {
                if (!rule.Validate(contract))
                {
                    listOfTasks.Add(_database.WriteValidationErrorToDbAsync(rule.Error));
                }
            }

            List<IValidationRule<Individual>> individualRules = new List<IValidationRule<Individual>>
            {
                new DateOfBirthRule()
            };

            foreach (var individual in contract.Individual)
            {
                foreach(var individualRule in individualRules)
                {
                    if (!individualRule.Validate(individual))
                    {
                        listOfTasks.Add(_database.WriteValidationErrorToDbAsync(individualRule.Error));
                    }
                }
            }
            return listOfTasks;
        }

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine($"Validation Error:\n   {e.Message}\n");
        }
    }
}
