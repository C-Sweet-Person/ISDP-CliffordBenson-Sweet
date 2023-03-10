<html>
<head>
<title>Web Order - Bullsye Sporting Goods</title>
<meta charset="UTF-8">
<style>
    .hidden
    {
        display:none;
        color:red;
    }
    #contentArea
    {
    border: solid thin black;
    overflow:hidden;
    }
    #tableItems
    {
        border: solid thin black;
        width: 54%;
        float: left;
    }
    #shoppingCartItems
    {
        width:46%;
        border: solid thin black;
        float: left;
    }
    .qty
    {
        width: 60px;
    }
    </style>
</head>
<body>
<h1>Items to order.</h1>
<label for="storeSelect">Store Select: </label><select name="Store" id="storeSelect"></select>
<label for="itemSearch">Search items: </label><input type ="text" id="itemSearch"><button id="searchButton">Search</button>
<div id="contentArea">
<table id="tableItems"></table>
<div id="Shipping"><u>Shopping Cart Items</u><table id="shoppingCartItems"></table></div>
</div>
<button id="orderSubmit">Submit</button><button id="addItem">Add to cart</button>
<a href="homepage.php"><button id="orderSubmit">Back</button></a>

<script src="scripts/webOrdering.js"></script>
</div>
</body>
</html>