using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;
using System.Runtime.Remoting.Activation;
using System.Web.UI.WebControls;

namespace Assignment5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // Takes a URL for an XML document and an XML Schema document and verifies them. Returns error information.
        public string verification(string xmlUrl, string xsdUrl)
        {
            // resultant string 
            string result = "No Errors"; 
            string xml;
            var set = new XmlSchemaSet();

            // Creating a web client
            using (var wc = new WebClient())
            {
                try
                {
                    // Downloads the XML document using the URL
                    xml = wc.DownloadString(xmlUrl);

                    // Check if the downloaded content is a valid XML
                    try
                    {
                        var xd = new XmlDocument();
                        xd.LoadXml(xml);
                    }
                    catch (XmlException ex)
                    {
                        result = "The downloaded content is not a valid XML document";
                        return result;
                    }
                }
                catch (WebException ex)
                {
                    result = "Failed to download the XML document from the provided URL";
                    return result;
                }
            }
            // Loads xml string into XmlDocument object
            var xdocument = new XmlDocument(); 
            try
            {
                xdocument.Load(xmlUrl);
            }
            catch (XmlException ex)
            {
                result = "XML parsing error: " + ex.Message;
                return result;
            }

            var xdoc = XmlDocToXDoc(xdocument);
            var validationErrors = new List<string>(); // List to store validation errors

            try
            {
                // Loads the schema into the schema set
                set.Add(null, xsdUrl);

                // Tries to validate the XML document
                xdoc.Validate(set, (o, e) =>
                {
                    validationErrors.Add(e.Message); // Add validation error messages to the list
                });

                if (validationErrors.Count > 0)
                {
                    // If there are validation errors, concatenate them and set in the result
                    result = "XML validation errors: \n" + string.Join("\n", validationErrors);
                    return result;
                }
            }
            catch (Exception ex)
            {
                result = "XML validation encountered an error: " + ex.Message.ToString() + " You might want to check the filenames that are entered." ;
                return result;
            }


            return result;
        }

        private static XDocument XmlDocToXDoc(XmlDocument xdoc)
        {
            return XDocument.Load(new XmlNodeReader(xdoc));
        }
        public string SearchXmlWithDOM(string xmlFilePath, string searchKey)
        {
            // Initialising the result string
            string result = "";
            // Creating a new XmlDocument object
            XmlDocument xmlDoc = new XmlDocument();
            // Creating a web client
            string xml;
            using (var wc = new WebClient())
            {
                try
                {
                    // Downloads the XML document using the URL
                    xml = wc.DownloadString(xmlFilePath);

                    // Check if the downloaded content is a valid XML
                    try
                    {
                        xmlDoc.LoadXml(xml);
                    }
                    catch (XmlException ex)
                    {
                        result = "The downloaded content is not a valid XML document";
                        return result;
                    }
                }
                catch (WebException ex)
                {
                    result = "Failed to download the XML document from the provided URL";
                    return result;
                }
            }

            //Reading all the nodes
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("*");
            foreach (XmlNode node in nodes)
            {
                // If node name matches user searchkey then we add the value in the resultant string
                if (node.Name == searchKey)
                {
                    result += node.InnerText + " , ";
                }
                // If the node has attributes then we check whether attribute name matches the user searchkey then we add the value in the resultant string
                if (node.Attributes != null)
                {
                    foreach (XmlAttribute attribute in node.Attributes)
                    {
                        if (attribute.Name == searchKey)
                        {
                            result += "Attribute Value: " + attribute.Value + " , ";
                            result += "Parent Element: " + node.Name + " | ";
                        }
                    }
                }
            }
            if (result == "")
            {
                result = "Search key did not match any node's value or attribute's value. Please put another search key.";
                return result;
            }
            // returning the string after removing the last two characters which will be space or |  
            return result.Substring(0, result.Length - 2);
        }

    }
}
