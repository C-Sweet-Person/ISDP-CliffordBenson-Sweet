window.onload = function()
{
orderCheck()
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


}

//-- Vigenère --
// Joxiutvc K foin lsog
// I rexe lef cyhknq ttamxkcow cnn
// mh trmu wkw c roen wofuidi K'd li niditavpa
// hkgmen sp dkc 1. K'm rsrevius sr gvova wkc.