using System;
using System.Collections.Generic;
using System.Xml;

namespace DeserializandoXmlTotal
{
    public class Xml
    {
        public static NF LerXml(string caminhoArquivo)
        {
            var erro = "";
            try
            {
                //Verificar se o arquivo é do tipo xml

                if (caminhoArquivo != ".xml")
                {
                    erro = "Anexe um arquivo do tipo jpg ou jpeg";
                }

                // Verificar se o arquivo existe

                var nf = new NF();
            using (XmlReader xml = XmlReader.Create(caminhoArquivo))
            {                
                var item = new ItensNF();
                var itens = new List<ItensNF>();
                while (xml.Read())
                {
                    //Cabeçalho
                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "natOp")
                        nf.natOp = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "nNF")
                        nf.nNF = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "dhEmi")
                        nf.dhEmi = xml.ReadElementContentAsString();

                    //Itens
                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "cProd")
                        item.Cprod = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "cEAN")
                        item.CEAN = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "xProd")
                        item.Xprod = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "NCM")
                        item.NCM = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "CEST")
                        item.CEST = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "CFOP")
                        item.CFOP = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "qCom")
                        item.Qcom = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "vUnCom")
                        item.VumCom = xml.ReadElementContentAsString();

                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "vProd")
                        item.Vprod = xml.ReadElementContentAsString();
                    

                    //Adicionar na lista quando todas as propriedades do objeto estiverem
                    //preenchidas
                    if (!String.IsNullOrEmpty(item.Cprod) && !String.IsNullOrEmpty(item.Xprod)
                    && !String.IsNullOrEmpty(item.Qcom) && !String.IsNullOrEmpty(item.VumCom)
                    && !String.IsNullOrEmpty(item.Vprod))
                    {
                        itens.Add(item);
                        item = new ItensNF();
                    }

                    // Rodapé
                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "vNF")
                        nf.vNF = xml.ReadElementContentAsString().Replace(".", ",");

                }
                //Adicionar itens ao objeto Nota
                nf.Itens = itens;

            }

            return nf;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public string ValidarXml(string caminhoArquivo)
        {
            if (caminhoArquivo != ".xml") 
            {
                return "Anexe um arquivo do tipo jpg ou jpeg";                
            }

            return null;
        }

    }
}
