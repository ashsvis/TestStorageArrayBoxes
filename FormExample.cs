using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestStorageArrayBoxes
{
    public partial class FormExample : Form
    {
        public FormExample()
        {
            InitializeComponent();
            var n = 0;
            for (var row = 0; row < gridPanel.RowCount; row++) 
            { 
                for (var col = 0; col < gridPanel.ColumnCount; col++) 
                {
                    var box = new TextBox() { Name = $"R{row}C{col}", Text = $"{++n}", Anchor = AnchorStyles.None };
                    gridPanel.Controls.Add(box, col, row);
                }
            }
        }
    }
}
