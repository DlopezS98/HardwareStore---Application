using HardwareStore.Core.Interfaces;
using HardwareStore.Core.Interfaces.Reports;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.ComponentModel;
using HardwareStore.Core.Interfaces.Catalogs;

namespace HardwareStore.Modules.Reports
{
    public partial class Index : PageBase
    {
        [Inject]
        public IReportsService ReportService { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    this.LoadDDListWarehouses();
            //    this.LoaddlProductModule();
            //}
        }
        //Reporte de Productos
        private void LoadProductReport(string Search)
        {
            DataTable dt = new DataTable();
            dt = this.ReportService.GetProductDetailsFromDatabase(false, Search);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource Rdlc = new ReportDataSource("DataSetProduct", dt);
            ReportViewer1.LocalReport.DataSources.Add(Rdlc);
            ReportViewer1.LocalReport.Refresh();
            MultiviewReports.ActiveViewIndex = 1;
        }

        protected void btnSearchProducts_Click(Object sender, EventArgs e)
        {
            string Search = btnSearchProducts.Text;
            this.LoadProductReport(Search);
        }
        protected void btnNewProductReport_Click(Object sender, EventArgs e)
        {
            this.LoadProductReport("");            
        }

        //protected void ddlistFilterByWarehousesModuleProduct_SelectedIndexChanged(Object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32(ddlistFilterByWarehousesModuleProduct.SelectedValue);
        //    this.LoadExistencies(id);
        //}

        //private void LoaddlProductModule()
        //{
        //    var list = this.ReportService.ListWarehousesForDropDowns();
        //    this.ddlistFilterByWarehousesModuleProduct.DataSource = list;
        //    this.ddlistFilterByWarehousesModuleProduct.DataTextField = "Name";
        //    this.ddlistFilterByWarehousesModuleProduct.DataValueField = "Id";
        //    this.ddlistFilterByWarehousesModuleProduct.DataBind();
        //    this.ddlistFilterByWarehousesModuleProduct.Items.Insert(0, new ListItem("----[Todas las bodegas]----", "0"));
        //}

        //Reporte Compras

        private void LoadPurchases(DateTime StartDate, DateTime EndDate)
        {
            DataTable dtp = new DataTable();
            dtp = this.ReportService.GetPurhaseInvoices(StartDate, EndDate, "");
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportDataSource Rdlc = new ReportDataSource("DataSetPurchase", dtp);
            ReportViewer2.LocalReport.DataSources.Add(Rdlc);
            ReportViewer2.LocalReport.Refresh();            
        }

        protected void btnFilterPurchase_Click(Object sender, EventArgs e)
        {
            DateTime Start = Convert.ToDateTime(PurchaseDateFrom.Text);
            DateTime End = Convert.ToDateTime(PurchaseDateTo.Text);
            if (End > Start)
            {
                this.LoadPurchases(Start, End);
                return;
            }
            else
            {
                string ShowModalDate = "ModalDate()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModalDate, true);

            }
        }
        protected void btnPurchaseReport_Click(Object sender, EventArgs e)
        {
            DateTime Start = DateTime.Parse("1998-10-01");
            DateTime End = DateTime.Now;
            this.LoadPurchases(Start, End);
            MultiviewReports.ActiveViewIndex = 2;
        }

        //Reporte  Ventas
        private void LoadSale(DateTime? StartDate, DateTime? EndDate, string search = "")
        {
            DateTime Start, End;
            DataTable dts = new DataTable();
            if (StartDate != null && EndDate != null)
            {
                dts = this.ReportService.ListSalesInvoices((DateTime)StartDate, (DateTime)EndDate, search);
            }
            else
            {
                Start = Convert.ToDateTime("1998-10-01");
                End = DateTime.Now.AddDays(1);
                dts = this.ReportService.ListSalesInvoices(Start, End, search);
            }

            ReportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource Rdlc = new ReportDataSource("DataSetSale", dts);
            ReportViewer3.LocalReport.DataSources.Add(Rdlc);
            ReportViewer3.LocalReport.Refresh();
        }

