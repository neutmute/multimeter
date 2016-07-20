﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Multimeter.Web
{
    /// <summary>
    /// Meter timings on old school ASMX soap interfaces
    /// </summary>
    public class SoapLogger : ISoapLogger
    {
        #region Methods
        private const string ItemsCacheKeySoapMetric = "Multimeter.Web.SoapLogger.Metric";
        #endregion
        
        #region Internal Methods

        internal SoapMetric GetSoapMetric(Stream receiveStream)
        {
            var originalPosition = receiveStream.Position;
            receiveStream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(receiveStream);
            string text = reader.ReadToEnd();
            receiveStream.Seek(originalPosition, SeekOrigin.Begin);

            return GetSoapMetric(text);
        }

        /// <summary>
        /// when using autogenerated page from wsdl, there is no xml or soap envelope.
        /// </summary>
        internal SoapMetric GetSoapMetric(string messageText)
        {
            var metric = new SoapMetric("NonSoap");
            var flattenedText = string.Empty;

            if (messageText.StartsWith("<?xml"))
            {
                var document = XDocument.Parse(messageText);
                var namespaceManager = new XmlNamespaceManager(new NameTable());
                namespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                var query = (IEnumerable) document.XPathEvaluate("/soap:Envelope/soap:Body", namespaceManager);

                var sb = new StringBuilder();
                var hasSetMessageName = false;
                foreach (var x in query.Cast<XElement>())
                {
                    RemoveNamespace(x);
                    sb.Append(ToFlatString(x.FirstNode));

                    if (!hasSetMessageName)
                    {
                        metric.Name = ((XElement) (x.FirstNode)).Name.LocalName;
                        hasSetMessageName = true;
                    }
                }

                flattenedText = sb.ToString();

            }

            metric.Message = flattenedText;
            return metric;
        }

        private string ToFlatString(XNode element)
        {
            return element.ToString().Replace("\r\n", string.Empty);
        }

        /// <summary>
        /// http://stackoverflow.com/questions/987135/how-to-remove-all-namespaces-from-xml-with-c
        /// </summary>
        private void RemoveNamespace(XElement xml)
        {
            foreach (XElement xElement in xml.DescendantsAndSelf())
            {
                // Stripping the namespace by setting the name of the element to it's localname only
                xElement.Name = xElement.Name.LocalName;
                // replacing all attributes with attributes that are not namespaces and their names are set to only the localname
                xElement.ReplaceAttributes(
                    (from xattrib in xElement.Attributes().Where(xa => !xa.IsNamespaceDeclaration)
                        select new XAttribute(xattrib.Name.LocalName, xattrib.Value)));
            }
        }

        #endregion

        #region ISoapLogger Methods
        public  void BeginRequest()
        {
            var soapMetric = new SoapLogger().GetSoapMetric(HttpContext.Current.Request.InputStream);
            HttpContext.Current.Items.Add(ItemsCacheKeySoapMetric, soapMetric);
        }

        public SoapMetric EndRequest()
        {
            var metric = (SoapMetric) HttpContext.Current.Items[ItemsCacheKeySoapMetric];
            metric.Stop();
            return metric;
        }
        #endregion
    }
}