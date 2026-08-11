using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KasirMakananTugas
{
    public partial class Form1 : Form
    {
        private const decimal TaxRate = 0.10m;

        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("id-ID");
        private readonly List<MenuProduct> _menu = new List<MenuProduct>();
        private readonly List<CartLine> _cart = new List<CartLine>();

        private readonly Color _ink = Color.FromArgb(18, 32, 35);
        private readonly Color _muted = Color.FromArgb(101, 113, 112);
        private readonly Color _surface = Color.FromArgb(241, 245, 242);
        private readonly Color _panel = Color.FromArgb(255, 255, 251);
        private readonly Color _line = Color.FromArgb(218, 226, 220);
        private readonly Color _accent = Color.FromArgb(13, 122, 109);
        private readonly Color _accentSoft = Color.FromArgb(223, 244, 239);
        private readonly Color _success = Color.FromArgb(18, 138, 92);
        private readonly Color _danger = Color.FromArgb(198, 55, 66);

        private FlowLayoutPanel _menuPanel;
        private DataGridView _cartGrid;
        private Label _subtotalValue;
        private Label _discountValue;
        private Label _taxValue;
        private Label _grandTotalValue;
        private Label _changeValue;
        private TextBox _discountInput;
        private TextBox _cashInput;
        private TextBox _receiptBox;

        private sealed class MenuProduct
        {
            public MenuProduct(string name, string category, decimal price)
            {
                Name = name;
                Category = category;
                Price = price;
            }

            public string Name { get; private set; }
            public string Category { get; private set; }
            public decimal Price { get; private set; }
        }

        private sealed class CartLine
        {
            public CartLine(MenuProduct product)
            {
                Product = product;
                Quantity = 1;
            }

            public MenuProduct Product { get; private set; }
            public int Quantity { get; set; }
            public decimal LineTotal { get { return Product.Price * Quantity; } }
        }

        public Form1()
        {
            InitializeComponent();
            InitializeMenuData();
            BuildInterface();
            RefreshCartGrid();
            RefreshTotals();
        }

        private void InitializeMenuData()
        {
            _menu.Add(new MenuProduct("Nasi Goreng Spesial", "Makanan", 18000m));
            _menu.Add(new MenuProduct("Mie Ayam Bakso", "Makanan", 16000m));
            _menu.Add(new MenuProduct("Ayam Geprek", "Makanan", 17000m));
            _menu.Add(new MenuProduct("Bakso Kuah", "Makanan", 15000m));
            _menu.Add(new MenuProduct("Soto Ayam", "Makanan", 14000m));
            _menu.Add(new MenuProduct("Es Teh Manis", "Minuman", 5000m));
            _menu.Add(new MenuProduct("Es Jeruk", "Minuman", 7000m));
            _menu.Add(new MenuProduct("Kopi Susu", "Minuman", 9000m));
            _menu.Add(new MenuProduct("Air Mineral", "Minuman", 4000m));
            _menu.Add(new MenuProduct("Pisang Goreng", "Snack", 8000m));
        }

        private void BuildInterface()
        {
            Controls.Clear();
            BackColor = _surface;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            var root = new TableLayoutPanel();
            root.Dock = DockStyle.Fill;
            root.BackColor = _surface;
            root.ColumnCount = 1;
            root.RowCount = 2;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            Controls.Add(root);

            root.Controls.Add(BuildHeader(), 0, 0);
            root.Controls.Add(BuildBody(), 0, 1);
        }

        private Control BuildHeader()
        {
            var header = new Panel();
            header.Dock = DockStyle.Fill;
            header.BackColor = _ink;
            header.Padding = new Padding(28, 18, 28, 16);

            var title = new Label();
            title.AutoSize = true;
            title.Text = "Kasir Makanan";
            title.ForeColor = Color.White;
            title.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            title.Location = new Point(28, 18);

            var subtitle = new Label();
            subtitle.AutoSize = true;
            subtitle.Text = "Dashboard transaksi kantin yang cepat, rapi, dan mudah dipakai";
            subtitle.ForeColor = Color.FromArgb(203, 218, 213);
            subtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            subtitle.Location = new Point(31, 67);

            var dateLabel = new Label();
            dateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dateLabel.AutoSize = false;
            dateLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", _culture);
            dateLabel.TextAlign = ContentAlignment.MiddleRight;
            dateLabel.ForeColor = Color.FromArgb(223, 236, 232);
            dateLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dateLabel.Size = new Size(280, 24);
            dateLabel.Location = new Point(ClientSize.Width - 310, 25);

            var roleLabel = new Label();
            roleLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roleLabel.AutoSize = false;
            roleLabel.Text = "Meja kasir 01";
            roleLabel.TextAlign = ContentAlignment.MiddleRight;
            roleLabel.ForeColor = Color.FromArgb(159, 185, 178);
            roleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            roleLabel.Size = new Size(180, 24);
            roleLabel.Location = new Point(ClientSize.Width - 210, 55);

            header.Resize += delegate
            {
                dateLabel.Location = new Point(header.Width - dateLabel.Width - 28, 25);
                roleLabel.Location = new Point(header.Width - roleLabel.Width - 28, 55);
            };

            header.Controls.Add(title);
            header.Controls.Add(subtitle);
            header.Controls.Add(dateLabel);
            header.Controls.Add(roleLabel);
            return header;
        }

        private Control BuildBody()
        {
            var body = new TableLayoutPanel();
            body.Dock = DockStyle.Fill;
            body.BackColor = _surface;
            body.Padding = new Padding(22);
            body.ColumnCount = 3;
            body.RowCount = 1;
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));

            body.Controls.Add(BuildMenuSection(), 0, 0);
            body.Controls.Add(BuildCartSection(), 1, 0);
            body.Controls.Add(BuildPaymentSection(), 2, 0);

            return body;
        }

        private Control BuildMenuSection()
        {
            var panel = CreateSectionPanel("Daftar Menu", "Klik menu untuk menambahkan ke keranjang");

            _menuPanel = new FlowLayoutPanel();
            _menuPanel.Dock = DockStyle.Fill;
            _menuPanel.AutoScroll = true;
            _menuPanel.BackColor = _panel;
            _menuPanel.Padding = new Padding(2, 10, 2, 2);
            _menuPanel.WrapContents = true;

            foreach (MenuProduct product in _menu)
            {
                _menuPanel.Controls.Add(CreateMenuCard(product));
            }

            panel.Controls.Add(_menuPanel);
            panel.Controls.SetChildIndex(_menuPanel, 0);
            return panel;
        }

        private Control BuildCartSection()
        {
            var panel = CreateSectionPanel("Keranjang", "Atur jumlah item sebelum pembayaran");

            _cartGrid = new DataGridView();
            _cartGrid.Dock = DockStyle.Fill;
            _cartGrid.BackgroundColor = _panel;
            _cartGrid.BorderStyle = BorderStyle.None;
            _cartGrid.GridColor = _line;
            _cartGrid.AllowUserToAddRows = false;
            _cartGrid.AllowUserToDeleteRows = false;
            _cartGrid.AllowUserToResizeRows = false;
            _cartGrid.ReadOnly = true;
            _cartGrid.MultiSelect = false;
            _cartGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _cartGrid.RowHeadersVisible = false;
            _cartGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _cartGrid.EnableHeadersVisualStyles = false;
            _cartGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            _cartGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            _cartGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 239, 234);
            _cartGrid.ColumnHeadersDefaultCellStyle.ForeColor = _ink;
            _cartGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            _cartGrid.ColumnHeadersHeight = 38;
            _cartGrid.DefaultCellStyle.BackColor = _panel;
            _cartGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 251, 248);
            _cartGrid.DefaultCellStyle.SelectionBackColor = _accentSoft;
            _cartGrid.DefaultCellStyle.SelectionForeColor = _ink;
            _cartGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9.2F, FontStyle.Regular);
            _cartGrid.RowTemplate.Height = 38;
            _cartGrid.Columns.Add("Name", "Item");
            _cartGrid.Columns.Add("Price", "Harga");
            _cartGrid.Columns.Add("Quantity", "Qty");
            _cartGrid.Columns.Add("Total", "Total");
            _cartGrid.Columns["Quantity"].FillWeight = 40;

            var actions = new FlowLayoutPanel();
            actions.Dock = DockStyle.Bottom;
            actions.Height = 60;
            actions.FlowDirection = FlowDirection.LeftToRight;
            actions.Padding = new Padding(0, 14, 0, 0);
            actions.BackColor = _panel;

            var increaseButton = CreateActionButton("+", _accent, 52);
            increaseButton.Click += delegate { ChangeSelectedQuantity(1); };

            var decreaseButton = CreateActionButton("-", Color.FromArgb(100, 116, 139), 52);
            decreaseButton.Click += delegate { ChangeSelectedQuantity(-1); };

            var removeButton = CreateActionButton("Hapus", _danger, 84);
            removeButton.Click += delegate { RemoveSelectedLine(); };

            actions.Controls.Add(increaseButton);
            actions.Controls.Add(decreaseButton);
            actions.Controls.Add(removeButton);

            panel.Controls.Add(_cartGrid);
            panel.Controls.Add(actions);
            panel.Controls.SetChildIndex(_cartGrid, 0);
            return panel;
        }

        private Control BuildPaymentSection()
        {
            var panel = CreateSectionPanel("Pembayaran", "Hitung total, bayar, dan struk");

            var content = new TableLayoutPanel();
            content.Dock = DockStyle.Fill;
            content.BackColor = _panel;
            content.RowCount = 4;
            content.ColumnCount = 1;
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 188F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            content.Controls.Add(BuildSummaryBox(), 0, 0);
            content.Controls.Add(BuildPaymentInputs(), 0, 1);
            content.Controls.Add(BuildPaymentButtons(), 0, 2);
            content.Controls.Add(BuildReceiptBox(), 0, 3);

            panel.Controls.Add(content);
            panel.Controls.SetChildIndex(content, 0);
            return panel;
        }

        private Control BuildSummaryBox()
        {
            var summary = new TableLayoutPanel();
            summary.Dock = DockStyle.Fill;
            summary.BackColor = _panel;
            summary.ColumnCount = 2;
            summary.RowCount = 5;
            summary.Padding = new Padding(0, 2, 0, 10);
            summary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            summary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));

            for (int i = 0; i < 5; i++)
            {
                summary.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            }

            _subtotalValue = AddSummaryRow(summary, 0, "Subtotal");
            _discountValue = AddSummaryRow(summary, 1, "Diskon");
            _taxValue = AddSummaryRow(summary, 2, "Pajak 10%");
            _grandTotalValue = AddSummaryRow(summary, 3, "Total");
            _changeValue = AddSummaryRow(summary, 4, "Kembali");
            _grandTotalValue.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            _grandTotalValue.ForeColor = _accent;
            _changeValue.ForeColor = _success;

            return summary;
        }

        private Control BuildPaymentInputs()
        {
            var inputs = new TableLayoutPanel();
            inputs.Dock = DockStyle.Fill;
            inputs.BackColor = _panel;
            inputs.ColumnCount = 2;
            inputs.RowCount = 2;
            inputs.Padding = new Padding(0, 8, 0, 6);
            inputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            inputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            inputs.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            inputs.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            _discountInput = CreateInput("0");
            _discountInput.TextChanged += delegate { RefreshTotals(); };
            _cashInput = CreateInput("");
            _cashInput.TextChanged += delegate { RefreshTotals(); };

            inputs.Controls.Add(CreateFieldLabel("Diskon (%)"), 0, 0);
            inputs.Controls.Add(_discountInput, 1, 0);
            inputs.Controls.Add(CreateFieldLabel("Uang Bayar"), 0, 1);
            inputs.Controls.Add(_cashInput, 1, 1);

            return inputs;
        }

        private Control BuildPaymentButtons()
        {
            var buttons = new TableLayoutPanel();
            buttons.Dock = DockStyle.Fill;
            buttons.BackColor = _panel;
            buttons.ColumnCount = 2;
            buttons.RowCount = 1;
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));

            var payButton = CreateActionButton("Proses Bayar", _success, 160);
            payButton.Dock = DockStyle.Fill;
            payButton.Click += delegate { ProcessPayment(); };

            var resetButton = CreateActionButton("Reset", Color.FromArgb(100, 116, 139), 100);
            resetButton.Dock = DockStyle.Fill;
            resetButton.Click += delegate { ResetTransaction(); };

            buttons.Controls.Add(payButton, 0, 0);
            buttons.Controls.Add(resetButton, 1, 0);
            return buttons;
        }

        private Control BuildReceiptBox()
        {
            _receiptBox = new TextBox();
            _receiptBox.Dock = DockStyle.Fill;
            _receiptBox.Multiline = true;
            _receiptBox.ReadOnly = true;
            _receiptBox.ScrollBars = ScrollBars.Vertical;
            _receiptBox.BackColor = Color.FromArgb(248, 250, 252);
            _receiptBox.BorderStyle = BorderStyle.FixedSingle;
            _receiptBox.Font = new Font("Consolas", 9.2F, FontStyle.Regular);
            _receiptBox.ForeColor = _ink;
            _receiptBox.Text = "Struk akan tampil setelah pembayaran berhasil.";
            return _receiptBox;
        }

        private Panel CreateSectionPanel(string titleText, string subtitleText)
        {
            var outer = new Panel();
            outer.Dock = DockStyle.Fill;
            outer.BackColor = _panel;
            outer.Padding = new Padding(18, 76, 18, 18);
            outer.Margin = new Padding(8);

            var title = new Label();
            title.AutoSize = true;
            title.Text = titleText;
            title.ForeColor = _ink;
            title.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            title.Location = new Point(18, 16);

            var subtitle = new Label();
            subtitle.AutoSize = true;
            subtitle.Text = subtitleText;
            subtitle.ForeColor = _muted;
            subtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            subtitle.Location = new Point(20, 48);

            outer.Paint += delegate(object sender, PaintEventArgs e)
            {
                using (var pen = new Pen(_line))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, outer.Width - 1, outer.Height - 1);
                }
            };

            outer.Controls.Add(title);
            outer.Controls.Add(subtitle);
            return outer;
        }

        private Control CreateMenuCard(MenuProduct product)
        {
            var card = new Panel();
            card.Size = new Size(168, 124);
            card.Margin = new Padding(7);
            card.Padding = new Padding(12);
            card.BackColor = Color.FromArgb(248, 252, 247);
            card.Cursor = Cursors.Hand;
            card.Tag = product;

            var category = new Label();
            category.AutoSize = false;
            category.Text = product.Category;
            category.ForeColor = _accent;
            category.BackColor = _accentSoft;
            category.TextAlign = ContentAlignment.MiddleCenter;
            category.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            category.Size = new Size(76, 24);
            category.Location = new Point(12, 12);

            var name = new Label();
            name.AutoSize = false;
            name.Text = product.Name;
            name.ForeColor = _ink;
            name.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            name.Size = new Size(144, 42);
            name.Location = new Point(12, 44);

            var price = new Label();
            price.AutoSize = false;
            price.Text = FormatRupiah(product.Price);
            price.ForeColor = _success;
            price.Font = new Font("Consolas", 10F, FontStyle.Bold);
            price.Size = new Size(112, 24);
            price.Location = new Point(12, 88);

            var plus = new Label();
            plus.AutoSize = false;
            plus.Text = "+";
            plus.TextAlign = ContentAlignment.MiddleCenter;
            plus.ForeColor = Color.White;
            plus.BackColor = _accent;
            plus.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            plus.Size = new Size(30, 30);
            plus.Location = new Point(126, 82);
            plus.Cursor = Cursors.Hand;

            card.Paint += delegate(object sender, PaintEventArgs e)
            {
                using (var pen = new Pen(_line))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            card.MouseEnter += delegate { card.BackColor = Color.FromArgb(236, 248, 243); };
            card.MouseLeave += delegate { card.BackColor = Color.FromArgb(248, 252, 247); };
            card.Click += delegate { AddToCart(product); };
            category.Click += delegate { AddToCart(product); };
            name.Click += delegate { AddToCart(product); };
            price.Click += delegate { AddToCart(product); };
            plus.Click += delegate { AddToCart(product); };

            card.Controls.Add(category);
            card.Controls.Add(name);
            card.Controls.Add(price);
            card.Controls.Add(plus);
            return card;
        }

        private Label AddSummaryRow(TableLayoutPanel table, int row, string title)
        {
            var titleLabel = new Label();
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Text = title;
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            titleLabel.ForeColor = _muted;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            var valueLabel = new Label();
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Text = FormatRupiah(0m);
            valueLabel.TextAlign = ContentAlignment.MiddleRight;
            valueLabel.ForeColor = _ink;
            valueLabel.Font = new Font("Consolas", 10F, FontStyle.Bold);

            table.Controls.Add(titleLabel, 0, row);
            table.Controls.Add(valueLabel, 1, row);
            return valueLabel;
        }

        private Label CreateFieldLabel(string text)
        {
            var label = new Label();
            label.Dock = DockStyle.Fill;
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.ForeColor = _ink;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            return label;
        }

        private TextBox CreateInput(string text)
        {
            var input = new TextBox();
            input.Dock = DockStyle.Fill;
            input.Text = text;
            input.BorderStyle = BorderStyle.FixedSingle;
            input.Font = new Font("Consolas", 12F, FontStyle.Regular);
            input.TextAlign = HorizontalAlignment.Right;
            input.Margin = new Padding(0, 6, 0, 6);
            return input;
        }

        private Button CreateActionButton(string text, Color backColor, int width)
        {
            var button = new Button();
            button.Text = text;
            button.Width = width;
            button.Height = 40;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            button.Margin = new Padding(0, 0, 8, 0);
            button.Cursor = Cursors.Hand;
            return button;
        }

        private void AddToCart(MenuProduct product)
        {
            CartLine existing = _cart.FirstOrDefault(line => line.Product.Name == product.Name);
            if (existing == null)
            {
                _cart.Add(new CartLine(product));
            }
            else
            {
                existing.Quantity++;
            }

            RefreshCartGrid();
            RefreshTotals();
        }

        private void ChangeSelectedQuantity(int amount)
        {
            CartLine line = GetSelectedLine();
            if (line == null)
            {
                MessageBox.Show("Pilih item di keranjang terlebih dahulu.", "Keranjang", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            line.Quantity += amount;
            if (line.Quantity <= 0)
            {
                _cart.Remove(line);
            }

            RefreshCartGrid();
            RefreshTotals();
        }

        private void RemoveSelectedLine()
        {
            CartLine line = GetSelectedLine();
            if (line == null)
            {
                MessageBox.Show("Pilih item yang ingin dihapus.", "Keranjang", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _cart.Remove(line);
            RefreshCartGrid();
            RefreshTotals();
        }

        private CartLine GetSelectedLine()
        {
            if (_cartGrid.SelectedRows.Count == 0)
            {
                return null;
            }

            return _cartGrid.SelectedRows[0].Tag as CartLine;
        }

        private void RefreshCartGrid()
        {
            _cartGrid.Rows.Clear();

            foreach (CartLine line in _cart)
            {
                int rowIndex = _cartGrid.Rows.Add(
                    line.Product.Name,
                    FormatRupiah(line.Product.Price),
                    line.Quantity.ToString(_culture),
                    FormatRupiah(line.LineTotal));
                _cartGrid.Rows[rowIndex].Tag = line;
            }
        }

        private void RefreshTotals()
        {
            decimal subtotal = GetSubtotal();
            decimal discount = GetDiscountAmount(subtotal);
            decimal afterDiscount = Math.Max(0m, subtotal - discount);
            decimal tax = GetTaxAmount(afterDiscount);
            decimal total = afterDiscount + tax;
            decimal cash;
            decimal change = 0m;

            if (TryParseMoney(_cashInput.Text, out cash) && cash >= total)
            {
                change = cash - total;
            }

            _subtotalValue.Text = FormatRupiah(subtotal);
            _discountValue.Text = "- " + FormatRupiah(discount);
            _taxValue.Text = FormatRupiah(tax);
            _grandTotalValue.Text = FormatRupiah(total);
            _changeValue.Text = FormatRupiah(change);
        }

        private decimal GetSubtotal()
        {
            return _cart.Sum(line => line.LineTotal);
        }

        private decimal GetDiscountPercent()
        {
            decimal discount;
            if (string.IsNullOrWhiteSpace(_discountInput.Text))
            {
                return 0m;
            }

            if (!decimal.TryParse(_discountInput.Text, NumberStyles.Number, _culture, out discount) &&
                !decimal.TryParse(_discountInput.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out discount))
            {
                return 0m;
            }

            if (discount < 0m)
            {
                return 0m;
            }

            if (discount > 100m)
            {
                return 100m;
            }

            return discount;
        }

        private bool TryValidateDiscount(out decimal discount)
        {
            discount = 0m;
            if (string.IsNullOrWhiteSpace(_discountInput.Text))
            {
                return true;
            }

            if (!decimal.TryParse(_discountInput.Text, NumberStyles.Number, _culture, out discount) &&
                !decimal.TryParse(_discountInput.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out discount))
            {
                MessageBox.Show("Diskon harus berupa angka 0 sampai 100.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (discount < 0m || discount > 100m)
            {
                MessageBox.Show("Diskon harus berada di antara 0 sampai 100 persen.", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private decimal GetDiscountAmount(decimal subtotal)
        {
            return subtotal * (GetDiscountPercent() / 100m);
        }

        private decimal GetTaxAmount(decimal afterDiscount)
        {
            return afterDiscount * TaxRate;
        }

        private decimal GetGrandTotal()
        {
            decimal subtotal = GetSubtotal();
            decimal afterDiscount = Math.Max(0m, subtotal - GetDiscountAmount(subtotal));
            return afterDiscount + GetTaxAmount(afterDiscount);
        }

        private void ProcessPayment()
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong. Pilih menu terlebih dahulu.", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal discount;
            if (!TryValidateDiscount(out discount))
            {
                return;
            }

            decimal cash;
            if (!TryParseMoney(_cashInput.Text, out cash))
            {
                MessageBox.Show("Masukkan jumlah uang bayar dengan benar.", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = GetGrandTotal();
            if (cash < total)
            {
                MessageBox.Show("Uang bayar belum cukup.", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal change = cash - total;
            _changeValue.Text = FormatRupiah(change);
            _receiptBox.Text = BuildReceipt(cash, change);
            MessageBox.Show("Pembayaran berhasil diproses.", "Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ResetTransaction()
        {
            _cart.Clear();
            _discountInput.Text = "0";
            _cashInput.Clear();
            _receiptBox.Text = "Struk akan tampil setelah pembayaran berhasil.";
            RefreshCartGrid();
            RefreshTotals();
        }

        private string BuildReceipt(decimal cash, decimal change)
        {
            decimal subtotal = GetSubtotal();
            decimal discount = GetDiscountAmount(subtotal);
            decimal afterDiscount = Math.Max(0m, subtotal - discount);
            decimal tax = GetTaxAmount(afterDiscount);
            decimal total = afterDiscount + tax;

            var receipt = new StringBuilder();
            receipt.AppendLine("KASIR MAKANAN");
            receipt.AppendLine("Tanggal: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm", _culture));
            receipt.AppendLine();
            receipt.AppendLine("Item:");

            foreach (CartLine line in _cart)
            {
                receipt.AppendLine("- " + line.Product.Name + " x" + line.Quantity.ToString(_culture) + "  " + FormatRupiah(line.LineTotal));
            }

            receipt.AppendLine();
            receipt.AppendLine(PadReceiptLine("Subtotal", subtotal));
            receipt.AppendLine(PadReceiptLine("Diskon", discount));
            receipt.AppendLine(PadReceiptLine("Pajak 10%", tax));
            receipt.AppendLine(PadReceiptLine("Total", total));
            receipt.AppendLine(PadReceiptLine("Bayar", cash));
            receipt.AppendLine(PadReceiptLine("Kembali", change));
            receipt.AppendLine();
            receipt.AppendLine("Terima kasih.");
            return receipt.ToString();
        }

        private string PadReceiptLine(string label, decimal value)
        {
            return label.PadRight(13) + FormatRupiah(value).PadLeft(13);
        }

        private bool TryParseMoney(string text, out decimal value)
        {
            value = 0m;
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            string normalized = text.Replace("Rp", "").Replace("rp", "").Trim();
            return decimal.TryParse(normalized, NumberStyles.Number, _culture, out value) ||
                   decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        private string FormatRupiah(decimal value)
        {
            return "Rp " + value.ToString("N0", _culture);
        }
    }
}
