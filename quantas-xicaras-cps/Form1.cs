using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace quantas_xicaras_cps
{
    public partial class formPrincipal : Form
    {
        private int statusCom = 0;
        private SerialPort serialPort = new SerialPort();
        private string serialData;
        
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            cbSerialComs.Items.Add("Selecione a porta COM");

            string[] comList = SerialPort.GetPortNames();
            for(int i=0; i<comList.Length; i++)
            {
                cbSerialComs.Items.Add(comList[i]);
            }

            cbSerialComs.SelectedIndex = 0;
            
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {

        }

        private void connect()
        {
            if (cbSerialComs.SelectedIndex != 0)
            {
                try
                {
                    this.serialPort.PortName = cbSerialComs.Text;
                    this.serialPort.BaudRate = 9600;
                    this.serialPort.Parity = Parity.None;
                    this.serialPort.DataBits = 8;
                    this.serialPort.StopBits = StopBits.One;

                    this.serialPort.Open();
                    lblStatusSerial.Text = "Conectado";
                    lblStatusSerial.ForeColor = Color.Green;
                    btnHandleConnection.Text = "Desconectar";
                    this.statusCom = 1;
                    timerSerial.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Selecione uma porta!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnect()
        {
            
            try
            {

                this.serialPort.Close();
                lblStatusSerial.Text = "Desconectado";
                lblStatusSerial.ForeColor = Color.Red;
                btnHandleConnection.Text = "Conectar";
                this.statusCom = 0;
                timerSerial.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnHandleConnection_Click(object sender, EventArgs e)
        {
            if(this.statusCom == 0)
            {
                this.connect();
            }
            else
            {
                this.disconnect();
            }
            
            
        }

        private void timerSerial_Tick(object sender, EventArgs e)
        {
            try
            {
                serialPort.Write("[TT]");
                Task.Delay(250);
                serialData = "";
                serialData = serialPort.ReadExisting();
                if(serialData != "")
                {
                    lblTemp.Text = "Temperatura: " + serialData + " °C";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCoolerOn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Write("[C1]");
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCoolerOff_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Write("[C0]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
