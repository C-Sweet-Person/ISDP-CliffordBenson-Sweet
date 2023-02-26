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
 <?php if (strcmp($user[0]->username,"admin") === 0)
 {
     echo "<p><a href='OrderPage.php'>Order Page</a></p>";
 }
 else
 {
     echo "Whatever";
 }
 ?>
<h1>User Dashboard</h1>
<div id="Menu">
    <p class="option" id="createOrder">Create Store Orders</p>
    <p class="option" id="createEOrder">Create Emergency Orders</p>
    <p class="option" id="RecieveOrder">Recieve Orders</p>
    <p class="option" id="RecieveOrder">Fulfil Orders</p>
</div>
<hr>
<div id="tableDisplay"><table id="tableItems"></table>
</div>
<table>
</table>
<p id="currentIndex"></p>
<button id="Previous">Prev</button>
<button id="Forward">Next</button>
<br><button id="Logout">Logout</button>
<br><button id="Test">Test</button>
<script src="scripts/WHDashboard.js"></script>
</body>
</html>