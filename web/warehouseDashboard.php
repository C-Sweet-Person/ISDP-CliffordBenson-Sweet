<html>
    <head>
        <?php Session_start()?>
        <style>

            #tableItems th, td, table 
            {
                border: solid thin black;
                border-collapse: collapse;
                padding: 2px;
            }
            #tableDisplay
            {
                border: solid thin black;
                padding: 5px;
                height: 300px;
                overflow: scroll;
                width: fit-content;
                margin: auto;
            }
        </style>
                    <link rel="stylesheet" href="style.css"></link>
                    <link rel="icon" type="image/x-icon" href="favicon.ico">
<title>Dashboard Page</title>
</head>
<body>
    <p id="Signed"><?php
    $user = json_decode($_SESSION['user']);
    echo $user[0]->username ?></p>
<h1>Warehouse Dashboard</h1>
<div id="Menu">
    <a href="viewInventory.php"><p class="option">View Inventory</p></a>
    <a href="OrderPage.php"><p class="option" id="createOrder">Create Orders</p></a>
    <p class="option" id="RecieveOrder">Recieve Orders</p>
    <p class="option" id="FulfilOrder">Fulfil Orders</p>
</div>
<hr>
<div id="WHtableDisplay"><table id="tableItems"></table>
</div>
<table>
</table>
<p id="currentIndex"></p>
<button id="Previous">Prev</button>
<button id="Forward">Next</button>
<br><a href="login.php"><button id="Logout">Logout</button></a>
<br><button id="Test">Test</button>
<script src="scripts/WHDashboard.js"></script>
</body>
</html>