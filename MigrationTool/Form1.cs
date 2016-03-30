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
        private PostgresConnection pgCon;
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
                try
                {
                    if (oraTest.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text,
              textBoxPasswordSource.Text))
                    {
                        labelTestSource.Text = "Connected";
                        sourceConnection = true;
                        oraTest.getSysTables();
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Connection Error");
                }
          
            }
            else if (comboBoxDatabaseSource.Text.Equals("Postgres"))
            {
                try
                {
                    pgCon = new PostgresConnection();
                    pgCon.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text,
                        textBoxPasswordSource.Text, textBoxDBNameSrc.Text);
                    labelTestSource.Text = "Connected";
                    sourceConnection = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection Error");
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxDatabaseSource.Text.Equals("Oracle") && comboBoxDatabaseDestination.Text.Equals("Oracle"))
            {
                oraTest.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text, textBoxPasswordSource.Text);
                
                labelTestSource.Text = "Connected";
                sourceConnection = true;
                oraTest.getSysTables();

                oraTestDest.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text, textBoxPasswordDest.Text);

                labelTestDest.Text = "Connected";
                sourceConnection = true;
                oraTest.getSysTables();

                var tables = oraTest.getSysTables();
                var columnInfoList = oraTest.getColumnInfoList(tables);
                var columnNames = oraTest.getColumnNamesList(oraTest.owner, tables);
                var columnValues = oraTest.getAllColumnValues(tables);

                

                oraTestDest.migrateData(oraTestDest.owner, tables, columnInfoList, columnNames, columnValues);
                labelSuccessMigration.Text = "Successful Migration";
                MessageBox.Show("Success");

            }
            else if (comboBoxDatabaseSource.Text.Equals("Postgres") && comboBoxDatabaseDestination.Text.Equals("Oracle"))
            {
                pgCon = new PostgresConnection();
                pgCon.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text,
                    textBoxPasswordSource.Text, textBoxDBNameSrc.Text);
                pgCon.fillTables();
                pgCon.getDataTables();

                OracleTest oracle = new OracleTest();
                oracle.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text,
                   textBoxPasswordDest.Text);
                oracle.executeQueries(pgCon.GetCreateTableOracleQueries());
                oracle.executeQueries(pgCon.GetInsertOracleDataQueries());

                labelSuccessMigration.Text = "Successful Migration";
                MessageBox.Show("Success");
               
            }
            else if (comboBoxDatabaseSource.Text.Equals("Postgres") && comboBoxDatabaseDestination.Text.Equals("Postgres"))
            {
                pgCon = new PostgresConnection();
                pgCon.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text,
                    textBoxPasswordSource.Text, textBoxDBNameSrc.Text);
                pgCon.fillTables();
                pgCon.getDataTables();

                PostgresConnection pgDest = new PostgresConnection();
                pgDest.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text,
                   textBoxPasswordDest.Text, textBoxDBNameDest.Text);
                pgDest.ExecuteQuery(pgCon.GetCreateTableQueries());
                pgDest.ExecuteQuery(pgCon.GetInsertDataQueries());
                labelSuccessMigration.Text = "Successful Migration";
                MessageBox.Show("Success");

            }
            else if (comboBoxDatabaseSource.Text.Equals("Oracle") && comboBoxDatabaseDestination.Text.Equals("Postgres"))
            {
                oraTest.Connect(textBoxServerSouce.Text, textBoxPortSource.Text, textBoxUserSource.Text, textBoxPasswordSource.Text);

               
                oraTest.fillTables();
                oraTest.getDataTables();

                PostgresConnection pgDest = new PostgresConnection();
                pgDest.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text,
                   textBoxPasswordDest.Text, textBoxDBNameDest.Text);
                pgDest.ExecuteQuery(oraTest.GetCreateTableQueries());
                pgDest.ExecuteQueries(oraTest.GetInsertDataQueries());
                labelSuccessMigration.Text = "Successful Migration";
                MessageBox.Show("Success");

            }
        }

        private void textBoxDBNameSrc_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxDatabaseSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDatabaseSource.Text.Equals("Postgres"))
            {
                labelDBNameSrc.Visible = true;
                textBoxDBNameSrc.Visible = true;
                buttonTestSource.Location = new Point(buttonTestSource.Location.X, 320);

                labelTestSource.Location = new Point(labelTestSource.Location.X, 325);
                textBoxPortSource.Text = "5432";
                textBoxServerSouce.Text = "localhost";
                textBoxDBNameSrc.Text = "banco";
                textBoxPasswordSource.Text = "p@ssw0rd";
                textBoxUserSource.Text = "postgres";
            }
            else if (comboBoxDatabaseSource.Text.Equals("Oracle"))
            {
                labelDBNameSrc.Visible = false;
                textBoxDBNameSrc.Visible = false;

                textBoxPortSource.Text = "1521";
                textBoxServerSouce.Text = "localhost";
            }
        }

        private void comboBoxDatabaseDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDatabaseDestination.Text.Equals("Postgres"))
            {
                labelDBNameDest.Visible = true;
                textBoxDBNameDest.Visible = true;
                buttonTestDest.Location = new Point(buttonTestDest.Location.X, 320);

                labelTestDest.Location = new Point(labelTestDest.Location.X, 325);
                textBoxPortDest.Text = "5432";
                textBoxServerDest.Text = "localhost";

                textBoxDBNameDest.Text = "banco";
                textBoxPasswordDest.Text = "p@ssw0rd";
                textBoxUserDest.Text = "postgres";
            }
            else if (comboBoxDatabaseDestination.Text.Equals("Oracle"))
            {
                labelDBNameDest.Visible = false;
                textBoxDBNameDest.Visible = false;
                textBoxPortDest.Text = "1521";
                textBoxServerDest.Text = "localhost";
            }
        }

        private void buttonTestDest_Click(object sender, EventArgs e)
        {
            if (comboBoxDatabaseDestination.Text.Equals("Oracle"))
            {
                try
                {
                  if (oraTest.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text,
                  textBoxPasswordDest.Text))
                    {
                        labelTestDest.Text = "Connected";
                        destConnection = true;
                        oraTest.getSysTables();
                    }
                }
                catch (Exception)
                {


                    MessageBox.Show("Connection Error");
                }
              

            }
            else if (comboBoxDatabaseDestination.Text.Equals("Postgres"))
            {
                PostgresConnection con = new PostgresConnection();
                try
                {
                    con.Connect(textBoxServerDest.Text, textBoxPortDest.Text, textBoxUserDest.Text,
                        textBoxPasswordDest.Text, textBoxDBNameDest.Text);
                    labelTestDest.Text = "Connected";
                }
                catch (Exception exep)
                {
                    MessageBox.Show("Connection Error");
                }
              
            }
        }
    }
}
