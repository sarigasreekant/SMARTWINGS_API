using System.Dynamic;
using System.Xml.Linq;

namespace DHBForex80.Server.Helper
{
    public class DynamicXML
    {
       public static dynamic ProcessDynamicXml(string filePath)
        {
            string xmlFilePath = "path/to/your/dynamicfile.xml";

            // Load XML data
            XDocument xmlDoc = XDocument.Load(xmlFilePath);
            // Parse XML and convert to a dynamic object
            var  dynamicData = ConvertXmlToDynamic(xmlDoc);

            return dynamicData;
            // Save the dynamic data to the database

        }

        static dynamic ConvertXmlToDynamic(XDocument xmlDoc)
        {
            dynamic dynamicData = new ExpandoObject();

            // Traverse XML elements and attributes dynamically
            TraverseXml(xmlDoc.Root, dynamicData);

            return dynamicData;
        }

        static void TraverseXml(XElement element, dynamic dynamicObject)
        {
            foreach (var childElement in element.Elements())
            {
                if (childElement.HasElements)
                {
                    var childObject = new ExpandoObject();
                    ((IDictionary<string, object>)dynamicObject)[childElement.Name.LocalName] = childObject;
                    TraverseXml(childElement, childObject);
                }
                else
                {
                    ((IDictionary<string, object>)dynamicObject)[childElement.Name.LocalName] = childElement.Value;
                }

                foreach (var attribute in childElement.Attributes())
                {
                    ((IDictionary<string, object>)dynamicObject)[attribute.Name.LocalName] = attribute.Value;
                }
            }
        }

    }
}
