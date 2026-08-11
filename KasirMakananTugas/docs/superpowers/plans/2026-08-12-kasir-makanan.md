# Kasir Makanan Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a polished simple food cashier app in the existing C# WinForms project.

**Architecture:** Use the existing .NET Framework 4.7.2 WinForms project and implement the app as a single-screen `Form1`. The UI is built programmatically in C# to avoid fragile designer layout edits, with small in-memory `MenuProduct` and `CartLine` classes inside `Form1`.

**Tech Stack:** C#, .NET Framework 4.7.2, Windows Forms, no external packages, no database.

## Global Constraints

- The app runs locally and uses no database.
- Menu and cart data are stored in memory while the program is open.
- The primary UI is a single-screen cashier dashboard in `Form1`.
- Out of scope: login, database storage, real printer integration, inventory management, user roles, and saved transaction history.
- Numeric parsing must be safe and show user-friendly message boxes for invalid states.

---

### Task 1: Replace Empty Form With Cashier Dashboard

**Files:**
- Modify: `KasirMakananTugas/Form1.cs`
- Modify: `KasirMakananTugas/Form1.Designer.cs`

**Interfaces:**
- Produces: `Form1` constructor calls `InitializeComponent()`, then initializes menu data, builds the UI, and refreshes totals.
- Produces: private model class `MenuProduct` with `Name`, `Category`, and `Price`.
- Produces: private model class `CartLine` with `Product`, `Quantity`, and `LineTotal`.

- [ ] **Step 1: Replace designer layout with a clean shell**

Set `Form1.Designer.cs` to keep only standard designer infrastructure and basic form settings:

```csharp
private void InitializeComponent()
{
    this.SuspendLayout();
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(1180, 720);
    this.MinimumSize = new System.Drawing.Size(1060, 650);
    this.Name = "Form1";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = "Kasir Makanan";
    this.ResumeLayout(false);
}
```

- [ ] **Step 2: Add fields and model classes to `Form1.cs`**

Add fields for menu data, cart data, panels, labels, text boxes, buttons, `DataGridView`, and receipt preview. Define:

```csharp
private sealed class MenuProduct
{
    public MenuProduct(string name, string category, decimal price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public string Name { get; }
    public string Category { get; }
    public decimal Price { get; }
}

private sealed class CartLine
{
    public CartLine(MenuProduct product)
    {
        Product = product;
        Quantity = 1;
    }

    public MenuProduct Product { get; }
    public int Quantity { get; set; }
    public decimal LineTotal { get { return Product.Price * Quantity; } }
}
```

- [ ] **Step 3: Build the visual layout**

Create a dark header, left menu panel, center cart panel, and right payment/receipt panel using `TableLayoutPanel`, `Panel`, `FlowLayoutPanel`, `DataGridView`, `TextBox`, `Label`, and `Button`. Use colors:

```csharp
private readonly Color _ink = Color.FromArgb(25, 32, 45);
private readonly Color _surface = Color.FromArgb(247, 249, 252);
private readonly Color _panel = Color.White;
private readonly Color _accent = Color.FromArgb(34, 139, 230);
private readonly Color _success = Color.FromArgb(22, 163, 74);
private readonly Color _danger = Color.FromArgb(220, 38, 38);
```

- [ ] **Step 4: Add static menu items**

Create at least 10 products:

```csharp
new MenuProduct("Nasi Goreng Spesial", "Makanan", 18000m)
new MenuProduct("Mie Ayam Bakso", "Makanan", 16000m)
new MenuProduct("Ayam Geprek", "Makanan", 17000m)
new MenuProduct("Bakso Kuah", "Makanan", 15000m)
new MenuProduct("Soto Ayam", "Makanan", 14000m)
new MenuProduct("Es Teh Manis", "Minuman", 5000m)
new MenuProduct("Es Jeruk", "Minuman", 7000m)
new MenuProduct("Kopi Susu", "Minuman", 9000m)
new MenuProduct("Air Mineral", "Minuman", 4000m)
new MenuProduct("Pisang Goreng", "Snack", 8000m)
```

- [ ] **Step 5: Build check**

Run: `msbuild KasirMakananTugas.slnx /p:Configuration=Debug`

Expected: the project compiles, or if `msbuild` is unavailable, use Visual Studio build.

---

### Task 2: Implement Cart, Payment, Receipt, And Reset Behavior

**Files:**
- Modify: `KasirMakananTugas/Form1.cs`

**Interfaces:**
- Consumes: `MenuProduct`, `CartLine`, layout controls from Task 1.
- Produces: `AddToCart(MenuProduct product)`, `RefreshCartGrid()`, `RefreshTotals()`, `ProcessPayment()`, `ResetTransaction()`, and `BuildReceipt(decimal cash, decimal change)`.

- [ ] **Step 1: Add cart behavior**

Implement:

```csharp
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
```

Add selected-line buttons for plus, minus, and remove. Minus removes a line when quantity reaches zero.

- [ ] **Step 2: Add totals calculation**

Use:

```csharp
private decimal GetSubtotal()
private decimal GetDiscountPercent()
private decimal GetDiscountAmount(decimal subtotal)
private decimal GetTaxAmount(decimal afterDiscount)
private decimal GetGrandTotal()
```

Tax rate is `0.10m`. Discount defaults to `0`.

- [ ] **Step 3: Add payment validation**

`ProcessPayment()` must show message boxes for empty cart, invalid cash, or insufficient cash. If valid, it calculates change, updates the change label, and writes receipt text.

- [ ] **Step 4: Add receipt generation**

Receipt format:

```text
KASIR MAKANAN
Tanggal: yyyy-MM-dd HH:mm

Item:
- Nasi Goreng Spesial x2  Rp 36.000

Subtotal     Rp ...
Diskon       Rp ...
Pajak 10%    Rp ...
Total        Rp ...
Bayar        Rp ...
Kembali      Rp ...

Terima kasih.
```

- [ ] **Step 5: Add reset behavior**

`ResetTransaction()` clears `_cart`, cash input, discount input, change label, receipt text, grid rows, and totals.

- [ ] **Step 6: Manual verification**

Check these flows:

- Add one product and confirm quantity `1`.
- Add same product again and confirm quantity `2`.
- Use minus and remove buttons.
- Enter discount `10` and confirm total decreases before tax.
- Enter cash less than total and confirm warning.
- Enter enough cash and confirm receipt plus change.
- Reset and confirm the screen returns to the default state.

- [ ] **Step 7: Build check**

Run: `msbuild KasirMakananTugas.slnx /p:Configuration=Debug`

Expected: the project compiles without errors.

---

## Self-Review

- Spec coverage: single-screen dashboard, menu cards, cart, totals, discount, tax, cash, change, receipt, reset, no database, and validation are covered.
- Placeholder scan: no placeholder work remains.
- Type consistency: `MenuProduct`, `CartLine`, and method names are consistent across tasks.
