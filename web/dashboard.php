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
    echo $user[0]->username;
    if ($user[0]->positionID == 4)
    {
        header("Location: warehouseDashboard.php");
    }?></p>
 <?php if (strcmp($user[0]->username,"admin" || strcmp($user[0]->getPositionID,"3")) === 0)
 {
     echo "<p><a href='OrderPage.php'>Order Page</a></p>";
 }
 ?>
<h1>User Dashboard</h1>
<div id="Menu">
    <a href="viewInventory.php"><p class="option">View Inventory</p></a>
    <p class="option" id="createOrder">Create Store Orders</p>
    <p class="option" id="createEOrder">Create Emergency Orders</p>
</div>
<hr>
<div id="tableDisplay"><table id="tableItems"></table>
</div>
<table>
</table>
<p id="currentIndex"></p>
<button id="Previous">Prev</button>
<button id="Forward">Next</button>
<br><a href="login.php"><button id="Logout">Logout</button></a>
<br><button id="Test">Test</button>
<script src="scripts/Dashboard.js"></script>
</body>
</html>