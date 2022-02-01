using System.Text;

namespace EntityFrameworkQuerires
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectAllVendors_Click(object sender, EventArgs e)
        {
            using APContext dbContext = new();

            // LINQ(Language Integrated Query) method syntax
            List<Vendor> vendorList = dbContext.Vendors.ToList();

            // LINQ query syntax
            List<Vendor> vendorList2 = (from v in dbContext.Vendors
                                       select v).ToList();
        }

        private void btnAllCaliVendors_Click(object sender, EventArgs e)
        {
            using APContext dbContext = new();
            
            List<Vendor> vendorList = dbContext.Vendors
                                       .Where(v => v.VendorState == "CA")
                                       .OrderBy(v => v.VendorName)
                                       .ToList();

            List<Vendor> vendorList2 = (from v in dbContext.Vendors
                                        where v.VendorState == "CA"
                                        orderby v.VendorName
                                        select v).ToList();
        }

        private void btnSelectSpecificColumns_Click(object sender, EventArgs e)
        {
            using APContext dbContext = new();
            // Anonymous type
            List<VendorLocation> results = (from v in dbContext.Vendors
                           select new VendorLocation
                           {
                               VendorName = v.VendorName,
                               VendorState = v.VendorState,
                               VendorCity = v.VendorCity
                           }).ToList();

            StringBuilder displayString = new();
            foreach (var vendor in results)
            {
                displayString.AppendLine($"{vendor.VendorName} is in {vendor.VendorCity}");
            }

            MessageBox.Show(displayString.ToString());
        }

        private void btnMiscQueries_Click(object sender, EventArgs e)
        {
            APContext dbContext = new();

            // Check if something exists
            bool doesExist = (from v in dbContext.Vendors
                             where v. VendorState == "CA"
                             select v).Any();

            // get number of Invoices
            int invoiceCount = (from invoice in dbContext.Vendors
                                select invoice).Count();

            //Query a single Vendor
            Vendor ibm = (from v in dbContext.Vendors
                         where v.VendorName == "IBM"
                         select v).Single();

            if (ibm != null)
            {
                // Do something with the Vendor Object
            }
        }
    }

    class VendorLocation
    {
        public string VendorName { get; set; }

        public string VendorState { get; set; }

        public string VendorCity { get; set; }
    }
}