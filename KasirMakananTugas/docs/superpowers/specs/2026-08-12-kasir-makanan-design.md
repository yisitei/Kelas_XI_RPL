# Kasir Makanan Design

## Goal

Build a simple food cashier application for a school assignment using the existing C# WinForms project. The app runs locally, uses no database, and keeps all menu and cart data in memory while the program is open.

## Scope

The application is a single-screen cashier dashboard in `Form1`. It includes a fixed food and drink menu, a shopping cart, payment calculation, change calculation, transaction reset, and an on-screen receipt.

Out of scope: login, database storage, printing to a real printer, inventory management, user roles, and saved transaction history.

## UI Design

The form uses a polished dashboard layout:

- A dark header with the app name and short subtitle.
- A left menu section with food and drink cards.
- A center cart section showing selected items, quantity, unit price, and line total.
- A right payment section showing subtotal, discount, tax, grand total, cash input, change, and receipt preview.

The visual style should feel intentional: clear spacing, modern colors, consistent button styling, readable typography, and grouped controls that match a cashier workflow.

## Behavior

Clicking a menu item adds it to the cart. If the item already exists, its quantity increases. Cart controls allow increasing, decreasing, and removing selected items. Totals update after each cart change.

Payment flow:

- Subtotal is calculated from cart items.
- Discount is a simple fixed percentage input.
- Tax is calculated automatically.
- Total due is subtotal minus discount plus tax.
- Cash input calculates change.
- Processing payment validates that the cart is not empty and the cash amount is enough.
- A receipt is generated in the receipt preview area.

Reset clears the cart, payment fields, and receipt.

## Data Model

Use small in-memory classes:

- `MenuItem`: name, category, price.
- `CartItem`: menu item, quantity, line total.

No external package is required.

## Error Handling

The app shows message boxes for invalid states: empty cart, invalid cash input, insufficient payment, or invalid discount value. Numeric parsing uses safe parsing instead of exceptions.

## Testing

Verification is manual and build-based:

- Build the project successfully.
- Run the app if the local environment supports launching WinForms.
- Check add/remove quantity behavior, total calculation, discount, tax, insufficient cash, successful payment, receipt generation, and reset.
