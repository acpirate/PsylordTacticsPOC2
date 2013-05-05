using UnityEngine;
using System.Collections;
using System.Xml;


public class XMLHandler {
		
	public static string ExtractXMLString(XmlNode inNode, string childName) {		
		return inNode.SelectNodes(childName).Item(0).InnerText;		
	}
	
}
