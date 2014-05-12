using BinAff.Core;
using System;
using System.Collections.Generic;
using System.Xml;

using VanAcc = Vanilla.Guardian.Facade.Account;
using ArtfFac = Vanilla.Utility.Facade.Artifact;

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

        public List<XmlBucket> SaveRecentFile(String documentPath, String artifactComponentType, String xmlFilePath)
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
            attr = xmlDoc.CreateAttribute("Code");
            attr.Value = artifactComponentType;
            element.Attributes.Append(attr);

            rootNode.AppendChild(element);
            if (rootNode.ChildNodes.Count > 10) rootNode.RemoveChild(rootNode.FirstChild); //Need to remove hard coding of count

            xmlDoc.Save(xmlFilePath);
            
            return ReadRecentFile(xmlFilePath); //Need to remove IO
        }

        protected abstract String GetRecentFileNodeName();

        public abstract ArtfFac.Category GetCategory();

        public List<XmlBucket> ReadRecentFile(String xmlFilePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNode rootNode = xmlDoc.ChildNodes[0].SelectSingleNode(this.GetRecentFileNodeName());
            if (rootNode.ChildNodes != null && rootNode.ChildNodes.Count > 0)
            {
                List<XmlBucket> fileList = new List<XmlBucket>();
                foreach (XmlNode file in rootNode.ChildNodes)
                {
                    fileList.Add(new XmlBucket
                    {
                        Path = file.Attributes["Path"].Value,
                        Code = file.Attributes["Code"].Value
                    });
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

        public class XmlBucket
        {

            public String Path { get; set; }
            public String Code { get; set; }

        }

        public string GetComponentFormType(String code)
        {
            return new Module.Helper(new Module.Dto
            {
                Code = code,
            }, this.GetCategory()).ModuleFormType;
        }

    }

}
