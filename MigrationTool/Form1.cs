using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace MigrationTool
{
    public partial class Form1 : Form
    {
        private OracleTest oraTest;
        private OracleTest oraTestDest;
        private bool sourceConnection;
        private bool destConnection;
        public Form1()
        {
            InitializeComponent();
            sourceConnection = false;
            destConnection = false;
            oraTest = new OracleTest();
            oraTestDest = new OracleTest();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonTestSource_Click(object sender, EventArgs e)
        {
            if (comboBoxDatabaseSource.Text.Equals("Oracle"))
            {

                if (oraTest.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text,
                    textBoxPasswordSource.Text))
                {
                    labelTestSource.Text = "Connected";
                    sourceConnection = true;
                    oraTest.getSysTables(textBoxUserSource.Text);
                }

            }
            else if (comboBoxDatabaseSource.Equals("Postgres"))
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxDatabaseSource.Text.Equals("Oracle") && comboBoxDatabaseDestination.Text.Equals("Oracle"))
            {
                oraTest.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text, textBoxPasswordSource.Text);
                
                labelTestSource.Text = "Connected";
                sourceConnection = true;
                oraTest.getSysTables(textBoxUserSource.Text);

                oraTestDest.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text, textBoxPasswordDest.Text);

                labelTestDest.Text = "Connected";
                sourceConnection = true;
                oraTest.getSysTables(textBoxUserSource.Text);

                var tables = oraTest.getSysTables(oraTest.owner);
                var columnInfoList = oraTest.getColumnInfoList(tables);
                var columnNames = oraTest.getColumnNamesList(oraTest.owner, tables);
                var columnValues = oraTest.getAllColumnValues(tables);

                

                oraTestDest.migrateData(oraTestDest.owner, tables, columnInfoList, columnNames, columnValues);
                
            }
        }
    }
}
