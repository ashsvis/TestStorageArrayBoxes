using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        /// <summary>
        /// При инициализации
        /// </summary>
        public FormExample()
        {
            InitializeComponent();
            // формируем матрицу текстбоксов
            // gridPanel.RowCount = 10;
            // gridPanel.ColumnCount = 8;
            var n = 0;
            for (var row = 0; row < gridPanel.RowCount; row++) 
            { 
                for (var col = 0; col < gridPanel.ColumnCount; col++) 
                {
                    var box = new TextBox() { Name = $"R{row}C{col}", Text = $"{++n}", Anchor = AnchorStyles.None };
                    // добавляем бокс в сетку
                    gridPanel.Controls.Add(box, col, row);
                }
            }
        }

        /// <summary>
        /// При первой загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormExample_Load(object sender, EventArgs e)
        {
            // загружаем ране записанные параметры
            Properties.Settings.Default.Reload();
            StringCollection collection = Properties.Settings.Default.Matrix;
            if (collection != null)
            {
                // для каждого бокса загружаем его сохранённое значение из коллекции по-порядку
                var n = 0;
                for (var row = 0; row < gridPanel.RowCount; row++)
                {
                    for (var col = 0; col < gridPanel.ColumnCount; col++)
                    {
                        // получаем бокс по индексам столбца и строки матрицы
                        var box = (TextBox)gridPanel.GetControlFromPosition(col, row);
                        // проверяем также что для этого бокса имеется элемент коллекции
                        if (box != null && n < collection.Count)
                            box.Text = collection[n++];
                        else
                            box.Text = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Перед закрытием формы в конце работы приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormExample_FormClosing(object sender, FormClosingEventArgs e)
        {
            // в конце работы записываем значения из боксов в коллекцию
            var collection = new StringCollection();
            for (var row = 0; row < gridPanel.RowCount; row++)
            {
                for (var col = 0; col < gridPanel.ColumnCount; col++)
                {
                    // получаем бокс по индексам столбца и строки матрицы
                    var box = (TextBox)gridPanel.GetControlFromPosition(col, row);
                    if (box != null)
                        collection.Add(box.Text);
                }
            }
            // и выгружаем на диск
            Properties.Settings.Default.Matrix = collection;
            Properties.Settings.Default.Save();
        }
    }
}
