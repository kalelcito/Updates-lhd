using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class multiFileUpload : System.Web.UI.UserControl
    {
        public event MultipleFileUploadClick Click;

        /// <summary>
        /// The no of visible rows to display.
        /// </summary>
        private int _Rows = 6;
        public int Rows
        {
            get { return _Rows; }
            set { _Rows = value < 6 ? 6 : value; }
        }

        /// <summary>
        /// The no of maximukm files to upload.
        /// </summary>
        private int _UpperLimit = 0;
        public int UpperLimit
        {
            get { return _UpperLimit; }
            set { _UpperLimit = value; }
        }

        /// <summary>
        /// Methos for page load event.
        /// </summary>
        /// <param name="sender">Reference of the object that raises this event.</param>
        /// <param name="e">Contains information regarding page load click event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCaption.Text = _UpperLimit == 0 ? "Maximum Files: No Limit" : string.Format("Maximo de Archivos: {0}", _UpperLimit);
            pnlListBox.Attributes["style"] = "overflow:auto;";
            pnlListBox.Height = Unit.Pixel(20 * _Rows - 1);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "MyScript", GetJavaScript());
        }

        /// <summary>
        /// Methods for btnUpload Click event. 
        /// </summary>
        /// <param name="sender">Reference of the object that raises this event.</param>
        /// <param name="e">Contains information regarding button click event data.</param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Fire the event.
            Click(this, new FileCollectionEventArgs(this.Request));
        }

        /// <summary>
        /// This method is used to generate javascript code for MultipleFileUpload control that execute at client side.
        /// </summary>
        /// <returns>Javascript as a string object.</returns>
        private string GetJavaScript()
        {
            StringBuilder JavaScript = new StringBuilder();

            JavaScript.Append("<script type='text/javascript'>");
            JavaScript.Append("var Id = 0;\n");
            JavaScript.AppendFormat("var MAX = {0};\n", _UpperLimit);
            JavaScript.AppendFormat("var DivFiles = document.getElementById('{0}');\n", pnlFiles.ClientID);
            JavaScript.AppendFormat("var DivListBox = document.getElementById('{0}');\n", pnlListBox.ClientID);
            JavaScript.AppendFormat("var BtnAdd = document.getElementById('{0}');\n", btnAdd.ClientID);
            JavaScript.Append("function Add()");
            JavaScript.Append("{\n");
            JavaScript.Append("var IpFile = GetTopFile();\n");
            JavaScript.Append("if(IpFile == null || IpFile.value == null || IpFile.value.length == 0)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("alert('Selecciona un archivo para agregar.');\n");
            JavaScript.Append("return;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("var NewIpFile = CreateFile();\n");
            JavaScript.Append("DivFiles.insertBefore(NewIpFile,IpFile);\n");
            JavaScript.Append("if(MAX != 0 && GetTotalFiles() - 1 == MAX)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("NewIpFile.disabled = true;\n");
            JavaScript.Append("BtnAdd.disabled = true;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("IpFile.style.display = 'none';\n");
            JavaScript.Append("DivListBox.appendChild(CreateItem(IpFile));\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function CreateFile()");
            JavaScript.Append("{\n");
            JavaScript.Append("var IpFile = document.createElement('input');\n");
            JavaScript.Append("IpFile.id = IpFile.name = 'IpFile_' + Id++;\n");
            JavaScript.Append("IpFile.type = 'file';\n");
            JavaScript.Append("return IpFile;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function CreateItem(IpFile)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Item = document.createElement('div');\n");
            JavaScript.Append("Item.style.backgroundColor = '#ffffff';\n");
            JavaScript.Append("Item.style.fontWeight = 'normal';\n");
            JavaScript.Append("Item.style.textAlign = 'left';\n");
            JavaScript.Append("Item.style.verticalAlign = 'middle'; \n");
            JavaScript.Append("Item.style.cursor = 'default';\n");
            JavaScript.Append("Item.style.height = 20 + 'px';\n");
            JavaScript.Append("var Splits = IpFile.value.split('\\\\');\n");
            JavaScript.Append("Item.innerHTML = Splits[Splits.length - 1] + '&nbsp;';\n");
            JavaScript.Append("Item.value = IpFile.id;\n");
            JavaScript.Append("Item.title = IpFile.value;\n");
            JavaScript.Append("var A = document.createElement('a');\n");
            JavaScript.Append("A.innerHTML = 'Delete';\n");
            JavaScript.Append("A.id = 'A_' + Id++;\n");
            JavaScript.Append("A.href = '#';\n");
            JavaScript.Append("A.style.color = 'blue';\n");
            JavaScript.Append("A.onclick = function()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("DivFiles.removeChild(document.getElementById(this.parentNode.value));\n");
            JavaScript.Append("DivListBox.removeChild(this.parentNode);\n");
            JavaScript.Append("if(MAX != 0 && GetTotalFiles() - 1 < MAX)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("GetTopFile().disabled = false;\n");
            JavaScript.Append("BtnAdd.disabled = false;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("}\n");
            JavaScript.Append("Item.appendChild(A);\n");
            JavaScript.Append("Item.onmouseover = function()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("Item.bgColor = Item.style.backgroundColor;\n");
            JavaScript.Append("Item.fColor = Item.style.color;\n");
            JavaScript.Append("Item.style.backgroundColor = '#C6790B';\n");
            JavaScript.Append("Item.style.color = '#ffffff';\n");
            JavaScript.Append("Item.style.fontWeight = 'bold';\n");
            JavaScript.Append("}\n");
            JavaScript.Append("Item.onmouseout = function()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("Item.style.backgroundColor = Item.bgColor;\n");
            JavaScript.Append("Item.style.color = Item.fColor;\n");
            JavaScript.Append("Item.style.fontWeight = 'normal';\n");
            JavaScript.Append("}\n");
            JavaScript.Append("return Item;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function Clear()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("DivListBox.innerHTML = '';\n");
            JavaScript.Append("DivFiles.innerHTML = '';\n");
            JavaScript.Append("DivFiles.appendChild(CreateFile());\n");
            JavaScript.Append("BtnAdd.disabled = false;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function GetTopFile()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n");
            JavaScript.Append("var IpFile = null;\n");
            JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("IpFile = Inputs[n];\n");
            JavaScript.Append("break;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("return IpFile;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function GetTotalFiles()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Inputs = DivFiles.getElementsByTagName('input');\n");
            JavaScript.Append("var Counter = 0;\n");
            JavaScript.Append("for(var n = 0; n < Inputs.length && Inputs[n].type == 'file'; ++n)\n");
            JavaScript.Append("Counter++;\n");
            JavaScript.Append("return Counter;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function GetTotalItems()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("var Items = DivListBox.getElementsByTagName('div');\n");
            JavaScript.Append("return Items.length;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("function DisableTop()\n");
            JavaScript.Append("{\n");
            JavaScript.Append("if(GetTotalItems() == 0)\n");
            JavaScript.Append("{\n");
            JavaScript.Append("alert('Elige al menos un archivo para subir.');\n");
            JavaScript.Append("return false;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("GetTopFile().disabled = true;\n");
            JavaScript.Append("return true;\n");
            JavaScript.Append("}\n");
            JavaScript.Append("</script>");

            return JavaScript.ToString();
        }
    }

    /// <summary>
    /// EventArgs class that has some readonly properties regarding posted files corresponding to MultipleFileUpload control. 
    /// </summary>
    public class FileCollectionEventArgs : EventArgs
    {
        private HttpRequest _HttpRequest;

        public HttpFileCollection PostedFiles
        {
            get
            {
                return _HttpRequest.Files;
            }
        }

        public int Count
        {
            get { return _HttpRequest.Files.Count; }
        }

        public bool HasFiles
        {
            get { return _HttpRequest.Files.Count > 0 ? true : false; }
        }

        public double TotalSize
        {
            get
            {
                double Size = 0D;
                for (int n = 0; n < _HttpRequest.Files.Count; ++n)
                {
                    if (_HttpRequest.Files[n].ContentLength < 0)
                        continue;
                    else
                        Size += _HttpRequest.Files[n].ContentLength;
                }

                return Math.Round(Size / 1024D, 2);
            }
        }

        public FileCollectionEventArgs(HttpRequest oHttpRequest)
        {
            _HttpRequest = oHttpRequest;
        }
    }

    //Delegate that represents the Click event signature for MultipleFileUpload control.
    public delegate void MultipleFileUploadClick(object sender, FileCollectionEventArgs e);
