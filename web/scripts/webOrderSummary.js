window.onload = function()
{
orderCheck()
orderSumUp()
document.querySelector("#submitButton").addEventListener("click",orderFinalSubmit)
}

/**
 * This function just checks to see if there's a sessionObject with "orderInfo" made.
 * If not, display an alert and redirect a customer: they shouldn't be here. That's just
 * silly.
 */

function orderCheck()
{
    if (sessionStorage.getItem("orderInfo") == null)
    {
        alert("Please order something before coming here.");
        window.location.href = "webOrder.php";
    }
    else
    {
        console.log(sessionStorage.getItem("orderInfo"));
    }
}

/**
 * This function will just compile the object
 * into lines and also calculate the grand total
 * of the cart.
 */

function orderSumUp()
{
let items = JSON.parse(sessionStorage.getItem("orderInfo"));
let summaryTable = document.querySelector("#orderSummary");
console.log(items);
let cartItems = items.items;
let totalPrice = 0;
for (let i = 0; i < cartItems.length; i++)
{
    let name = cartItems[i].name
    let quantity = cartItems[i].quantity
    let id = cartItems[i].ID
    let price = cartItems[i].price
    html = `<p>Product Name: ${name}, ID: ${id}, QTY: ${quantity}, Price: ${price}</p>`;
    totalPrice += (Number(quantity) * Number(price))
    summaryTable.innerHTML += html;
    console.log(i)
}
summaryTable.innerHTML += `<p>Grand total: $${totalPrice}</p>`
}

/**
 * This function basically just
 * grabs the info from the user areas
 * which will also make sure that
 * the textboxes aren't blank
 * prior to the completion.
 */

function orderFinalSubmit()
{
let name = document.querySelector("#custName").value;
let phone = document.querySelector("#custPhone").value;
let email = document.querySelector("#custEmail").value;
if (isNaN(parseInt(phone)))
{
    alert("Please enter a valid phone number");
}
console.log(name,phone,email);

}

//-- Vigenère --
// Joxiutvc K foin lsog
// I rexe lef cyhknq ttamxkcow cnn
// mh trmu wkw c roen wofuidi K'd li niditavpa
// hkgmen sp dkc 1. K'm rsrevius sr gvova wkc.