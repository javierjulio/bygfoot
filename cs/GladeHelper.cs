using System;
using System.IO;
using System.Xml;

namespace bygfoot
{
	public class GladeHelper
	{
		public static string ProcessGladeFile(string gladePath)
		{
			string processedPath = string.Format("{0}{1}{2}.mono.glade",
			                                     Path.GetDirectoryName(gladePath),
			                                     Path.DirectorySeparatorChar,
			                                     Path.GetFileNameWithoutExtension(gladePath));
			string processedInfoPath = string.Format("{0}.processed", gladePath);
			if (!File.Exists(processedPath))
				ProcessGladeFile(gladePath, processedPath, processedInfoPath);
			else
			{
				StreamReader reader = File.OpenText(processedInfoPath);
				DateTime lastWriteTime = DateTime.Parse(reader.ReadLine());
				reader.Close();

				FileInfo gladeFileInfo = new FileInfo(gladePath);
				TimeSpan tsDiff = gladeFileInfo.LastWriteTime - lastWriteTime;
				if (tsDiff.Seconds != 0)
					ProcessGladeFile(gladePath, processedPath, processedInfoPath);
			}

			return processedPath;
		}

		private static void ProcessGladeFile(string gladePath, string processedPath, string processedInfoPath)
		{
			XmlDocument document = new XmlDocument();
			document.PreserveWhitespace = true;
			document.Load(gladePath);
			
			XmlWriterSettings setttings = new XmlWriterSettings();
			setttings.Indent = true;
			using (XmlWriter writer = XmlWriter.Create(processedPath, setttings))
			{
				writer.WriteStartDocument();
				WriteNode(writer, document.DocumentElement);
				writer.WriteEndDocument();
				writer.Flush();
				writer.Close();
			}

			using (StreamWriter sw = File.CreateText(processedInfoPath))
			{
				FileInfo gladeFileInfo = new FileInfo(gladePath);
				sw.WriteLine(gladeFileInfo.LastWriteTime.ToString());
				sw.Flush();
				sw.Close();
			}
		}
		
		private static void WriteNode(XmlWriter writer, XmlNode nodeToWrite)
		{
			if (nodeToWrite.NodeType == XmlNodeType.Comment)
				writer.WriteComment(nodeToWrite.Value);
			else if (nodeToWrite.NodeType == XmlNodeType.Text)
			{
				writer.WriteValue(nodeToWrite.Value);
			}
			else if (nodeToWrite.NodeType == XmlNodeType.Whitespace)
			{
				writer.WriteWhitespace(nodeToWrite.Value);
			}
			else if (nodeToWrite.NodeType == XmlNodeType.SignificantWhitespace)
			{
				Console.WriteLine("SignificantWhitespace ignored");
			}
			else if (nodeToWrite.NodeType == XmlNodeType.Element)
			{
				string nodeName = nodeToWrite.Name;
				if (nodeName == "interface")
					nodeName = "glade-interface";
				else if (nodeName == "object")
					nodeName = "widget";
				
				writer.WriteStartElement(nodeName);
				// Write all attributes
				foreach (XmlAttribute attr in nodeToWrite.Attributes)
				{
					// Add tab attribute as packing child (Fix for Glade#)
					if (attr.Name == "type" && attr.Value == "tab")
					{
						XmlNode packingNode = nodeToWrite.SelectSingleNode("packing");
						if (packingNode != null)
						{
							XmlElement propNode = nodeToWrite.OwnerDocument.CreateElement("property");
							XmlAttribute attrType = nodeToWrite.OwnerDocument.CreateAttribute("name");
							attrType.Value = "type";
							propNode.Attributes.Append(attrType);
							propNode.AppendChild(nodeToWrite.OwnerDocument.CreateTextNode("tab"));
							packingNode.AppendChild(propNode);
						}
					}
					else
						writer.WriteAttributeString(attr.Name, attr.Value);
				}

				// Move accelerator after signal (Fix for Glade#)
				XmlNode acceleratorNode = nodeToWrite.SelectSingleNode("accelerator");
				if (acceleratorNode != null)
				{
					XmlNodeList signalNodeList = nodeToWrite.SelectNodes("signal");
					if (signalNodeList != null && signalNodeList.Count > 0)
						nodeToWrite.InsertAfter(acceleratorNode, signalNodeList[signalNodeList.Count - 1]);
				}

				// Write all child nodes
				foreach (XmlNode childNode in nodeToWrite.ChildNodes)
				{
					WriteNode(writer, childNode);
				}
				writer.WriteEndElement();
			}
		}
	}
}

