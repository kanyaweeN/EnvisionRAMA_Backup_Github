using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

using Net.Sgoliver.NRtfTree.Core;
using Net.Sgoliver.NRtfTree.Util;

internal class StateRtf {
public bool bold;
public bool italic;
public bool underline;

public string fontName;
public int fontSize;
public Color fontColor;

public StateRtf(string FontName,int FontSize,Color FontColor,bool Bold,bool Italic, bool Underline) {
    fontName = FontName;
    fontSize = FontSize;
    fontColor = FontColor;

    bold = Bold;
    italic = Italic;
    underline = Underline;
}

}
public class TransRtf {

#region Field.
private RtfTree tree;			

private string[] data;		
private Color[] dataColor;		

private ArrayList listData;
private StateRtf  rtfData;	
#endregion            

#region Constructor.
public TransRtf(string RtfDataFormat) {
    listData = new ArrayList();
    tree = new RtfTree();
    tree.LoadRtfText(RtfDataFormat);
}
#endregion

#region Method.
public string Translator() {
    string result = string.Empty;
    data = tree.GetFontTable();
    dataColor = tree.GetColorTable();
    result = TranslatorText();
    return result;
}
public string TranslatorText() {
    //string result = "<html><head></head><body>"; 
    string result = string.Empty;
    Color c = Color.Empty;
    if (dataColor.Length > 0)
        c = (Color)dataColor[0];
    if(data.Length==0)
        rtfData = new StateRtf(tree.Text, 10, c, false, false, false);
    else
        rtfData = new StateRtf((string)data[0], 10, c, false, false, false);

    startFormat();

    bool flag = false;		
    int i = 0;
    RtfTreeNode nodo = new RtfTreeNode();
    while (!flag && i < tree.RootNode.FirstChild.ChildNodes.Count)
    {
        nodo = tree.RootNode.FirstChild.ChildNodes[i];
        if (nodo.NodeKey == "pard")
        {
            flag = true;
        }

        i++;
    }
    int primerNodoTexto = i - 1;
    result += TranslatorText(tree.RootNode.FirstChild, primerNodoTexto);
    result += endFormat();
    //result += "</body></html>";
    return result;
}
public string TranslatorText(RtfTreeNode curNode, int prim)
{
    string result = string.Empty;
    RtfTreeNode nprin = curNode;
    RtfTreeNode nodo = new RtfTreeNode();
    bool flag = false;
    for (int i = prim; i < nprin.ChildNodes.Count; i++)
    {
        if (flag)
            break;
        nodo = nprin.ChildNodes[i];
        Color c = Color.Empty;
        if (dataColor.Length > 0)
            c = (Color)dataColor[0];
        if (nodo.NodeType == RtfNodeType.Group)
        {
            listData.Add(rtfData);
            rtfData = new StateRtf((string)data[0], 10, c, false, false, false);
            result += TranslatorText(nodo, 0);
            rtfData = (StateRtf)listData[listData.Count - 1];
            listData.RemoveAt(listData.Count - 1);
        }
        else if (nodo.NodeType == RtfNodeType.Control)
        {
            if (nodo.NodeKey == "'")
            {
                result += startFormat();
                if (nodo.Parameter >= 161)
                {
                    result += Convert.ToChar(nodo.Parameter + 3424);
                }
                else
                {
                    result += Convert.ToChar(nodo.Parameter);
                }
                result += endFormat();
            }
        }
        else if (nodo.NodeType == RtfNodeType.Keyword)
        {
            
            switch (nodo.NodeKey)
            {
                case "f":  
                    rtfData.fontName = (string)data[nodo.Parameter];
                    break;
                case "cf":
                    rtfData.fontColor = (Color)dataColor[nodo.Parameter];
                    break;
                case "fs":
                    rtfData.fontSize= nodo.Parameter;
                    break;
                case "b":	
                    if (!nodo.HasParameter || nodo.Parameter == 1)
                        rtfData.bold = true;
                    else
                        rtfData.bold = false;
                    break;
                case "i":	
                    if (!nodo.HasParameter || nodo.Parameter == 1)
                        rtfData.italic = true;
                    else
                        rtfData.italic = false;
                    break;
                case "ul":
                    rtfData.underline = true;
                    break;
                case "ulnone":
                    rtfData.underline = false;
                    break;
                case "par":
                    result += "<br>";
                    break;
                case "tab":
                    result += "&nbsp;&nbsp;&nbsp;";
                    break;
                case "pict" :
                    result += "<img	src=\"none\" />";
                    flag = true;
                    break;
            }
           
        }
        else if (nodo.NodeType == RtfNodeType.Text)
        {
            result += startFormat();
            result += nodo.NodeKey;
            result += endFormat();
        }
    }

    return result;
}

public string startFormat()
{
    string result = string.Empty;
    result += "<font face='" + rtfData.fontName + "' size='" + rtfData.fontSize / 8 + "' color='" + toHTMLColor(rtfData.fontColor) + "'>";
    if (rtfData.bold)
        result += "<b>";
    if (rtfData.italic)
        result += "<i>";
    if (rtfData.underline)
        result += "<u>";
    return result;
}
public string endFormat() {
    string result = "";
    if (rtfData.bold)
    {
        result += "</b>";
    }
    if (rtfData.italic)
    {
        result += "</i>";
    }
    if (rtfData.underline)
    {
        result += "</u>";
    }
    result += "</font>";    
    return result;
}

public string toHTMLColor(Color actColor)
{
    return "black";
    //return "#" + intToHex(actColor.R, 2) + intToHex(actColor.G, 2) + intToHex(actColor.B, 2);
}
public String intToHex(int hexint, int length)
{
    string hexstr = Convert.ToString(hexint, 16);
    int filler = length - hexstr.Length;
    for (int i = 0; i < filler; i++)
        hexstr = "0" + hexstr;
    return hexstr;
}
#endregion

}

