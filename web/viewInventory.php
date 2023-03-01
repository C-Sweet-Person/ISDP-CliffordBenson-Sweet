<html>
    <head>
    <?php Session_start()?>
    <?php
    $user = json_decode($_SESSION['user']);
    echo $user[0]->username;
    ?>
        <meta charset="UTF-8">
        <title>View Inventory - Bullseye Sporting Goods</title>
        <style>
            #tableItems td, #tableItems th
            {
                border:solid thin black;
                padding: 5px;
            }
            table
            {
                border-collapse: collapse;

            }
            </style>
</head>
<body>
<h1>All inventory Items</h1>
<table id="tableItems"></table>
<?php
    $user = json_decode($_SESSION['user']);
    if (strcmp($user[0]->positionID,"4"))
    {
        echo "<a href='warehouseDashboard.php'>Back to dashboard</a>";
    }
    else
    {
        echo "<a href='dashboard.php'>Back to dashboard</a>";
    }
?>
<script src="scripts/inventoryDash.js"></script>
</body>
</html>