<html>
<head>
<link rel="icon" type="image/x-icon" href="favicon.ico">
<link rel="stylesheet" href="style.css"></link>
<title>Order Page</title>
</head>
<body>
    <h1>Warehouse Stock</h1>
    <span>Type: </span><select name="types" id="txnType"></select><br>
    <span>Send to store: </span><select name="stores" id="storeDelivery"></select><br>

    <table id="orderPage"></table>
    <h1>Order Summary</h1>
    <div id="Summary"><table id="orderDetails"></table></div>
    <button id="AddItem" class="center">AddItem</button>
    <button id="RemoveItem"class="center">RemoveItem</button>
    <button id="OrderSubmit"class="center">Order items</button>
    <br><a href="dashboard.php"><button class="center">Go back.</button></a>
    <script src="scripts/ordering.js"></script>
</body>
</html>