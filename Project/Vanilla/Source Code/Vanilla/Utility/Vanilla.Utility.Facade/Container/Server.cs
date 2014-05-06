using BinAff.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using VanAcc = Vanilla.Guardian.Facade.Account;

namespace Vanilla.Utility.Facade.Container
{

    public abstract class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            throw new System.NotImplementedException();
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            throw new System.NotImplementedException();
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            new VanAcc.Server(new VanAcc.FormDto()).Logout();
        }

        public List<String> SaveRecentFile(String documentPath, String xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            String category = this.GetRecentFileNodeName();
            XmlNode rootNode = xmlDoc.ChildNodes[0].SelectSingleNode(category);

            XmlNodeList duplicateList = xmlDoc.SelectNodes("Recent/" + category + "/Document[@Path='" + documentPath + "']");
            if (duplicateList != null && duplicateList.Count > 0)
            {
                foreach (XmlNode node in duplicateList)
                {
                    rootNode.RemoveChild(node);
                }
            }
            
            XmlElement element = xmlDoc.CreateElement("Document");
            XmlAttribute attr = xmlDoc.CreateAttribute("Path");
            attr.Value = documentPath;
            element.Attributes.Append(attr);

            rootNode.AppendChild(element);
            if (rootNode.ChildNodes.Count > 10) rootNode.RemoveChild(rootNode.FirstChild); //Need to remove hard coding of count

            xmlDoc.Save(xmlFilePath);
            
            return ReadRecentFile(xmlFilePath); //Need to remove IO
        }

        protected abstract String GetRecentFileNodeName();

        public List<String> ReadRecentFile(String xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNode rootNode = xmlDoc.ChildNodes[0].SelectSingleNode(this.GetRecentFileNodeName());
            if (rootNode.ChildNodes != null && rootNode.ChildNodes.Count > 0)
            {
                List<String> fileList = new List<String>();
                foreach (XmlNode file in rootNode.ChildNodes)
                {
                    fileList.Add(file.Attributes["Path"].Value);
                }
                return fileList;
            }
            return null;
        }

        public void RemoveRecentFile(String xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            xmlDoc.ChildNodes[0].SelectSingleNode(this.GetRecentFileNodeName()).RemoveAll();
            xmlDoc.Save(xmlFilePath);
        }

    }

}
