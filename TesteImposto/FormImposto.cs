using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imposto.Core.Domain;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private Pedido pedido = new Pedido();

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;                       
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }   
        }

        private object GetTablePedidos()
        {
            DataTable table = null;

            try
            {
                table = new DataTable("pedidos");
                table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
                table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
                table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
                table.Columns.Add(new DataColumn("Brinde", typeof(bool)));
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;

        }

        private void LimpaTela()
        {
            try
            {
                txtBoxNomeCliente.Text = string.Empty;
                txtEstadoDestino.Text = string.Empty;
                txtEstadoOrigem.Text = string.Empty;
                
                dataGridViewPedidos.AutoGenerateColumns = true;
                dataGridViewPedidos.DataSource = GetTablePedidos();
                ResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {        
            try
            {
                pedido = new Pedido();

                NotaFiscalService NotaFiscalService = new NotaFiscalService();
                pedido.EstadoOrigem = txtEstadoOrigem.Text;
                pedido.EstadoDestino = txtEstadoDestino.Text;
                pedido.NomeCliente = txtBoxNomeCliente.Text;

                DataTable table = (DataTable)dataGridViewPedidos.DataSource;

                foreach (DataRow row in table.Rows)
                {
                    
                    pedido.ItensDoPedido.Add(
                        new PedidoItem()
                        {

                            Brinde = Convert.ToBoolean((row["Brinde"].ToString() == string.Empty ? false : true)),
                            CodigoProduto =  row["Codigo do produto"].ToString(),
                            NomeProduto = row["Nome do produto"].ToString(),
                            ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())            
                        });
                }

                NotaFiscalService.Gravar(pedido);

                MessageBox.Show("Operação efetuada com sucesso");

                LimpaTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            

        }
    }
}