        protected void btnFilterSale_Click(Object sender, EventArgs e)
        {
            
        }

        protected void btnSaleReport_Click(Object sender, EventArgs e)
        {
            DateTime Start = DateTime.Parse("1998-10-01");
            DateTime End = DateTime.Now;
            this.LoadSale(Start, End);
            MultiviewReports.ActiveViewIndex = 3;
        }

        //Existencies
        private void LoadExistencies(int WarehouseId)
        {
            DataTable dte = new DataTable();
            dte = this.ReportService.GetProductStocksDetails("0", "", WarehouseId);
            ReportViewer4.LocalReport.DataSources.Clear(); 
            ReportDataSource Rdlc = new ReportDataSource("DataSetExistencies", dte);
            ReportViewer4.LocalReport.DataSources.Add(Rdlc);
            ReportViewer4.LocalReport.Refresh();
        }

        protected void btnNewReportExistencies_Click(Object sender, EventArgs e)
        {
            this.LoadExistencies(0);
            MultiviewReports.ActiveViewIndex = 4;
        }

        //protected void ddlistFilterByWarehouses_SelectedIndexChanged(Object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32(ddlistFilterByWarehouses.SelectedValue);
        //    this.LoadExistencies(id);
        //}

        //Llenando drop de Bodegas
        //public void LoadDDListWarehouses()
        //{
        //    var list = this.ReportService.ListWarehousesForDropDowns();
        //    this.ddlistFilterByWarehouses.DataSource = list;
        //    this.ddlistFilterByWarehouses.DataTextField = "Name";
        //    this.ddlistFilterByWarehouses.DataValueField = "Id";
        //    this.ddlistFilterByWarehouses.DataBind();
        //    this.ddlistFilterByWarehouses.Items.Insert(0, new ListItem("----[Todas las bodegas]----", "0"));
        //}


        //Productos Dañados
        private void LoadReportDamagedProducts(DateTime StartDate, DateTime EndDate)
        {
            DataTable dtdp = new DataTable();
            dtdp = this.ReportService.GetRemovedProducts(StartDate, EndDate, "");
            ReportViewer5.LocalReport.DataSources.Clear();
            ReportDataSource Rdlc = new ReportDataSource("DataSetDamagedProducts", dtdp);
            ReportViewer5.LocalReport.DataSources.Add(Rdlc);
            ReportViewer5.LocalReport.Refresh();
        }

        protected void btnDamagedProducts_Click(Object sender, EventArgs e)
        {
            DateTime Start = DateTime.Parse("1998-10-01");
            DateTime End = DateTime.Now;
            this.LoadReportDamagedProducts(Start, End);
            MultiviewReports.ActiveViewIndex = 5;
        }

        protected void btnFilterDamagedProducts_Click(Object sender, EventArgs e)
        {
            DateTime StartSale = Convert.ToDateTime(txtStartDatePD.Text);
            DateTime EndSale = Convert.ToDateTime(txtEndDatePD.Text);
            if (EndSale > StartSale)
            {
                this.LoadReportDamagedProducts(StartSale, EndSale);
                return;
            }
            else
            {
                string ShowModalDate = "ModalDate()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModalDate, true);
            }
        }

        protected void btnNewReportSale_Click(object sender, EventArgs e)
        {
            string startdatestring = StartDateSale.Text;
            string enddatestring = EndDateSale.Text;
            if(startdatestring != "" && enddatestring != "")
            {
                DateTime StartSale = Convert.ToDateTime(startdatestring);
                DateTime EndSale = Convert.ToDateTime(enddatestring);
                if (EndSale > StartSale)
                {
                    this.LoadSale(StartSale, EndSale, txtSearchSale.Text);
                    return;
                }
                else
                {
                    string ShowModalDate = "ModalDate()";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", ShowModalDate, true);
                }
            }

            this.LoadSale(null, null, txtSearchSale.Text);
        }
    }
}